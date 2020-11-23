using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Tester : Producto
    {

        #region atributos y propiedades
        private int cantidadCuentas;
        private int cantidadFunciones;

        public int CantidadCuentas
        {
            get
            {
                return this.cantidadCuentas;
            }
            set
            {
                this.cantidadCuentas = value;
            }
        }

        public int CantidadFunciones
        {
            get
            {
                return this.cantidadFunciones;
            }
            set
            {
                this.cantidadFunciones = value;
            }
        }
        #endregion


        #region constructores
        public Tester()
        {

        }

        public Tester(int codigo, string descripcion, double precio, int cantidadCuentas, int cantidadFunciones)
            : base(codigo, descripcion, precio)
        {
            this.cantidadCuentas = cantidadCuentas;
            this.cantidadFunciones = cantidadFunciones;
        }


        public Tester(int id, int codigo, string descripcion, double precio, int cantidadCuentas, int cantidadFunciones)
            : this(codigo, descripcion, precio, cantidadCuentas, cantidadFunciones)
        {
            this.Id = id;
        }
        #endregion

        /// <summary>
        /// Método que presenta los datos del tester
        /// </summary>
        /// <returns>Retorna los datos en forma de cadena</returns>
        private string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("--CARACTERISTICAS--");
            sb.AppendFormat("CANTIDAD DE CUENTAS: {0}\n", this.cantidadCuentas);
            sb.AppendFormat("CANTIDAD DE FUNCIONES: {0}\n", this.cantidadFunciones);
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString()
        /// </summary>
        /// <returns>Retorna los datos del tester en forma de cadena</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
