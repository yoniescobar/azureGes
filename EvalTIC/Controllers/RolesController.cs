using EvalTIC.Datos;
using EvalTIC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EvalTIC.Controllers
{
    public class RolesController : Controller
    {
        public readonly ApplicationDbContext _contexto; //instanciamos a ContextPropiedades

        //contructor
        public RolesController(ApplicationDbContext contexto) //con eso accedemos a los models bd
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            List<Rol> listaRoles = _contexto.Rol.ToList(); //ahi carga todos los Roles
            return View(listaRoles);
        }

        //metodo mostrar Formulario
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        //metodo mostrar Formulario Envia los datos por Post
        [HttpPost]
        [ValidateAntiForgeryToken] //validacion datos
        public IActionResult Crear(Rol Rol)
        {
            if (ModelState.IsValid)
            {
                _contexto.Rol.Add(Rol);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(); //si hay problemas con modelo o no es valido
        }



        ////metodo mostrar Formulario Multiple formulario para 5 --prueba
        //[HttpGet]
        //public IActionResult CrearRolesMasivo()
        //{

        //    List<Rol> listaRoles = new List<Rol>();

        //    for (int i = 0; i < 5; i++)
        //    {
        //        listaRoles.Add(new Rol { Descripcion = Guid.NewGuid().ToString() });
        //        // _contexto.Rol.Add(new Rol { Descripcion = Guid.NewGuid().ToString() });
        //    }
        //    _contexto.Rol.AddRange(listaRoles);
        //    _contexto.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        //VistaRolesMasivoForm
        [HttpGet]
        public  IActionResult VistaRolesMasivoForm()
        {
            return View();
        }
        //CrearMultipleOpcionFormulario 
        [HttpPost]
        [ValidateAntiForgeryToken] //validacion datos
        public IActionResult CrearMultipleOpcionFormulario()
        {
            string RolesForms = Request.Form["Descripcion"];   //slipt para cojer todas las categoria
            var lstRoles = from val in RolesForms.Split(new[]{","},StringSplitOptions.RemoveEmptyEntries) select (val);

            List<Rol> Roladd = new List<Rol>();

            foreach (string Rol in lstRoles)
            {
                Roladd.Add(new Rol { Descripcion = Rol });
            }
            _contexto.Rol.AddRange(Roladd);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //forms para editar
        [HttpGet]
        public IActionResult Editar(int? id) //si inteta enviar un null
        {
            if (id==null)
            {
                return View();
            }
            var Rol = _contexto.Rol.FirstOrDefault(x => x.RolId == id); //comparar ids
            return View(Rol);
        }

        //ditar por post
        [HttpPost]
        [ValidateAntiForgeryToken] //validacion datos proteger app
        public IActionResult Editar(Rol Rol)
        {
            if(ModelState.IsValid) //validar modelos logitud min, requerido  de lo data anotations
            {
                _contexto.Rol.Update(Rol);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index)); //retorna al index
            }
            return View(Rol); //vista

        }

        //Eliminar Registro
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var rolRemove = _contexto.Rol.FirstOrDefault(r =>r.RolId==id);
            _contexto.Rol.Remove(rolRemove);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index)); //retorna al index
        }

 

    }
}
