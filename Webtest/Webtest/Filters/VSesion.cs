using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaModelo;
using Webtest.Controllers;

namespace Webtest.Filters
{
    public class VSesion:ActionFilterAttribute
    {
        private cUsuario seUser;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                seUser = (cUsuario)HttpContext.Current.Session["User"];
                if (seUser==null)
                {
                    if (filterContext.Controller is AccesoController ==false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}