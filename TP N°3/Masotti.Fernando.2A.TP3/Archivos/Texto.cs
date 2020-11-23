using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Implementación del método Guardar para archivos de texto
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos a guardar</param>
        /// <returns>Retorna true si se pudo guardar</returns>
        public bool Guardar(string archivo, string datos)
        {
            if (archivo == null)
            {
                throw new ArchivosException(new Exception("Error en el archivo de texto a guardar."));
            }

            if (datos == null)
            {
                throw new ArchivosException(new Exception("Error en los datos a guardar en el archivo de texto."));
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Implementación del método Leer para archivos de texto
        /// </summary>
        /// <param name="archivo">La ruta del archivo</param>
        /// <param name="datos">Los datos leidos</param>
        /// <returns>Retorna true si se pudo leer</returns>
        public bool Leer(string archivo, out string datos)
        {
            if (archivo == null)
            {
                throw new ArchivosException(new Exception("Error en el archivo de texto a leer."));
            }
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}