using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Infrastructure.Data;
using BibliotecaApp.Shared.Entities;

namespace BibliotecaApp.Server.Services
{
    public class LibroService : ILibroService
    {
        private readonly BibliotecaDbContext _context;

        public LibroService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Libro>> GetAllLibrosAsync()
        {
            return await _context.Libros
                .Include(l => l.Autor)
                .ToListAsync();
        }

        public async Task<Libro?> GetLibroByIdAsync(int id)
        {
            return await _context.Libros
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Libro> CreateLibroAsync(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task UpdateLibroAsync(Libro libro)
        {
            _context.Entry(libro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLibroAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }
    }
} 