namespace Backend.DTOs
{
    public class EstudianteDTO
    {
        public int IdEstudiante { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; } = string.Empty; // ← ¡Nombre de la carrera, no toda la entidad!
    }
}