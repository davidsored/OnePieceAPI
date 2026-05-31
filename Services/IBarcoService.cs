using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public interface IBarcoService
{
    Task<Barco?> ObtenerBarcoAsync(string identificador);
    Task<List<Barco>> ObtenerTodosLosBarcosAsync();
}