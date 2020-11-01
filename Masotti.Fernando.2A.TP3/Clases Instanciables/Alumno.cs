using System.Text;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        #region enumerados
        /// <summary>
        /// Enumerado para los posibles estados de cuenta del alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion region

        #region atributos
        /// <summary>
        /// Atributos del alumno
        /// </summary>
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno() : base()
        {
            this.estadoCuenta = EEstadoCuenta.AlDia;
            this.claseQueToma = Universidad.EClases.SPD;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="id">Recibe el id</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="apellido">Recibe el apellido</param>
        /// <param name="dni">Recibe el dni</param>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        /// <param name="claseQueToma">Recibe la clase que toma</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="id">Recibe el id</param>
        /// <param name="nombre">Recibe el nombre</param>
        /// <param name="apellido">Recibe el apellido</param>
        /// <param name="dni">Recibe el dni</param>
        /// <param name="nacionalidad">Recibe la nacionalidad</param>
        /// <param name="claseQueToma">Recibe la clase que toma</param>
        /// <param name="estadoCuenta">Recibe el estado de cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Sobreescritura del método MostrarDatos
        /// </summary>
        /// <returns>Retorna los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            string estado = "";
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    estado = "Cuota al día";
                    break;
                default:
                    estado = this.estadoCuenta.ToString();
                    break;
            }
            
            this.estadoCuenta.ToString();
            
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}\n\n", base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", estado);
            sb.AppendFormat("TOMA CLASES DE: {0}", this.claseQueToma);
            return sb.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString
        /// </summary>
        /// <returns>Retorna los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobreescritura del método ParticiparEnClase
        /// </summary>
        /// <returns>Retorna las clases que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }
        #endregion

        #region sobrecarga de operadores
        /// <summary>
        /// Sobrecarga del operador ==
        /// Un alumno es igual a una clase si toma la misma clase y si no es deudor 
        /// </summary>
        /// <param name="a">Recibe un alumno</param>
        /// <param name="clase">Recibe una clase</param>
        /// <returns>Retorna true si son iguales</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool aux = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                aux = true;
            }
            return aux;
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="a">Recibe un alumno</param>
        /// <param name="clase">Recibe una clase</param>
        /// <returns>Retorna true si no son iguales</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool aux = false;
            if(a.claseQueToma != clase)
            {
                aux = true;
            }
            return aux;
        }
        #endregion 
    }
}
