using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        #region atributos
        /// <summary>
        /// Atributos del profesor
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor de clase
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor():base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>(new[] { Universidad.EClases.Laboratorio, Universidad.EClases.Programacion });
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="id">Recibe el id</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="apellido">Recibe el apellido</param>
        /// <param name="dni">Recibe el dni</param>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region metodos
        /// <summary>
        /// Método que le agrega dos clases al azar al profesor
        /// </summary>
        private void _randomClases()
        {
            int cantidad = Enum.GetValues(typeof(Universidad.EClases)).GetLength(0);
            for(int i= 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, cantidad));
            }
        }

        /// <summary>
        /// Sobreescritura del método ToString
        /// </summary>
        /// <returns>Retorna los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobreescritura del método ParticiparEnClase
        /// </summary>
        /// <returns>Retorna las clases que dicta el profesor</returns>
        protected override string ParticiparEnClase()
        {
            string cadena = "CLASES DEL DÍA:";
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                cadena = cadena + "\n" + item;
            }
            return cadena;
        }

        /// <summary>
        /// Sobreescritura del método MostrarDatos
        /// </summary>
        /// <returns>Retorna los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador ==
        /// Un profesor es igual a una clase si dicta la misma
        /// </summary>
        /// <param name="i">Recibe un profesor</param>
        /// <param name="clase">Recibe una clase</param>
        /// <returns>Retorna true si son iguales</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool aux = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
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
        /// <param name="i">Recibe un profesor</param>
        /// <param name="clase">Recibe una clase</param>
        /// <returns>Retorna true si son distintos</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion 
    }
}
