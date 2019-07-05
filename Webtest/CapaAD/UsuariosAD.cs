using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAD
{
    public class UsuariosAD
    {
        private SqlCommand cmdComando;

        public void create(cUsuario obj)
        {
            try
            {
                SqlConnection cnnConexion = Conexion.ObtenerConexion();
               
                string query = "insert into alumno Values ( '{0}', '{1}', '{2}', {3}, {4})";
                query = string.Format(query, obj.Nombre, obj.Email, obj.Password, 1, 1); // no dio chance de implementar las cargas de los combobox 

                cmdComando = new SqlCommand(query, cnnConexion);

                cmdComando.ExecuteNonQuery();
                cnnConexion.Close();
               
            }
            catch (Exception e)
            {
               
            }

        }

        public List<cUsuario> findAll()
        {
            SqlConnection cnnConexion = Conexion.ObtenerConexion();
            List<cUsuario> lst = new List<cUsuario>();
            try
            {
                string query = "select * from Users";
                query = string.Format(query);
                cmdComando = new SqlCommand(query, cnnConexion);
                SqlDataReader read = cmdComando.ExecuteReader();
                while (read.Read())
                {

                    cUsuario obj = new cUsuario();
                    obj.Id = Convert.ToInt16(read[0].ToString());
                    obj.Nombre = read[1].ToString();
                    obj.Email = read[2].ToString();
                    obj.Password = read[3].ToString();
                    obj.IdRol = Convert.ToInt16(read[4].ToString());
                    obj.Estatus= Convert.ToInt16(read[5].ToString());
                    lst.Add(obj);
                }

                return lst;

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                // cmdComando.ExecuteNonQuery();
                cnnConexion.Close();

            }

        }

        public cUsuario Find(int id)
        {
            bool registers;
            SqlConnection cnnConexion = Conexion.ObtenerConexion();
            cUsuario obj = new cUsuario();

            try
            {
                string query = "select * from Users where id={0} ";
                query = string.Format(query, id);
                cmdComando = new SqlCommand(query, cnnConexion);
                SqlDataReader read = cmdComando.ExecuteReader();
                registers = read.Read();
                if (registers)
                {
                    obj.Id = Convert.ToInt16(read[0].ToString());
                    obj.Nombre = read[1].ToString();
                    obj.Email = read[2].ToString();
                    obj.Password = read[3].ToString();
                    obj.IdRol = Convert.ToInt16(read[4].ToString());
                    obj.Estatus= Convert.ToInt16(read[5].ToString());

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
        public void update(cUsuario obj)
        {
            SqlConnection cnnConexion = Conexion.ObtenerConexion();

            try
            {
                string query = "update Users set nombre='{1}', email='{2}' , password='{3}', idEstatus={4} where id={0} ";
                query = string.Format(query, obj.Id, obj.Nombre, obj.Email, obj.Password, obj.Estatus);
                cmdComando = new SqlCommand(query, cnnConexion);
                cmdComando.ExecuteNonQuery();

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
        public void delete(int obj)


        {
            SqlConnection cnnConexion = Conexion.ObtenerConexion();

            try
            {
                int Estatus = 2;
                string query = "update Users set idEstatus={1} where id={0} ";
                query = string.Format(query, obj, Estatus);
                cmdComando = new SqlCommand(query, cnnConexion);
                cmdComando.ExecuteNonQuery();
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

        public cUsuario autenticar(string email, string password) {

            SqlConnection cnnConexion = Conexion.ObtenerConexion();
            bool registers;
            cUsuario obj = new cUsuario();
            try
            {
                string query = "select * from Users where email='{0}' and password ='{1}' ";
                query = string.Format(query, email, password);
                cmdComando = new SqlCommand(query, cnnConexion);
                SqlDataReader read = cmdComando.ExecuteReader();
                registers = read.Read();
                if (registers)
                {
                    obj.Id = Convert.ToInt16(read[0].ToString());
                    obj.Nombre = read[1].ToString();
                    obj.Email = read[2].ToString();
                    obj.Password = read[3].ToString();
                    obj.IdRol = Convert.ToInt16(read[4].ToString());
                    return obj;
                }
                else
                {
                    return null;
                }
                


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


        public cUsuario Obtener(int id)
        {
            bool registers;
            SqlConnection cnnConexion = Conexion.ObtenerConexion();
            cUsuario obj = new cUsuario();

            try
            {
                string query = "select * from Users where id={0} ";
                query = string.Format(query, id);
                cmdComando = new SqlCommand(query, cnnConexion);
                SqlDataReader read = cmdComando.ExecuteReader();
                registers = read.Read();
                if (registers)
                {
                    obj.Id = Convert.ToInt16(read[0].ToString());
                    obj.Nombre = read[1].ToString();
                    obj.Email = read[2].ToString();
                    obj.Password = read[3].ToString();
                    obj.idRol= Convert.ToInt16(read[4].ToString());
                    obj.Estatus= Convert.ToInt16(read[5].ToString());
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
