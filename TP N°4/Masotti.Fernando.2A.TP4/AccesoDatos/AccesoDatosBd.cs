using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    /// <summary>
    /// Clase abstracta y genérica para el acceso a la base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AccesoDatosBd<T>
    {
        
        protected SqlConnection conexion;
        protected SqlDataReader lector;
        protected SqlCommand comando;

        /// <summary>
        /// Constructor con el string de conexión a la base de datos
        /// </summary>
        public AccesoDatosBd()
        {
            this.conexion = new SqlConnection("Data Source=DESKTOP-I54N2AN\\SQLEXPRESS;Initial Catalog = lab2_tp4; Integrated Security = true");
        }

        public abstract bool Eliminar(int id);
        public abstract bool Guardar(T entidad);
        public abstract bool Modificar(T entidad);
        public abstract T ObtenerPorId(int id);
        public abstract List<T> ObtenerTodos();

    }
}
