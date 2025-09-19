namespace Backend.Entities
{
    public class Carrera
    {
        // 
        public int IdCarrera { get; set; }
        public string Nombre { get; set; } = string.Empty;
        

        public required ICollection<Estudiante> Estudiantes{ get; set; }
    }
}