namespace BibliotecaApp.Shared.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int AutorId { get; set; }
        public string AutorNombre { get; set; } = string.Empty;
        public int CantidadEjemplares { get; set; }
        public bool DisponibleParaPrestamo { get; set; }
    }
}
