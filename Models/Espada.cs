using System.Text.Json.Serialization;

namespace OnePieceAPI.Models;

public class Espada
{
    
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("name")]
    public string? Nombre { get; set; }

    [JsonPropertyName("roman-name")]
    public string? NombreRomano { get; set; }

    [JsonPropertyName("type")]
    public string? Tipo { get; set; }

    [JsonPropertyName("category")]
    public string? Categoria { get; set; }

    [JsonPropertyName("description")]
    public string? Descripcion { get; set; }

    [JsonPropertyName("isDestroy")]
    public bool? EstaDestruida { get; set; }
}