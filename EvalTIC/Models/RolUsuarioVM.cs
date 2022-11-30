using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvalTIC.Models
{
    public class RolUsuarioVM
    {
        public Rol Rol { get; set; }
        public IEnumerable<SelectListItem> ListaUsuarios { get; set; }

    }
}
