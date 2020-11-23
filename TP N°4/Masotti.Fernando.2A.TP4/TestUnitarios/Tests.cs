using System;
using Archivos;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Teste que verifica que se pueda serializar una venta en el archivo xml
        /// </summary>
        [TestMethod]
        public void SerializarVenta()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(590, "Tester de Prueba", 2750, 1000, 4));
            venta.Items.Add(new Osciloscopio(690, "Osciloscopio de Prueba", 145000, true, true));
            string pathArchivo = "test_venta.xml";
            Xml<Venta> xml = new Xml<Venta>();

            bool resultado = xml.Guardar(pathArchivo, venta);

            Assert.IsTrue(resultado);            
        }

        /// <summary>
        /// Test que verifica que se pueda deserializar una venta del archivo xml
        /// </summary>
        [TestMethod]
        public void DeserializarVenta()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(111, "Tester de Prueba", 100, 1000, 4));
            venta.Items.Add(new Osciloscopio(690, "Osciloscopio de Prueba", 145000, true, true));
            string pathArchivo = "test_venta.xml";
            Xml<Venta> xml = new Xml<Venta>();
            xml.Guardar(pathArchivo, venta);

            bool resultado = xml.Leer(pathArchivo, out Venta nuevaVenta);           

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Test que verifica que se pueda imprimir la factura en un archivo de texto
        /// </summary>
        [TestMethod]
        public void ImprimirFactura()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(111, "Tester de Prueba", 100, 1000, 4));
            venta.Items.Add(new Osciloscopio(690, "Osciloscopio de Prueba", 145000, true, true));
            string pathArchivo = "test_venta.txt";
            Texto<Venta> txt = new Texto<Venta>();

            bool resultado = txt.Guardar(pathArchivo, venta);

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Test que verifica que se pueda leer el archivo de texto
        /// </summary>
        [TestMethod]
        public void LeerFactura()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(111, "Tester de Prueba", 100, 1000, 4));
            venta.Items.Add(new Osciloscopio(690, "Osciloscopio de Prueba", 145000, true, true));
            string pathArchivo = "test_venta.txt";
            Texto<Venta> txt = new Texto<Venta>();
            txt.Guardar(pathArchivo, venta);

            bool resultado = txt.Leer(pathArchivo, out string factura);

            Assert.IsTrue(resultado);
        }

    }
}
