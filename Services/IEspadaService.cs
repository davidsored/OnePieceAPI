using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public interface IEspadaService
{
    Task<Espada?> ObtenerEspadaAsync(string identificador);
    Task<List<Espada>> ObtenerTodasLasEspadasAsync();
}