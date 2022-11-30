using System.ComponentModel.DataAnnotations;

namespace EvalTIC.Models
{
    public class Rol
    {
        public int RolId { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public List<Usuario> Usuario { get; set; } //Table Padre
    }
}
