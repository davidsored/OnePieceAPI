using System.Text.Json.Serialization;

namespace OnePieceAPI.Models;

public class Haki
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string? Nombre { get; set; }

    [JsonPropertyName("roman-name")]
    public string? NombreRomano { get; set; }    

    [JsonPropertyName("description")]
    public string? Descripcion { get; set; }
}