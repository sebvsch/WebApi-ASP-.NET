using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.DTOs
{
    public class PersonaEditDTO
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
    }
}