using Archivos;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Jornada
    {
        #region atributos y propiedades
        /// <summary>
        /// Atributos de la Jornada
        /// </summary>
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            { 
                this.alumnos= value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set 
            { 
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            { 
                this.instructor = value;
            }
        }
        #endregion

        #region constructores
        /// <summary>
        /// Constructor
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="clase">Recibe una clase</param>
        /// <param name="instructor">Recibe un instructor</param>
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobreescritura del método ToString
        /// </summary>
        /// <returns>Retorna los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.clase, this.instructor);
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método estático Guardar
        /// Guarda una jornada en el archivo de texto datosJornada.txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna true si se pudo guardar</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto datosJornada = new Texto();
            return datosJornada.Guardar("datosJornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Método estático Leer
        /// Lee los datos del archivo de texto datosJornada.txt
        /// </summary>
        /// <returns>Retorna los datos leidos</returns>
        public static string Leer()
        {
            Texto datosJornada = new Texto();
            string datos = "";
            datosJornada.Leer("datosJornada.txt", out datos);
            return datos;
        }
        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador ==
        /// Una jornada es igual a un alumno si ese alumno esta en la lista de alumnos de la jornada
        /// </summary>
        /// <param name="j">Recibe la jornada</param>
        /// <param name="a">Recibe un alumno</param>
        /// <returns>Retorna true si son iguales</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool aux = false;
            foreach (Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    aux = true;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="j">Recibe una jornada</param>
        /// <param name="a">Recibe un alumno</param>
        /// <returns>Retorna true si son distintos</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador +
        /// Agrega un alumno a la lista de alumnos de la jornada
        /// </summary>
        /// <param name="j">Recibe la jornada</param>
        /// <param name="a">Recibe un alumno</param>
        /// <returns>Retorna la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;            
        }
        #endregion 
    }
}
