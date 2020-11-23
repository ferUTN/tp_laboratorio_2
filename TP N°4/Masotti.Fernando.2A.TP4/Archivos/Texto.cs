using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase genérica para la escritura de archivos de texto
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Texto<T>: IArchivoTexto<T>
    {

        /// <summary>
        /// Implementación del método Guardar para archivos de texto
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos a guardar</param>
        /// <returns>Retorna true si se pudo guardar</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool aux = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {                    
                    sw.WriteLine(datos.ToString());
                    aux = true;
                }
            }
            catch (Exception e)
            {
                aux = false;
                throw new ArchivosException(new Exception("No se pudo escribir el archivo de texto."));
            }
            return aux;
        }


        /// <summary>
        /// Implementación del método Leer para archivos de texto
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos leidos</param>
        /// <returns>Retorna true si se pudo leer</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool aux = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                    aux = true;
                }
            }
            catch (Exception e)
            {                
                datos = null;
                aux = false;
                throw new ArchivosException(new Exception("No se pudo leer el archivo de texto."));
            }
            return aux;
        }
    }
}
