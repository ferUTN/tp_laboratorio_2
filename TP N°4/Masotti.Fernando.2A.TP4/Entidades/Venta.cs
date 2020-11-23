using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Entidades
{
  
    public class Venta
    {

        #region atributos y propiedades
        private int id;
        private DateTime fecha;
        private string cliente;
        private List<Producto> productos;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }


        public string Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double total = 0;
                foreach (Producto item in this.productos)
                {
                    total += item.Precio;
                }
                return total;
            }
        }

        public List<Producto> Items
        {
            get { return this.productos; }
        }
        #endregion


        #region constructores
        public Venta()
        {
            this.productos = new List<Producto>();
        }

        public Venta(DateTime fecha, string cliente) : this()
        {
            this.fecha = fecha;
            this.cliente = cliente;
        }

        public Venta(int id, DateTime fecha, string cliente) : this(fecha,cliente)
        {
            this.id = id;
        }
        #endregion


        public void GenerarArchivosVenta()
        {
            string pathArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "venta.xml");
            Xml<Venta> serializador = new Xml<Venta>();
            serializador.Guardar(pathArchivo, this);

            pathArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "facturaVenta.txt");
            Texto<Venta> generadorFactura = new Texto<Venta>();
            generadorFactura.Guardar(pathArchivo, this);
        }


        /// <summary>
        /// Sobreescritura del método ToString()
        /// </summary>
        /// <returns>Retorna los datos completos de la venta en forma de cadena</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------DATOS DE LA FACTURA----------\n");
            sb.AppendFormat("FECHA: {0}\n", this.fecha.ToShortDateString());
            sb.AppendFormat("CLIENTE: {0}\n", this.cliente);
            sb.AppendLine("\n***DETALLE DE LOS PRODUCTOS***\n");
            foreach (Producto item in this.productos)
            {
                sb.AppendFormat("\n{0}", item.ToString());
            }
            sb.AppendFormat("\nTOTAL FACTURADO: {0}\n", this.PrecioTotal);         
            return sb.ToString();
        }
    }
}
