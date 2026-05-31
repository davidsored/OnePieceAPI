using System.Net.Http.Json;
using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public class TripulacionService : ITripulacionService
{
    private readonly HttpClient _httpclient;

    public TripulacionService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<Tripulacion?> ObtenerTripulacionAsync(string identificador)
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/crews/en/{identificador.ToLower()}");

        if (respuesta.IsSuccessStatusCode)
        {
            return await respuesta.Content.ReadFromJsonAsync<Tripulacion>();
        }  

        return null;
    }

    public async Task<List<Tripulacion?>> ObtenerTodasLasTripulacionesAsync()
    {     
        
        var respuesta = await _httpclient.GetAsync("https://api.api-onepiece.com/v2/crews/en");

        if (respuesta.IsSuccessStatusCode)
        {
            var tripulaciones = await respuesta.Content.ReadFromJsonAsync<List<Tripulacion>>();

            return tripulaciones ?? new List<Tripulacion>();
        }

        return null;
    }
}