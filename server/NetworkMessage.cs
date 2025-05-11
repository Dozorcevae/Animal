using System.Text.Json;
using Animals.Models;

namespace Animals.Networking
{
    // Универсальное сообщение (JSON).
    public record NetworkMessage
    (
        MessageType Type,
        AnimalType? TargetType,
        List<AnimalModel>? Animals
    )
    {
        public string ToJson() => JsonSerializer.Serialize(this,
            new JsonSerializerOptions { WriteIndented = false });

        public static NetworkMessage? FromJson(string json) =>
            JsonSerializer.Deserialize<NetworkMessage>(json);
    }
}
