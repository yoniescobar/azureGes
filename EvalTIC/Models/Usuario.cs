using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvalTIC.Models
{   [Index(nameof(Correo),IsUnique =true)]
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El Nombres es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellidos es Obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Telefono es Obligatorio")]
        [MaxLength(8)]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        [Required(ErrorMessage = "El correo es Obligatorio")]
      //  [RegularExpression(@" ^[_A - Za - z0 - 9 -\\+] + (\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Por favor Ingrese un Correo válido")]
         public string Correo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }

        public int Activo { get; set; }
        [Required(ErrorMessage = "El Password es Obligatorio")]
        public String Contrasenia { get; set; }

        //relaciones
        [ForeignKey("Rol")]
        public int RolId{ get; set; }
        public Rol Rol { get; set; } //relacion de Rol a Usuario

       


    }

    
}
