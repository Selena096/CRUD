namespace Backend.DTOs  //los dtos son clases simples que se usan para enviar o recibir datos entre capas, con el fin de que se envie de forma segura , limpia y eficiente
{
    public class CarreraDTO
    {
        public int IdCarrera { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}