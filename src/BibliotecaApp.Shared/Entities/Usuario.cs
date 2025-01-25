namespace BibliotecaApp.Shared.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string LugarResidencia { get; set; } = string.Empty;
        public bool PuedePrestarLibros { get; set; }
    }
} 