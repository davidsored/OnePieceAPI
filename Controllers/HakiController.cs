using OnePieceAPI.Models;
using OnePieceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnePieceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HakiController : ControllerBase
{
    private readonly IHakiService _hakiService;

    public HakiController(IHakiService hakiService)
    {
        _hakiService = hakiService;
    }

    [HttpGet("{identificador}")]
    public async Task<IActionResult> GetHaki(string identificador)
    {
        var haki = await _hakiService.ObtenerHakiAsync(identificador);

        if(haki == null)
        {
            return NotFound();
        }
        return Ok(haki);
    }

    [HttpGet("multiple/{identificador}")]
    public async Task<IActionResult> GetVarias(string identificador)
    {
        string[] arrayIds = identificador.Split(',');
        var listaHakis = new List<Haki>();

        foreach(var id in arrayIds)
        {
            var haki = await _hakiService.ObtenerHakiAsync(id.Trim());
            if(haki != null)
            {
                listaHakis.Add(haki);
            }
        }

        if(listaHakis.Count == 0)
        {
            return NotFound("No se encontró ningún haki.");
        }

        return Ok(listaHakis);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodas()
    {
        var hakis = await _hakiService.ObtenerTodosLosHakisAsync();

        if(hakis == null || hakis.Count == 0)
        {
            return NotFound("No se encontraron hakis.");
        }

        return Ok(hakis);
        
    }
}