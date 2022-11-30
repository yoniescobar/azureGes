using EvalTIC.Datos;
using Microsoft.AspNetCore.Mvc;

namespace EvalTIC.Controllers
{
    public class SesionController : Controller
    {
        public readonly ApplicationDbContext _contexto; //instanciamos a ContextPropiedades

        //contructor
        public SesionController(ApplicationDbContext contexto) //con eso accedemos a los models bd
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]


        public IActionResult Index(string correo, string contrasenia)
        {
            if (_contexto.Usuario.FirstOrDefault(x => x.Correo == correo && x.Contrasenia == contrasenia) != null)
            {

                return RedirectToAction("Index","Usuarios");

            }
            else
            {
                ViewData["MensajeError"] = "Contraseña o correo incorrecto verifique!!";
            }



            return View(); //si hay problemas con modelo o no es validoreturn View();
        }
    }
}
