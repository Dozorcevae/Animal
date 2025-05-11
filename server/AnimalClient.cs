using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Animals.Models;

namespace Animals.Networking
{
    // Клиент-обёртка для форм.
    public class AnimalClient
    {
        private readonly TcpClient tcp = new();
        private readonly CancellationTokenSource cts = new();
        private readonly AnimalCollection local;

        public event Action? CollectionChanged; // триггер для GUI

        public AnimalClient(AnimalCollection collection)
        {
            local = collection;
        }

        public async Task ConnectAsync(string host = "127.0.0.1", int port = 9000)
        {
            await tcp.ConnectAsync(host, port);
            _ = ReceiveLoop();
            await SyncAsync();
        }

        public async Task SyncAsync()
        {
            var msg = new NetworkMessage(MessageType.Sync, null, local.GetAll().ToList())
                .ToJson();
            await SendAsync(msg);
        }

        public async Task ExchangeAsync(AnimalType type)
        {
            var msg = new NetworkMessage(MessageType.Exchange, type, null).ToJson();
            await SendAsync(msg);
        }

        private async Task SendAsync(string json)
        {
            var data = Encoding.UTF8.GetBytes(json);
            await tcp.GetStream().WriteAsync(data);
        }

        private async Task ReceiveLoop()
        {
            var stream = tcp.GetStream();
            var buffer = new byte[8192];

            while (!cts.IsCancellationRequested)
            {
                var len = await stream.ReadAsync(buffer, cts.Token);
                if (len == 0) break;

                var json = Encoding.UTF8.GetString(buffer, 0, len);
                var msg = JsonSerializer.Deserialize<NetworkMessage>(json);
                if (msg?.Type == MessageType.Update && msg.Animals != null)
                {
                    local.GetAll().ToList().ForEach(a => local.Remove(a));
                    local.AddRange(msg.Animals);
                    CollectionChanged?.Invoke();
                }
            }
        }
    }
}
