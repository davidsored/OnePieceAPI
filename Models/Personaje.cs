using System.Text.Json.Serialization;

namespace OnePieceAPI.Models;

public class Personaje
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Nombre { get; set; }

    [JsonPropertyName("job")]
    public string? Trabajo { get; set; }

    [JsonPropertyName("age")]
    public string? Edad { get; set; }

    [JsonPropertyName("bounty")]
    public string? Recompensa { get; set; }

    [JsonPropertyName("status")]
    public string? Estado { get; set; }

    [JsonPropertyName("crew")]
    public Tripulacion? Tripulacion { get; set; }

    [JsonPropertyName("fruit")]
    public Fruta? Fruta { get; set; }
}