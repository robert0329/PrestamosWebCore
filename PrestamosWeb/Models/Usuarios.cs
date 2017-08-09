using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosWeb.Models
{
    public class Usuarios
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Primer Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es Requerido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Email es Requerido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Usuario es Requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Password es requerido")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
       
        public int Tipo { get; set; }
    }
}
