using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Animals.Models;

namespace Animals.Networking
{
    // Очень простой TCP-сервер; хранит коллекцию на каждый клиент.
    public class AnimalServer
    {
        private readonly TcpListener listener;
        private readonly CancellationTokenSource cts = new();
        private readonly ConcurrentDictionary<TcpClient, AnimalCollection> storage = new();

        public AnimalServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            _ = AcceptLoop();
        }

        public void Stop()
        {
            cts.Cancel();
            listener.Stop();
        }

        private async Task AcceptLoop()
        {
            while (!cts.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync(cts.Token);
                storage[client] = new AnimalCollection();
                _ = HandleClient(client);
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            var stream = client.GetStream();
            var buffer = new byte[8192];

            try
            {
                while (!cts.IsCancellationRequested && client.Connected)
                {
                    var len = await stream.ReadAsync(buffer, cts.Token);
                    if (len == 0) break;

                    var json = Encoding.UTF8.GetString(buffer, 0, len);
                    var msg = NetworkMessage.FromJson(json);
                    if (msg == null) continue;

                    if (msg.Type == MessageType.Sync && msg.Animals != null)
                        storage[client] = ToCollection(msg.Animals);

                    if (msg.Type == MessageType.Exchange && msg.TargetType != null)
                        await ProcessExchange(client, msg.TargetType.Value);
                }
            }
            finally
            {
                storage.TryRemove(client, out _);
                client.Close();
            }
        }

        private async Task ProcessExchange(TcpClient initiator, AnimalType type)
        {
            // Ищем любого другого клиента с животными нужного типа.
            var partnerEntry = storage.FirstOrDefault(p =>
                p.Key != initiator &&
                p.Value.GetAll().Any(a => a.Type == type));

            if (partnerEntry.Key == null) return;

            var initiatorCol = storage[initiator];
            var partnerCol = partnerEntry.Value;

            var fromInitiator = initiatorCol.ExtractByType(type);
            var fromPartner = partnerCol.ExtractByType(type);

            initiatorCol.AddRange(fromPartner);
            partnerCol.AddRange(fromInitiator);

            await SendUpdate(initiator, initiatorCol);
            await SendUpdate(partnerEntry.Key, partnerCol);
        }

        private async Task SendUpdate(TcpClient client, AnimalCollection col)
        {
            var msg = new NetworkMessage(MessageType.Update, null, col.GetAll().ToList())
                .ToJson();
            var data = Encoding.UTF8.GetBytes(msg);
            await client.GetStream().WriteAsync(data);
        }

        private static AnimalCollection ToCollection(IEnumerable<AnimalModel> list)
        {
            var col = new AnimalCollection();
            col.AddRange(list);
            return col;
        }
    }
}
