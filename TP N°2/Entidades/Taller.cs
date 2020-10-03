using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase sellada Taller.
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        #region enumerados
        /// <summary>
        /// Enumerado para los tipos de vehículos
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion

        /// <summary>
        /// Atributos del Taller
        /// </summary>
        #region atributos y propiedades
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        #endregion


        #region "Constructores"
        /// <summary>
        /// Constructor por defecto.
        /// Inicializa la Lista de vehículos.
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor sobrecargado.
        /// </summary>
        /// <param name="espacioDisponible">Recibe el espacio disponible</param>
        public Taller(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Sobreescritura del método ToString().
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Devuelve los datos del Taller y el de todos los vehículos que contiene</returns>
        public override string ToString()
        {
            return this.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Método para listar los autos del taller que pertenezcan a un tipo
        /// </summary>
        /// <param name="taller">Recibe el taller</param>
        /// <param name="ETipo">Recibe el tipo de vehículo a listar del taller</param>
        /// <returns>Devuelve los vehículos del tipo solicitado</returns>
        public string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", t.vehiculos.Count, t.espacioDisponible);
            foreach (Vehiculo v in t.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if(v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                            sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Sobrecarga del operador +
        /// Agregará un vehículo a la lista del taller
        /// </summary>
        /// <param name="taller">Recibe el taller a donde se agregará el vehículo</param>
        /// <param name="vehiculo">Recibe el vehículo a agregar</param>
        /// <returns>Devuelve el taller</returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {
            if ( t.vehiculos.Count() < t.espacioDisponible)
            {
                bool aux = false;
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        aux = true;
                        break;
                    }
                }
                if (!aux)
                {            
                    t.vehiculos.Add(vehiculo);
                }
            }
            return t;
        }


        /// <summary>
        /// Sobrecarga del operador -
        /// Quitará un vehículo de la lista del taller
        /// </summary>
        /// <param name="taller">Recibe el taller de donde se quitará el vehículo</param>
        /// <param name="vehiculo">Recibe el vehículo a quitar</param>
        /// <returns>Devuelve el taller</returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                {
                    t.vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return t;
        }
        #endregion
    }
}
