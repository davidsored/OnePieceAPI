using System.Net.Http.Json;
using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public class FrutaService : IFrutaService
{
    private readonly HttpClient _httpclient;

    public FrutaService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<Fruta?> ObtenerFrutaAsync(string identificador)
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/fruits/en/{identificador.ToLower()}");
        if (respuesta.IsSuccessStatusCode)
        {
            return await respuesta.Content.ReadFromJsonAsync<Fruta>();
        }

        return null;
        
    }   
        
    public async Task<List<Fruta>> ObtenerTodasLasFrutasAsync()
    {
        var respuesta = await _httpclient.GetAsync("https://api.api-onepiece.com/v2/fruits/en");
        if (respuesta.IsSuccessStatusCode)
        {
            var frutas = await respuesta.Content.ReadFromJsonAsync<List<Fruta>>();

            return frutas ?? new List<Fruta>();
        }

        return new List<Fruta>();
    }
}
