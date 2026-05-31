using System.Net.Http.Json;
using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public class EspadaService : IEspadaService
{
    private readonly HttpClient _httpclient;

    public EspadaService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<Espada?> ObtenerEspadaAsync(string identificador)
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/swords/en/{identificador.ToLower()}");

        if (respuesta.IsSuccessStatusCode)
        {
            return await respuesta.Content.ReadFromJsonAsync<Espada>();
        }

        return null;
    }

    public async Task<List<Espada>> ObtenerTodasLasEspadasAsync()
    {
        var respuesta = await _httpclient.GetAsync("https://api.api-onepiece.com/v2/swords/en");

        if (respuesta.IsSuccessStatusCode)
        {
            var espadas = await respuesta.Content.ReadFromJsonAsync<List<Espada>>();

            return espadas ?? new List<Espada>();
        }

        return new List<Espada>();
    }
}