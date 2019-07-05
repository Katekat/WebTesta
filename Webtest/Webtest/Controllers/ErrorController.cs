using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webtest.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult SinAutorizacion(string accion, string modulo, string msjError)
        {
            ViewBag.accion = accion;
            ViewBag.modulo = modulo;
            ViewBag.msjError = msjError;

            return View();
        }
    }
}