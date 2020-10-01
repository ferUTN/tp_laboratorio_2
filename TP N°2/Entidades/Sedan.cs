using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region enumerado
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion

        #region atributos y propiedades
        private ETipo tipo;

        /// <summary>
        /// Sedan son 'Mediano'
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
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
         
        }

        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region metodos
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
