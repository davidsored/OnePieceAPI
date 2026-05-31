using OnePieceAPI.Models;
using OnePieceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnePieceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarcoController : ControllerBase
{
    private readonly IBarcoService _barcoService;

    public BarcoController(IBarcoService barcoService)
    {
        _barcoService = barcoService;
    }

    [HttpGet("{identificador}")]
    public async Task<IActionResult> GetBarco(string identificador)
    {
        var barco = await _barcoService.ObtenerBarcoAsync(identificador);

        if(barco == null)
        {
            return NotFound();
        }

        return Ok(barco);
    }

    [HttpGet("multiple/{identificador}")]
    public async Task<IActionResult> GetVarios(string identificador)
    {
        string[] arrayIds = identificador.Split(',');
        var listaBarcos = new List<Barco>();

        foreach(var id in arrayIds)
        {
            var barco = await _barcoService.ObtenerBarcoAsync(id.Trim());
            if(barco != null)
            {
                listaBarcos.Add(barco);
            }
        }

        if(listaBarcos.Count == 0)
        {
            return NotFound("No se encontró ningún barco.");
        }

        return Ok(listaBarcos);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var barcos = await _barcoService.ObtenerTodosLosBarcosAsync();

        if(barcos == null || barcos.Count == 0)
        {
            return NotFound("No se encontraron barcos.");
        }

        return Ok(barcos);
    }
}