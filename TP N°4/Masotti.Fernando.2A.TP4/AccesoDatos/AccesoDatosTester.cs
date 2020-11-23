using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace AccesoDatos
{
    public class AccesoDatosTester : AccesoDatosBd<Tester>
    {
        /// <summary>
        /// Método para eliminar un registro de la tabla tester según su id
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns>Devuelve true si se pudo eliminar</returns>
        public override bool Eliminar(int id)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("DELETE FROM tester WHERE id = @id", this.conexion);
                this.comando.Parameters.AddWithValue("@id", id);
                this.comando.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw new BaseDeDatosException(new Exception("No se pudo eliminar el registro de la tabla."));
            }
            finally
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Método para agregar un registro a la tabla tester
        /// </summary>
        /// <param name="entidad">Objeto Tester a agregar</param>
        /// <returns>Devuelve true si se pudo agregar</returns>
        public override bool Guardar(Tester entidad)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("INSERT INTO tester (codigo,descripcion,precio,cantidadCuentas,cantidadFunciones)" +
                    " VALUES (@codigo, @descripcion, @precio,@cantidadCuentas,@cantidadFunciones)", this.conexion);
                this.comando.Parameters.AddWithValue("@codigo", entidad.Codigo);
                this.comando.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                this.comando.Parameters.AddWithValue("@precio", entidad.Precio);
                this.comando.Parameters.AddWithValue("@cantidadCuentas", entidad.CantidadCuentas);
                this.comando.Parameters.AddWithValue("@cantidadFunciones", entidad.CantidadFunciones);

                this.comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw new BaseDeDatosException(new Exception("No se pudo agregar el registro a la tabla."));
            }
            finally
            {
                this.conexion.Close();
            }
        }


        /// <summary>
        /// Método para modificar un registro de la tabla tester
        /// </summary>
        /// <param name="entidad">Objeto Tester a modificar</param>
        /// <returns>Devuelve true si se pudo modificar</returns>
        public override bool Modificar(Tester entidad)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("UPDATE tester SET codigo=@codigo, descripcion=@descripcion, precio=@precio, cantidadCuentas=@cantidadCuentas, cantidadFunciones=@cantidadFunciones WHERE id=@id", this.conexion);
                this.comando.Parameters.AddWithValue("@codigo", entidad.Codigo);
                this.comando.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                this.comando.Parameters.AddWithValue("@precio", entidad.Precio);
                this.comando.Parameters.AddWithValue("@cantidadFunciones", entidad.CantidadFunciones);
                this.comando.Parameters.AddWithValue("@cantidadCuentas", entidad.CantidadCuentas);
                this.comando.Parameters.AddWithValue("@id", entidad.Id);
                this.comando.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {
                throw new BaseDeDatosException(new Exception("No se pudo modificar el registro de la tabla."));
            }
            finally
            {
                this.conexion.Close();
            }

        }

        /// <summary>
        /// Método para obtener un registro de la tabla tester según su id
        /// </summary>
        /// <param name="id">id del registro a obtener</param>
        /// <returns>Devuelve un objeto Tester con los valores del registro de la tabla</returns>
        public override Tester ObtenerPorId(int id)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SELECT * FROM tester WHERE id = @id", this.conexion);
                this.comando.Parameters.AddWithValue("@id", id);

                var reader = this.comando.ExecuteReader();

                Tester nuevoTester = null;

                if (reader.Read())
                {
                    nuevoTester= new Tester((int)reader["id"],
                                        (int)reader["codigo"],
                                        (string)reader["descripcion"],
                                        (double)reader["precio"],
                                        (int)reader["cantidadCuentas"],
                                        (int)reader["cantidadFunciones"]);

                }
                return nuevoTester;
            }
            catch (Exception)
            {
                throw new BaseDeDatosException(new Exception("No se pudo obtener el registro de la tabla."));
            }
            finally
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Método para obtener todos los registros de la tabla tester
        /// </summary>
        /// <returns>Devuelve una lista de objetos Tester con los valores de los registros de la tabla</returns>
        public override List<Tester> ObtenerTodos()
        {
            List<Tester> listaTester = new List<Tester>();
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SELECT * FROM tester", this.conexion);
                var reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    Tester tester = new Tester((int)reader["id"],
                                                        (int)reader["codigo"],
                                                        (string)reader["descripcion"],
                                                        (double)reader["precio"],
                                                        (int)reader["cantidadCuentas"],
                                                        (int)reader["cantidadFunciones"]);                                                                                                                                                                      
                    listaTester.Add(tester);
                }

                return listaTester;
            }
            catch (Exception)
            {
                throw new BaseDeDatosException(new Exception("No se pudieron obtener los registros de la tabla."));
            }
            finally
            {
                this.conexion.Close();
            }
        }
    }
}
