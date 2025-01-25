namespace BibliotecaApp.Shared.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
        public int CantidadEjemplares { get; set; }
        public bool DisponibleParaPrestamo { get; set; }
    }
} 