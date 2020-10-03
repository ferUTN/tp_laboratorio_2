using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abstracta Vehiculo
    /// </summary>
    public abstract class Vehiculo
    {
        #region enumerados
        /// <summary>
        /// Enumerado para las marcas de los vehículos
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        /// <summary>
        /// Enumerado para los tamaños de los vehículos
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region atributos y propiedades
        /// <summary>
        /// Atributos de los vehículos
        /// </summary>
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;

        /// <summary>
        /// Propiedad abstracta que devuelve el tamaño del vehículo
        /// </summary>
        protected abstract ETamanio Tamanio
        {
            get;
        }
        #endregion

       
        #region constructor
        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="chasis">Recibe el chasis del vehículo</param>
        /// <param name="marca">Recibe la marca del vehículo</param>
        /// <param name="color">Recibe el color del vehículo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Método virtual que públic los datos del vehículo.
        /// </summary>
        /// <returns>Devuelve una cadena con los datos del vehículo.</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region sobrecargas

        /// <summary>
        /// Sobrecarga del operador explícito string
        /// </summary>
        /// <param name="p">Objeto de tipo vehículo</param>
        /// <returns>Devuelve la información del vehículo</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CHASIS: {0}\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\n", p.color.ToString());
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="v1">Vehíhulo a comparar</param>
        /// <param name="v2">Vehículo a comparar</param>
        /// <returns>Devuelve true si ambos chasis son iguales o false si no lo son</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool aux = false;
            if (v1.chasis == v2.chasis)
            {
                aux = true;
            }
            return aux;
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="v1">Vehículo a comparar</param>
        /// <param name="v2">Vehículo a comparar</param>
        /// <returns>Devuelve true si los chasis son distintos, o false si son iguales</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion

    }
}
