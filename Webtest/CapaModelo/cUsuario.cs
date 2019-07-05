using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cUsuario
    {
        public int id;

        public string nombre;

        public string email;

        public string password;

        public int idRol;

        public int estatus;

       
        public int Id { get => id; set => id = value; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe poseer al menos 3 caracteres.")]
        public string Nombre { get => nombre; set => nombre = value; }
        [DisplayName("Correo")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Email { get => email; set => email = value; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe poseer al menos 8 caracteres.")]
        public string Password { get => password; set => password = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public int Estatus { get => estatus; set => estatus = value; }
    }
}
