using OnePieceAPI.Models;
using OnePieceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnePieceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonajeController : ControllerBase
{
    private readonly IPersonajeService _personajeService;

    public PersonajeController(IPersonajeService personajeService)
    {
        _personajeService = personajeService;
    }

    [HttpGet("{identificador}")]
    public async Task<IActionResult> GetPersonaje(string identificador)
    {
        var respuesta = await _personajeService.ObtenerPersonajeAsync(identificador);

        if(respuesta == null)
        {
            return NotFound();
        }      
                
        return Ok(respuesta);
    }

    [HttpGet("multiple/{identificador}")]
    public async Task<IActionResult> GetVarios(string identificador)
    {
        string[] arrayIds = identificador.Split(',');
        var listaPersonajes = new List<Personaje>();

        foreach(var id in arrayIds)
        {
            var personaje = await _personajeService.ObtenerPersonajeAsync(id.Trim());
            if(personaje != null)
            {
                listaPersonajes.Add(personaje);
            }
        }

        if (listaPersonajes.Count == 0)
        {
            return NotFound("No se encontró ningún personaje.");
        }

        return Ok(listaPersonajes);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var personajes = await _personajeService.ObtenerTodosLosPersonajesAsync();

        if (personajes == null || personajes.Count == 0)
        {
            return NotFound("No se encontraron personajes.");
        }

        return Ok(personajes);
    }
}