using OnePieceAPI.Models;
using OnePieceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnePieceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripulacionController : ControllerBase
{
    private readonly ITripulacionService _tripulacionService;

    public TripulacionController(ITripulacionService tripulacionService)
    {
        _tripulacionService = tripulacionService;
    }

    [HttpGet("{identificador}")]
    public async Task<IActionResult> GetTripulacion(string identificador)
    {
        var tripulacion = await _tripulacionService.ObtenerTripulacionAsync(identificador);

        if(tripulacion == null)
        {
            return NotFound();
        }
        
        return Ok(tripulacion);
    }

    [HttpGet("multiple/{identificador}")]
    public async Task<IActionResult> GetVarias(string identificador)
    {
        string[] arrayIds = identificador.Split(',');
        var listaTripulaciones = new List<Tripulacion>();

        foreach(var id in arrayIds)
        {
            var tripulacion = await _tripulacionService.ObtenerTripulacionAsync(id.Trim());
            if(tripulacion != null)
            {
                listaTripulaciones.Add(tripulacion);
            }
        }

        if (listaTripulaciones.Count == 0)
        {
            return NotFound("No se encontró ninguna tripulación.");
        }

        return Ok(listaTripulaciones);
        
    }

    [HttpGet]
    public async Task<IActionResult> GetTodas()
    {
        var tripulaciones = await _tripulacionService.ObtenerTodasLasTripulacionesAsync();

        if(tripulaciones == null || tripulaciones.Count == 0)
        {
            return NotFound();
        }

        return Ok(tripulaciones);
        
    }
}