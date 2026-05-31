using System.Net.Http.Json;
using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public class HakiService : IHakiService
{
    private readonly HttpClient _httpclient;

    public HakiService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<Haki?> ObtenerHakiAsync(string identificador)
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/hakis/en/{identificador.ToLower()}");
        if (respuesta.IsSuccessStatusCode)
        {
            return await respuesta.Content.ReadFromJsonAsync<Haki>();
        }

        return null;
    }

    public async Task<List<Haki?>> ObtenerTodosLosHakisAsync()
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/hakis/en");
        if (respuesta.IsSuccessStatusCode)
        {
            var haki = await respuesta.Content.ReadFromJsonAsync<List<Haki>>();

            return haki ??new List<Haki?>();
        }

        return null;
    }
}