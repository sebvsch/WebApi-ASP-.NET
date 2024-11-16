
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Models
{
    public class PersonaInsert
    {
        [StringLength(100)]
        public required string nombre { get; set; } = string.Empty;
        [StringLength(100)]
        public required string apellido { get; set; } = string.Empty;
        public required int edad { get; set; }
    }
}