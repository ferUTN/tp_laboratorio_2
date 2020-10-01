using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region atributos y propiedades
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region constructor
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {

        }
        #endregion


        #region metodos
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SUV\n");
            sb.AppendFormat("{0}\n", base.Mostrar());
            sb.AppendFormat("TAMAÑO: {0}\n", this.Tamanio);
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion

    }
}
