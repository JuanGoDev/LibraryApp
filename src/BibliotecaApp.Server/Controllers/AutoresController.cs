namespace BibliotecaApp.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using BibliotecaApp.Server.Services;
    using BibliotecaApp.Shared.Entities;
    using BibliotecaApp.Shared.DTOs;

    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAutores()
        {
            var autores = await _autorService.GetAllAutoresAsync();
            var autoresDTO = autores.Select(autor => new AutorDTO
            {
                Nombre = autor.Nombre,
                PaisNacimiento = autor.PaisNacimiento,
                CantidadLibros = autor.Libros.Count
            });

            return Ok(autoresDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _autorService.GetAutorByIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public async Task<ActionResult<Autor>> CreateAutor(Autor autor)
        {
            var createdAutor = await _autorService.CreateAutorAsync(autor);
            return CreatedAtAction(nameof(GetAutor), new { id = createdAutor.Id }, createdAutor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutor(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            await _autorService.UpdateAutorAsync(autor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            await _autorService.DeleteAutorAsync(id);
            return NoContent();
        }
    }
} 