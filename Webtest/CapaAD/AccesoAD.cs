using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo;

namespace CapaAD
{
    public class AccesoAD
    {

        private SqlCommand cmdComando;

        public List<cAccesoModulo.cRoloperacion> ObtenerAcceso() {

            SqlConnection cnnConexion = Conexion.ObtenerConexion();
            List<cAccesoModulo.cRoloperacion> lstOper = new  List<cAccesoModulo.cRoloperacion> ();
            bool registers;
            try
            {
                string strSentenciaSQL = "SELECT * From Rol_operacion";
                strSentenciaSQL = string.Format(strSentenciaSQL);

                SqlCommand cmdComando = new SqlCommand(strSentenciaSQL, cnnConexion);


                SqlDataReader read = cmdComando.ExecuteReader();
                while (read.Read())
                {

                    cAccesoModulo.cRoloperacion obj = new cAccesoModulo.cRoloperacion();
                    obj.id = Convert.ToInt16(read[0].ToString());
                    obj.idRol = Convert.ToInt16(read[1].ToString());
                    obj.idOperacion = Convert.ToInt16(read[2].ToString());

                    lstOper.Add(obj);

                }
                return lstOper;
            }
            catch (Exception)
            {

                throw;
            }
           
            
        }

        //public DataSet ObtenerAcceso()
        //{

        //    SqlConnection cnnConexion = Conexion.ObtenerConexion();

        //    string strSentenciaSQL = "SELECT Oper.id,Oper.idRol, Oper.idOperacion, FROM Rol_operacion Oper INNER JOIN departamento dep ON disp.coddpto = dep.codigodpto LEFT JOIN revision rev ON disp.codigoControl = rev.codigocontrol WHERE disp.codigoControl = {0} ";
        //    strSentenciaSQL = string.Format(strSentenciaSQL, codigocontrol);

        //    SqlCommand cmdComando = new SqlCommand(strSentenciaSQL, cnnConexion);


        //    SqlDataAdapter adpAdapter = new SqlDataAdapter(cmdComando);

        //    DataSet dsConsulta = new DataSet();

        //    adpAdapter.Fill(dsConsulta, "consulta");

        //    cnnConexion.Close();

        //    return dsConsulta;
        //}

        public cAccesoModulo.cOperacion ObtenerOperacion(int id) {

            bool registers;
            SqlConnection cnnConexion = Conexion.ObtenerConexion();
            cAccesoModulo.cOperacion obj = new cAccesoModulo.cOperacion();

            try
            {
                string query = "select * from Operaciones where id={0} ";
                query = string.Format(query, id);
                cmdComando = new SqlCommand(query, cnnConexion);
                SqlDataReader read = cmdComando.ExecuteReader();
                registers = read.Read();
                if (registers)
                {
                    obj.Id = Convert.ToInt16(read[0].ToString());
                    obj.Nombre = read[1].ToString();
                    obj.IdModulo = Convert.ToInt16(read[3].ToString());
               
                }
                return obj;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

                cnnConexion.Close();

            }


          

        }

        public cAccesoModulo ObtenerModulo(int id)
        {

            bool registers;
            SqlConnection cnnConexion = Conexion.ObtenerConexion();
            cAccesoModulo obj = new cAccesoModulo();

            try
            {
                string query = "select * from modulo where id={0} ";
                query = string.Format(query, id);
                cmdComando = new SqlCommand(query, cnnConexion);
                SqlDataReader read = cmdComando.ExecuteReader();
                registers = read.Read();
                if (registers)
                {
                    obj.Id = Convert.ToInt16(read[0].ToString());
                    obj.Nombre = read[1].ToString();
                    

                }
                return obj;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

                cnnConexion.Close();

            }




        }
    }
}
