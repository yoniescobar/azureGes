using EvalTIC.Datos;
using EvalTIC.Models;
using EvalTIC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvalTIC.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly ApplicationDbContext _contexto; //instanciamos a ContextPropiedades

        //contructor
        public UsuariosController(ApplicationDbContext contexto) //con eso accedemos a los models bd
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            List<Usuario> listaUsuarios = _contexto.Usuario.ToList(); //ahi carga todos los Roles

            List<Usuario> lstUsuarios = new List<Usuario>();

            foreach (Usuario item in listaUsuarios)
            {
                Rol rol = _contexto.Rol.FirstOrDefault(x => x.RolId == item.RolId); //traemos el rol del primer usuario
                item.Rol = rol;
                lstUsuarios.Add(item); //cargamos los roles
            }


            return View(lstUsuarios);
        }

        //metodo mostrar Formulario
        [HttpGet]
        public IActionResult Crear()
        {
            RolesUsuariosVM rolesUsuarios = new RolesUsuariosVM();
            rolesUsuarios.ListaUsuarios = _contexto.Rol.Select(i => new SelectListItem
            {
                Text = i.Descripcion,
                Value = i.RolId.ToString()
            });

            return View(rolesUsuarios);
        }

        //metodo mostrar Formulario Envia los datos por Post
        [HttpPost]
        [ValidateAntiForgeryToken] //validacion datos
        public IActionResult Crear(Usuario usuario)
        {
            // rolUsuarios.Usuario = _contexto.Usuario.FirstOrDefault(u => u.UsuarioId == id);
            if (ModelState.IsValid)
            {
                if( _contexto.Usuario.FirstOrDefault(x => x.Correo == usuario.Correo) == null)
                {
                    _contexto.Usuario.Add(usuario);
                    _contexto.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewData["MensajeError"] = "Correo ya esta en uso!!";
                }
   
            }
            RolesUsuariosVM rolUsuarios = new RolesUsuariosVM();
            rolUsuarios.ListaUsuarios = _contexto.Rol.Select(i => new SelectListItem
            {
                Text = i.Descripcion,
                Value = i.RolId.ToString()
            });
            return View(rolUsuarios); //si hay problemas con modelo o no es valido
        }

        //forms para editar
        [HttpGet]
        public IActionResult Editar(int? id) //si inteta enviar un null
        {
            if (id == null)
            {
                return View();
            }


            RolesUsuariosVM rolUsuarios = new RolesUsuariosVM();
            rolUsuarios.ListaUsuarios = _contexto.Rol.Select(i => new SelectListItem
            {
                Text = i.Descripcion,
                Value = i.RolId.ToString()
            });

            rolUsuarios.Usuario = _contexto.Usuario.FirstOrDefault(u => u.UsuarioId == id);

            if (rolUsuarios == null)
            {
                return NotFound();
            }

            return View(rolUsuarios);
        }


        //metodo mostrar Formulario Envia los datos por Post
        [HttpPost]
        [ValidateAntiForgeryToken] //validacion datos
        public IActionResult Editar(RolesUsuariosVM usuarioVM)
        {
            if (usuarioVM.Usuario.UsuarioId == 0)
            {
                return View(usuarioVM.Usuario);

            }
            else
            {
                _contexto.Usuario.Update(usuarioVM.Usuario);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //Eliminar Registro
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var Usuario = _contexto.Usuario.FirstOrDefault(r => r.UsuarioId == id);
            _contexto.Usuario.Remove(Usuario);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index)); //retorna al index
        }



    }
}
