using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Animals.Domain;

const int PORT = 5555;
var listener = new TcpListener(IPAddress.Any, PORT);
listener.Start();
Console.WriteLine($"Server started on *:{PORT}");

// Глобальное хранилище клиентов
var clients = new Dictionary<int, ClientInfo>();
var nextId = 1;
async Task HandleClient(TcpClient tcp)
{
    int id = Interlocked.Increment(ref nextId);
    var ci = new ClientInfo(id, tcp);
    clients[id] = ci;

    Console.WriteLine($"Client {id} connected");
    BroadcastClients();                            // отправить новый список

    using var reader = new StreamReader(tcp.GetStream(), Encoding.UTF8);
    while (tcp.Connected && !reader.EndOfStream)
    {
        var line = await reader.ReadLineAsync();
        if (string.IsNullOrWhiteSpace(line)) continue;

        var msg = JsonSerializer.Deserialize<Message>(line);
        if (msg == null) continue;

        switch (msg.Command)
        {
            case "EXCHANGE":
                ProcessExchange(msg);
                break;
                // здесь можно добавить новые команды (CHAT, PING, ...)
        }
    }

    // отключение клиента
    clients.Remove(id);
    ci.Dispose();
    BroadcastClients();
    Console.WriteLine($"Client {id} disconnected");
}

// Рассылает всем актуальный список ClientId
void BroadcastClients()
{
    var ids = clients.Keys.ToArray();
    var listMsg = new Message("CLIENT_LIST", JsonSerializer.SerializeToElement(ids));
    foreach (var c in clients.Values) c.Send(listMsg);
}

// Основной цикл: ждём новых TCP-подключений
while (true)
{
    var tcp = listener.AcceptTcpClient();          // блокирующий вызов
    _ = Task.Run(() => HandleClient(tcp));         // обслуживаем асинхронно
}

// Пересылает EXCHANGE обеим сторонам
void ProcessExchange(Message m)
{
    var dto = m.Payload!.Value.Deserialize<ExchangeDto>();
    if (dto == null) return;

    SendTo(dto.From, m);
    SendTo(dto.To, m);
}

void SendTo(int id, Message m)
{
    if (clients.TryGetValue(id, out var c))
        c.Send(m);
}

// Универсальная обёртка любого сообщения.
record Message(string Command, JsonElement? Payload);

// Полезная нагрузка для команды EXCHANGE.
record ExchangeDto(int From, int To, AnimalClass Cls);

// Утилита отправки одному клиенту

// Инкапсуляция клиента на сервере.
sealed class ClientInfo : IDisposable
{
    public int Id { get; }
    private readonly StreamWriter _writer;

    public ClientInfo(int id, TcpClient tcp)
    {
        Id = id;
        _writer = new StreamWriter(tcp.GetStream(), Encoding.UTF8) { AutoFlush = true };
    }

    public void Send(Message m) =>
        _writer.WriteLine(JsonSerializer.Serialize(m));

    public void Dispose() => _writer.Dispose();
}