using System.Text.Json.Serialization;

namespace OnePieceAPI.Models;

public class Fruta
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Nombre { get; set; }

    [JsonPropertyName("roman_name")]
    public string? NombreRomano { get; set; }

    [JsonPropertyName("type")]
    public string? Tipo { get; set; }

    [JsonPropertyName("description")]
    public string? Descripcion { get; set; }

    [JsonPropertyName("filename")]
    public string? NombreArchivo { get; set; }

    [JsonPropertyName("technicalFile")]
    public string? ArchivoTecnico { get; set; }
}