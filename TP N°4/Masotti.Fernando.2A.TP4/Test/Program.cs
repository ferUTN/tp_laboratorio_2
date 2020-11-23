
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;
using Archivos;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                AccesoDatosTester adTester = new AccesoDatosTester();
                AccesoDatosOsciloscopio adOsciloscopio = new AccesoDatosOsciloscopio();

                Tester t1 = new Tester(801, "Consola - Tester 1", 1000, 2999, 3);
                Tester t2 = new Tester(802, "Consola - Tester 2", 1200, 3999, 5);
                Tester t3 = new Tester(802, "Consola - Tester 3", 2500, 3999, 7);
                Tester t4 = new Tester(802, "Consola - Tester 4", 3500, 9999, 8);

                Osciloscopio osc1 = new Osciloscopio(803, "Consola - Osciloscopio 1", 55000, false, false);
                Osciloscopio osc2 = new Osciloscopio(804, "Consola - Osciloscopio 2", 115500, false, true);
                Osciloscopio osc3 = new Osciloscopio(804, "Consola - Osciloscopio 3", 170000, true, false);
                Osciloscopio osc4 = new Osciloscopio(804, "Consola - Osciloscopio 4", 255000, true, true);

                adTester.Guardar(t1);
                adTester.Guardar(t2);
                adTester.Guardar(t3);
                adTester.Guardar(t4);

                adOsciloscopio.Guardar(osc1);
                adOsciloscopio.Guardar(osc2);
                adOsciloscopio.Guardar(osc3);
                adOsciloscopio.Guardar(osc4);

                List<Tester> listaTester = adTester.ObtenerTodos();
                List<Osciloscopio> listaOsciloscopio = adOsciloscopio.ObtenerTodos();

                int idPrimerTester = listaTester[0].Id;
                int idPrimerOsciloscopio = listaOsciloscopio[0].Id;


                t1 = adTester.ObtenerPorId(idPrimerTester);
                osc1 = adOsciloscopio.ObtenerPorId(idPrimerOsciloscopio);

                t1.Descripcion = "Consola - Tester Modificado";
                osc1.Descripcion = "Consola - Osciloscopio Modificado";

                adTester.Modificar(t1);
                adOsciloscopio.Modificar(osc1);

                foreach (Tester item in adTester.ObtenerTodos())
                {
                    Console.WriteLine(item.ToString());
                }

                foreach (Osciloscopio item in adOsciloscopio.ObtenerTodos())
                {
                    Console.WriteLine(item.ToString());
                }

                if (adTester.Eliminar(idPrimerTester + 1))
                {
                    Console.WriteLine("Tester eliminado");
                }

                if (adOsciloscopio.Eliminar(idPrimerOsciloscopio + 1))
                {
                    Console.WriteLine("Osciloscopio eliminado");
                }

                Venta unaVenta = new Venta();

                unaVenta.Cliente = "MEDICIONES SRL";
                unaVenta.Fecha = DateTime.Now;
                unaVenta.Items.Add(adTester.ObtenerPorId(idPrimerTester + 2));
                unaVenta.Items.Add(adOsciloscopio.ObtenerPorId(idPrimerOsciloscopio + 2));

                string pathArchivoXml = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ventaConsola.xml");
                Xml<Venta> serializador = new Xml<Venta>();
                serializador.Guardar(pathArchivoXml, unaVenta);

                string pathArchivoTexto = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "facturaVentaConsola.txt");
                Texto<Venta> generadorDeFactura = new Texto<Venta>();
                generadorDeFactura.Guardar(pathArchivoTexto, unaVenta);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el test de consola.");
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
            
        }
    }
}
