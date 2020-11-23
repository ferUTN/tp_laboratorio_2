using System;
using Archivos;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void SerializarVenta()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(111, "Tester de Prueba", 100, 1000, 4));
            string pathArchivo = "test_venta.xml";
            Xml<Venta> xml = new Xml<Venta>();

            bool resultado = xml.Guardar(pathArchivo, venta);

            Assert.IsTrue(resultado);            
        }


        [TestMethod]
        public void DeserializarVenta()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(111, "Tester de Prueba", 100, 1000, 4));
            string pathArchivo = "test_venta.xml";
            Xml<Venta> xml = new Xml<Venta>();
            xml.Guardar(pathArchivo, venta);

            bool resultado = xml.Leer(pathArchivo, out Venta nuevaVenta);           

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void ImprimirFactura()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(111, "Tester de Prueba", 100, 1000, 4));
            string pathArchivo = "test_venta.txt";
            Texto<Venta> txt = new Texto<Venta>();

            bool resultado = txt.Guardar(pathArchivo, venta);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void LeerFactura()
        {
            Venta venta = new Venta(DateTime.Now, "Pepe Sanchez");
            venta.Items.Add(new Tester(111, "Tester de Prueba", 100, 1000, 4));
            string pathArchivo = "test_venta.txt";
            Texto<Venta> txt = new Texto<Venta>();
            txt.Guardar(pathArchivo, venta);

            bool resultado = txt.Leer(pathArchivo, out string factura);

            Assert.IsTrue(resultado);
        }



    }
}
