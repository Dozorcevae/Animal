using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Animals.Domain;

namespace Animals.Simulation.Exchange
{
    public sealed class TcpExchangeService : IAnimalExchangeService, IDisposable
    {
        private readonly TcpClient _tcp = new();
        private readonly StreamWriter _writer;
        private readonly StreamReader _reader;

        public int ClientId { get; private set; }
        public int SelectedPeerId { get; set; }        // задаёт UI
        public event Action<int[]>? ClientsChanged;      // новые id
        public event Action? ExchangeCompleted;   // чтобы обновить списки

        private readonly AnimalCollection _local;

        public TcpExchangeService(string host, int port, AnimalCollection local)
        {
            _local = local;
            _tcp.Connect(host, port);
            _writer = new StreamWriter(_tcp.GetStream(), Encoding.UTF8) { AutoFlush = true };
            _reader = new StreamReader(_tcp.GetStream(), Encoding.UTF8);

            _ = Task.Run(ReadLoop);
        }

        // вызывается кнопкой UI
        public void ExchangeByClass(AnimalCollection me, AnimalCollection _, AnimalClass cls)
        {
            var dto = new { From = ClientId, To = SelectedPeerId, Cls = cls };
            var msg = new { Command = "EXCHANGE", Payload = dto };
            _writer.WriteLine(JsonSerializer.Serialize(msg));
        }

        private async Task ReadLoop()
        {
            while (!_reader.EndOfStream)
            {
                var line = await _reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var msg = JsonSerializer.Deserialize<Message>(line);
                switch (msg!.Command)
                {
                    case "CLIENT_LIST":
                        var ids = msg.Payload!.Value.Deserialize<int[]>()!;
                        ClientsChanged?.Invoke(ids);
                        break;

                    case "EXCHANGE":
                        var dto = msg.Payload!.Value.Deserialize<ExchangeDto>()!;
                        if (dto.To == ClientId)               // я получатель
                            ApplyExchange(dto);
                        break;
                }
            }
        }

        private void ApplyExchange(ExchangeDto dto)
        {
            var others = _local.GetByClass(dto.Cls).ToList();
            _local.RemoveByClass(dto.Cls);          // убрали своих
            _local.AddRange(dto.Swap!);             // добавили присланных

            ExchangeCompleted?.Invoke();
        }

        public void Dispose() => _tcp.Close();

        // локальные DTO (те же, что на сервере)
        private record Message(string Command, JsonElement? Payload);
        private record ExchangeDto(int From, int To, AnimalClass Cls, List<BaseAnimal> Swap);
    }
}
