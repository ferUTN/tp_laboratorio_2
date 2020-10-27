using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace Entidades
{
    sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

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

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool aux = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                aux = true;
            }
            return aux;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool aux = false;
            if(a.claseQueToma != clase)
            {
                aux = true;
            }
            return aux;
        }

    }
}
