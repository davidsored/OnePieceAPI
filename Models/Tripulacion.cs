using System.Text.Json.Serialization;

namespace OnePieceAPI.Models;

public class Tripulacion
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Nombre { get; set; }

    [JsonPropertyName("description")]
    public string? Descripcion { get; set; }

    [JsonPropertyName("status")]
    public string? Estado { get; set; }

    [JsonPropertyName("number")]
    public string? Numero { get; set; }

    [JsonPropertyName("roman_name")]
    public string? NombreRomano { get; set; }

    [JsonPropertyName("total_prime")]
    public string? RecompensaTotal { get; set; }

    [JsonPropertyName("is_yonko")]
    public bool EsYonko { get; set; }
}