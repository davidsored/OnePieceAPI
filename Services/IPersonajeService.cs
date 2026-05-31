using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public interface IPersonajeService
{
    Task<Personaje?> ObtenerPersonajeAsync(string identificador);
    Task<List<Personaje?>> ObtenerTodosLosPersonajesAsync();
}