using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Osciloscopio : Producto
    {
        #region atributos y propiedades
        private bool puertoUsb;
        private bool portatil;

        public bool PuertoUsb
        {
            get
            {
                return this.puertoUsb;
            }
            set
            {
                this.puertoUsb = value;
            }
        }
        public bool Portatil
        {
            get
            {
                return this.portatil;
            }
            set
            {
                this.portatil = value;
            }
        }
        #endregion

        #region constructores
        public Osciloscopio()
        {

        }

        public Osciloscopio(int codigo, string descripcion, double precio, bool puertoUsb, bool portatil)
            : base(codigo, descripcion, precio)
        {
            this.puertoUsb = puertoUsb;
            this.portatil = portatil;
        }


        public Osciloscopio(int id, int codigo, string descripcion, double precio, bool puertoUsb, bool portatil)
            : this(codigo, descripcion, precio, puertoUsb, portatil)
        {
            this.Id = id;
        }
        #endregion



        /// <summary>
        /// Método que presenta los datos del osciloscopio
        /// </summary>
        /// <returns>Retorna los datos en forma de cadena</returns>
        private string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("--CARACTERISTICAS--");
            sb.AppendFormat("PUERTO USB: {0}\n", this.PuertoUsb);
            sb.AppendFormat("PORTÁTIL: {0}\n", this.Portatil);
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString()
        /// </summary>
        /// <returns>Retorna los datos del osciloscopio en forma de cadena</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


    }
}
