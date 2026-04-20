using System.Text.Json.Serialization;

namespace MauiApp1.Models
{
    public class Player
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("posicion")]
        public string Posicion { get; set; } = string.Empty;

        [JsonPropertyName("equipo")]
        public string Equipo { get; set; } = string.Empty;
    }
}