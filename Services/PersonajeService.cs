using System.Net.Http.Json;
using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public class PersonajeService : IPersonajeService
{
    private readonly HttpClient _httpclient;

    public PersonajeService(HttpClient httpclient)
    {
        _httpclient = httpclient;
    }

    public async Task<Personaje?> ObtenerPersonajeAsync(string identificador)
    {
        var respuesta = await _httpclient.GetAsync($"https://api.api-onepiece.com/v2/characters/en/{identificador.ToLower()}");

        if (respuesta.IsSuccessStatusCode)
        {
            return await respuesta.Content.ReadFromJsonAsync<Personaje>();
        }

        return null;
    }

    public async Task<List<Personaje>> ObtenerTodosLosPersonajesAsync()
    {
        var respuesta = await _httpclient.GetAsync("https://api.api-onepiece.com/v2/characters/en");

        if (respuesta.IsSuccessStatusCode)
        {
            var personajes = await respuesta.Content.ReadFromJsonAsync<List<Personaje>>();

            return personajes ?? new List<Personaje>();
        }

        return new List<Personaje>();
    }
}