using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public interface IHakiService
{
    Task<Haki?> ObtenerHakiAsync(string identificador);
    Task<List<Haki?>> ObtenerTodosLosHakisAsync();
}