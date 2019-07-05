using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAD
{
    public class Conexion
    {

        public static string obtenercadena()
        {
            return ConfigurationManager.ConnectionStrings["CNTest"].ConnectionString;
        }

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection cnnConexion = new SqlConnection(obtenercadena());
            cnnConexion.Open();
            return cnnConexion;
        }
    }
}
