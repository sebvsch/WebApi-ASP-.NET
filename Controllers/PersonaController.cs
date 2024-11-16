
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.DTOs;
using WebApi.Models.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly WebApiContext _context;

        public PersonaController(WebApiContext context)
        {
            _context = context;
        }

        [Route("obtenerPersonas")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
        {
            return await _context.Personas.ToListAsync();
        }

        [Route("obtenerPersonaById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Persona>> GetPersonaById(int id)
        {
            var persona = await _context.Personas.FirstOrDefaultAsync(x => x.id == id);

            if (persona == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { exito = false, mensaje = "La persona no fue encontrada" });
            }
            return Ok(persona);

        }

        [Route("ingresarPersonaNueva")]
        [HttpPost]

        public async Task<ActionResult<Persona>> PostPersona(PersonaInsert personaInsert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persona = new Persona
            {
                nombre = personaInsert.nombre,
                apellido = personaInsert.apellido,
                edad = personaInsert.edad
            };

            _context.Personas.Add(persona);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersona), new { id = persona.id }, persona);
        }

        [Route("eliminarPersona/{id}")]
        [HttpDelete]
        public async Task<ActionResult<Persona>> DelatePersona(int id)
        {
            var personasExistentes = _context.Personas.Find(id);
            if (personasExistentes is null)
                return NotFound();

            _context.Personas.Remove(personasExistentes);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [Route("editarPersona/{id}")]
        [HttpPut]
        public async Task<ActionResult<Persona>> PutUsuarios(int id, PersonaEditDTO personaEditDto)
        {
            if (id <= 0 || personaEditDto == null)
                return StatusCode(StatusCodes.Status400BadRequest, new { exito = false, mensaje = "Los datos no fueron completados" });

            var personaExistente = await _context.Personas.FindAsync(id);
            if (personaExistente == null)
                return StatusCode(StatusCodes.Status404NotFound, new { exito = false, mensaje = "La persona no fue encontrado" });

            personaExistente.nombre = personaEditDto.nombre;
            personaExistente.apellido = personaEditDto.apellido;
            personaExistente.edad = personaEditDto.edad;

            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new { exito = true, mensaje = "Persona editado correctamente" });

        }
    }
}


