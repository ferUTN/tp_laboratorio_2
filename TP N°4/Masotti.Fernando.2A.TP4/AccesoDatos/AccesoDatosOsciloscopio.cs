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
    public class AccesoDatosOsciloscopio : AccesoDatosBd<Osciloscopio>
    {

        /// <summary>
        /// Método para eliminar un registro de la tabla osciloscopio según su id
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns>Devuelve true si se pudo eliminar</returns>
        public override bool Eliminar(int id)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("DELETE FROM osciloscopio WHERE id = @id", this.conexion);
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
        /// Método para agregar un registro a la tabla osciloscopio
        /// </summary>
        /// <param name="entidad">Objeto Osciloscopio a agregar</param>
        /// <returns>Devuelve true si se pudo agregar</returns>
        public override bool Guardar(Osciloscopio entidad)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("INSERT INTO osciloscopio (codigo,descripcion,precio,puertoUsb,portatil)" +
                    " VALUES (@codigo, @descripcion, @precio,@puertoUsb,@portatil)", this.conexion);
                this.comando.Parameters.AddWithValue("@codigo", entidad.Codigo);
                this.comando.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                this.comando.Parameters.AddWithValue("@precio", entidad.Precio);
                this.comando.Parameters.AddWithValue("@puertoUsb", entidad.PuertoUsb);
                this.comando.Parameters.AddWithValue("@portatil", entidad.Portatil);

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
        /// Método para modificar un registro de la tabla osciloscopio
        /// </summary>
        /// <param name="entidad">Objeto Osciloscopio a modificar</param>
        /// <returns>Devuelve true si se pudo modificar</returns>
        public override bool Modificar(Osciloscopio entidad)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("UPDATE osciloscopio SET codigo=@codigo, descripcion=@descripcion, precio=@precio, puertoUsb=@puertoUsb, portatil=@portatil WHERE id=@id", this.conexion);
                this.comando.Parameters.AddWithValue("@codigo", entidad.Codigo);
                this.comando.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                this.comando.Parameters.AddWithValue("@precio", entidad.Precio);
                this.comando.Parameters.AddWithValue("@puertoUsb", entidad.PuertoUsb);
                this.comando.Parameters.AddWithValue("@portatil", entidad.Portatil);
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
        /// Método para obtener un registro de la tabla osciloscopio según su id
        /// </summary>
        /// <param name="id">id del registro a obtener</param>
        /// <returns>Devuelve un objeto Osciloscopio con los valores del registro de la tabla</returns>
        public override Osciloscopio ObtenerPorId(int id)
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SELECT * FROM osciloscopio WHERE id = @id", this.conexion);
                this.comando.Parameters.AddWithValue("@id", id);

                var reader = this.comando.ExecuteReader();

                Osciloscopio nuevoOsciloscopio = null;

                if (reader.Read())
                {
                    nuevoOsciloscopio= new Osciloscopio((int)reader["id"],
                                                        (int)reader["codigo"],
                                                        (string)reader["descripcion"],
                                                        (double)reader["precio"],
                                                        (bool)reader["puertoUsb"],
                                                        (bool)reader["portatil"]);

                }
                return nuevoOsciloscopio;
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
        /// Método para obtener todos los registros de la tabla osciloscopio
        /// </summary>
        /// <returns>Devuelve una lista de objetos Osciloscopio con los valores de los registros de la tabla</returns>
        public override List<Osciloscopio> ObtenerTodos()
        {
            List<Osciloscopio> listaOsciloscopio = new List<Osciloscopio>();
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SELECT * FROM osciloscopio", this.conexion);
                var reader = this.comando.ExecuteReader();
                while (reader.Read())
                {
                    Osciloscopio osc = new Osciloscopio((int)reader["id"],
                                                            (int)reader["codigo"],
                                                            (string)reader["descripcion"],
                                                            (double)reader["precio"],
                                                            (bool)reader["puertoUsb"],
                                                            (bool)reader["portatil"]);                                                                                                                                                                      
                    listaOsciloscopio.Add(osc);
                }

                return listaOsciloscopio;
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
