using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webtest.Filters;
using CapaModelo;
using CapaAD;
using Webtest.Filters;

namespace Webtest.Controllers
{
    public class UsersController : Controller
    {

        private UsuariosAD objUser;

       
        public UsersController()
        {
            objUser = new UsuariosAD();
        }
        // GET: Users
        [AuthorizeUser(idOperacion: 1)]
        public ActionResult Index()
        {
            List<cUsuario> lstuser = objUser.findAll();

            return View(lstuser);
        }
        [AuthorizeUser(idOperacion: 1)]
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [AuthorizeUser(idOperacion: 1)]
        [HttpPost]
        public ActionResult Create(cUsuario obj)
        {
            objUser.create(obj);
            return RedirectToAction("Index");
        }

        [AuthorizeUser(idOperacion: 1)]
        [HttpGet]
        public ActionResult Update(int id)
        {

            var model = objUser.Obtener(id);
            return View(model);
        }
        [AuthorizeUser(idOperacion: 1)]
        [HttpPost]
        public ActionResult Update(cUsuario obj)
        {

            objUser.update(obj);

            return RedirectToAction("Index");
        }
        [AuthorizeUser(idOperacion: 1)]
        [HttpGet]
        public ActionResult Delete(int id)
        {

            var model = objUser.Obtener(id);
            return View(model);
        }
        [AuthorizeUser(idOperacion: 1)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            objUser.delete(id);
            return RedirectToAction("Index");
        }

    }
}