namespace BibliotecaApp.Server.Services
{
    using BibliotecaApp.Shared.Entities;

    public interface IAutorService
    {
        Task<IEnumerable<Autor>> GetAllAutoresAsync();
        Task<Autor?> GetAutorByIdAsync(int id);
        Task<Autor> CreateAutorAsync(Autor autor);
        Task UpdateAutorAsync(Autor autor);
        Task DeleteAutorAsync(int id);
    }
}