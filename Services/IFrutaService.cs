using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public interface IFrutaService
{
    Task<Fruta?> ObtenerFrutaAsync(string identificador);
    Task<List<Fruta?>> ObtenerTodasLasFrutasAsync();
}