using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Infrastructure.Data;
using BibliotecaApp.Shared.Entities;

namespace BibliotecaApp.Server.Services
{
    public class AutorService : IAutorService
    {
        private readonly BibliotecaDbContext _context;

        public AutorService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> GetAllAutoresAsync()
        {
            return await _context.Autores
                .Include(a => a.Libros)
                .ToListAsync();
        }

        public async Task<Autor?> GetAutorByIdAsync(int id)
        {
            return await _context.Autores
                .Include(a => a.Libros)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Autor> CreateAutorAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task UpdateAutorAsync(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutorAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }
    }
} 