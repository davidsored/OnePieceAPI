using OnePieceAPI.Models;
using OnePieceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnePieceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EspadaController : ControllerBase
{
    private readonly IEspadaService _espadaService;

    public EspadaController(IEspadaService espadaService)
    {
        _espadaService = espadaService;
    }

    [HttpGet("{identificador}")]
    public async Task<IActionResult> GetEspada(string identificador)
    {
        var espada = await _espadaService.ObtenerEspadaAsync(identificador);

        if(espada == null)
        {
            return NotFound();
        }

        return Ok(espada);
    }

    [HttpGet("multiple/{identificador}")]
    public async Task<IActionResult> GetVarios(string identificador)
    {
        string[] arrayIds = identificador.Split(',');
        var listaEspadas = new List<Espada>();

        foreach(var id in arrayIds)
        {
             var espada = await _espadaService.ObtenerEspadaAsync(id.Trim());
             if(espada != null)
             {
                 listaEspadas.Add(espada);
             }
        }

        if (listaEspadas.Count == 0)
        {
            return NotFound("No se encontró ninguna de las espadas.");
        }

        return Ok(listaEspadas);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var espadas = await _espadaService.ObtenerTodasLasEspadasAsync();

        if (espadas == null || espadas.Count == 0)
        {
            return NotFound("No se encontraron espadas.");
        }

        return Ok(espadas);
    }
}       