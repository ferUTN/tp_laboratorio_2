using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    /// <summary>
    /// Clase Sedan derivada de la clase base Vehiculo
    /// </summary>
    public class Sedan : Vehiculo
    {
        #region enumerado
        /// <summary>
        /// Enumerado para la cantidad de puertas
        /// </summary>
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas
        }
        #endregion

        /// <summary>
        /// Atributo de los objetos Sedan
        /// </summary>
        #region atributos y propiedades
        private ETipo tipo;

        /// <summary>
        /// Propiedad para el tamaño de los objetos Sedan.
        /// Todos los objetos de esta clase son de tamaño mediano.
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region constructores

        /// <summary>
        /// Constructor sobrecargado.
        /// Por defecto, todos los objetos Sedan tendran cuatro puertas
        /// </summary>
        /// <param name="marca">Recibe la marca</param>
        /// <param name="chasis">Recibe el chasis</param>
        /// <param name="color">Recibe el color</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
         
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="marca">Recibe la marca</param>
        /// <param name="chasis">Recibe el chasis</param>
        /// <param name="color">Recibe el color</param>
        /// <param name="tipo">Recibe el tipo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobreescritura del método Mostrar()
        /// </summary>
        /// <returns>Devuelve una cadena con los datos del objeto Sedan.</returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SEDAN\n");
            sb.AppendFormat("{0}\n", base.Mostrar());
            sb.AppendFormat("TAMAÑO: {0} TIPO: {1}\n", this.Tamanio, this.tipo);
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
