using OnePieceAPI.Models;

namespace OnePieceAPI.Services;

public interface ITripulacionService
{
    Task<Tripulacion?> ObtenerTripulacionAsync(string identificador);
    Task<List<Tripulacion?>> ObtenerTodasLasTripulacionesAsync();
} 