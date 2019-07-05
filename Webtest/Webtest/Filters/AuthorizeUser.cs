using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAD;
using CapaModelo;

namespace Webtest.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private cUsuario objUser;
        private AccesoAD AccModulo = new AccesoAD();
        private int idOperacion;
        string nombreAccion = "";
        string nombreModulo = "";

        //
        public AuthorizeUser(int idOperacion = 0) {
            this.idOperacion = idOperacion;
        }

        /// <summary>
        /// Filtros para la actorizacion
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            objUser = (cUsuario)HttpContext.Current.Session["Usuario"];
            var ListAcciones = AccModulo.ObtenerAcceso();
            var lstAcciones = from m in ListAcciones
                              where m.idRol == objUser.idRol
                              && m.idOperacion == idOperacion
                              select m;
            

            if (ListAcciones.ToList().Count==0)
            {
                var obAcciones = AccModulo.ObtenerOperacion(idOperacion);
                int idModulo = obAcciones.IdModulo;
                nombreAccion = obAcciones.Nombre;
                var Modulo= AccModulo.ObtenerModulo(idModulo);
                nombreModulo = Modulo.Nombre;
                filterContext.Result = new RedirectResult("~/Error/SinAutorizacion?opracion=" + nombreAccion);


            }
        }



    }
}