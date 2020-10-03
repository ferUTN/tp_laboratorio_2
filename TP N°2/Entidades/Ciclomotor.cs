using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Ciclomotor derivada de la clase base Vehiculo
    /// </summary>
    public class Ciclomotor : Vehiculo
    {

        #region atributos y propiedades
        /// <summary>
        /// Propiedad para el tamaño de los objetos Ciclomotor.
        /// Todos los objetos de esta clase son de tamaño "Chico".
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="marca">Recibe la marca</param>
        /// <param name="chasis">Recibe el chasis</param>
        /// <param name="color">Recibe el color</param>
        #region constructor
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {

        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobreescritura del método Mostrar()
        /// </summary>
        /// <returns>Devuelve una cadena con los datos del objeto Ciclomotor.</returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CICLOMOTOR\n");
            sb.AppendFormat("{0}\n", base.Mostrar());
            sb.AppendFormat("TAMAÑO: {0}\n", this.Tamanio);
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion
    }
}
