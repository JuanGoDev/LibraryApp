namespace BibliotecaApp.Server.Services
{
    using BibliotecaApp.Shared.Entities;

    public interface ILibroService
    {
        Task<IEnumerable<Libro>> GetAllLibrosAsync();
        Task<Libro?> GetLibroByIdAsync(int id);
        Task<Libro> CreateLibroAsync(Libro libro);
        Task UpdateLibroAsync(Libro libro);
        Task DeleteLibroAsync(int id);
    }
}