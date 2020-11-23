using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Atributos agregados para la serialización de las clases derivadas de Producto
    /// </summary>
    [XmlInclude(typeof(Tester))]
    [XmlInclude(typeof(Osciloscopio))]
    public abstract class Producto
    {
        #region atributos y propiedades
        private int id;
        private int codigo;
        private string descripcion;
        private double precio;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public Double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        #endregion

        #region constructores
        public Producto()
        {

        }

        public Producto(int codigo, string descripcion, double precio)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public Producto(int id, int codigo, string descripcion, double precio):this(codigo,descripcion,precio)
        {
            this.id = id;
        }
        #endregion

        /// <summary>
        /// Sobreescritura del método ToString()
        /// </summary>
        /// <returns>Retorna los datos del producto</returns>
        public override string ToString()
        {          
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CODIGO: {0}, DESCRIPCIÓN: {1}, PRECIO: {2}", this.codigo, this.descripcion, this.precio);
            return sb.ToString();
        }

    }
}
