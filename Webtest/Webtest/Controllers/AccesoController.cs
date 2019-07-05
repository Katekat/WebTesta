using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAD;

namespace Webtest.Controllers
{
    public class AccesoController : Controller
    {

        private UsuariosAD objUser;

        public AccesoController() {
            objUser = new UsuariosAD();
        }

        // GET: Acceso
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            
            var model = objUser.autenticar(User, Pass);
            if (model == null)
            {
                ViewBag.Error = "Usuario o contraseña inválida";
                return View();
            }
            else
            {
                Session["User"] = model;
                ViewBag.idRol = model.IdRol;
                if (model.IdRol == 1)
                {
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }
                
            }
            
               
              
            
 

        }


    }
}