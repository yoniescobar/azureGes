using EvalTIC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvalTIC.ViewModels
{
    public class RolesUsuariosVM
    {
        public Usuario Usuario { get; set; } //instancias objeto Usuario
        public IEnumerable<SelectListItem> ListaUsuarios { get; set; }

    }


   
}