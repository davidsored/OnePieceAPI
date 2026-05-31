using OnePieceAPI.Models;
using OnePieceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnePieceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FrutaController : ControllerBase
{
    private readonly IFrutaService _frutaService;

    public FrutaController(IFrutaService frutaService)
    {
        _frutaService = frutaService;
    }

    [HttpGet("{identificador}")]
    public async Task<IActionResult> GetFruta(string identificador)
    {
        var fruta = await _frutaService.ObtenerFrutaAsync(identificador);

        if(fruta == null)
        {
            return NotFound();
        }

        return Ok(fruta);

    }

    [HttpGet("multiple/{identificador}")]
    public async Task<IActionResult> GetVarios(string identificador)
    {
        string[] arrayIds = identificador.Split(',');
        var listaFrutas = new List<Fruta>();

        foreach(var id in arrayIds)
        {
            var fruta = await _frutaService.ObtenerFrutaAsync(id.Trim());
            if(fruta != null)
            {
                listaFrutas.Add(fruta);
            }
        }

        if(listaFrutas.Count == 0)
        {
            return NotFound("No se encontró ninguna fruta.");
        }

        return Ok(listaFrutas);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var frutas = await _frutaService.ObtenerTodasLasFrutasAsync();

        if(frutas == null || frutas.Count == 0)
        {
            return NotFound("No se encontraron frutas.");
        }

        return Ok(frutas);
        
    }
}