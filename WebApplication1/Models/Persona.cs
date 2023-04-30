using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(10)]
        public string Matricula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal UbicacionLatitud { get; set; }
        public decimal UbicacionLongitud { get; set; }
        public decimal UbicacionAltitud { get; set; }
    }
}