namespace Backend.Entities
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
       
        // RELACIÓN CADA ESTUDIANTE TIENE UN PERFIL
        public int IdCarrera { get; set; }     
        public Carrera Carrera { get; set; } = null!; 

    }
}