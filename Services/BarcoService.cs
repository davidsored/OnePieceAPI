using System.Net.Http.Json;
using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public class BarcoService : IBarcoService
{
    private readonly HttpClient _httpclient;

    public BarcoService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<Barco?> ObtenerBarcoAsync(string identificador)
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/boats/en/{identificador.ToLower()}");
        if (respuesta.IsSuccessStatusCode)
        {
            return await respuesta.Content.ReadFromJsonAsync<Barco>();
        }

        return null;
    }

    public async Task<List<Barco>> ObtenerTodosLosBarcosAsync()
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/boats/en");
        if (respuesta.IsSuccessStatusCode)
        {
            var barcos = await respuesta.Content.ReadFromJsonAsync<List<Barco>>();

            return barcos ?? new List<Barco>();
        }

        return new List<Barco>();
    }
}