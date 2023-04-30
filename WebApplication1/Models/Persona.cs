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
        [Required(ErrorMessage = "El campo nombre no puede estar vacio")]
        [StringLength(100)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo Apellido no puede estar vacio")]
        [StringLength(100)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo Matricula no puede estar vacio")]
        [MaxLength(10, ErrorMessage = "La matricula no puede ser mayor a 10 Caracteres")]
        [MinLength(10, ErrorMessage = "La matricula no puede ser menor de 10 Caracteres")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Solo se admiten letras y numeros")]

        public string Matricula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal UbicacionLatitud { get; set; }
        public decimal UbicacionLongitud { get; set; }
        public decimal UbicacionAltitud { get; set; }
    }
}