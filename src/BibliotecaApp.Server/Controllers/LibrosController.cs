using Microsoft.AspNetCore.Mvc;
using BibliotecaApp.Shared.Entities;
using BibliotecaApp.Server.Services;
using BibliotecaApp.Shared.DTOs;

namespace BibliotecaApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDTO>>> GetLibros()
        {
            var libros = await _libroService.GetAllLibrosAsync();
            var librosDTO = libros.Select(libro => new LibroDTO
            {
                Id = libro.Id,
                Nombre = libro.Nombre,
                AutorId = libro.AutorId,
                AutorNombre = libro.Autor?.Nombre ?? string.Empty,
                CantidadEjemplares = libro.CantidadEjemplares,
                DisponibleParaPrestamo = libro.DisponibleParaPrestamo
            });

            return Ok(librosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return libro;
        }

        [HttpPost]
        public async Task<ActionResult<Libro>> CreateLibro(Libro libro)
        {
            var createdLibro = await _libroService.CreateLibroAsync(libro);
            return CreatedAtAction(nameof(GetLibro), new { id = createdLibro.Id }, createdLibro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibro(int id, Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            await _libroService.UpdateLibroAsync(libro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            await _libroService.DeleteLibroAsync(id);
            return NoContent();
        }
    }
} 