namespace WebApi.Models
{
    public class Persona
    {
        public int id { get; set; }
        public required string nombre { get; set; } = string.Empty;
        public required string apellido { get; set; } = string.Empty;
        public required int edad { get; set; }
    }
}