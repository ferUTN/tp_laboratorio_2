using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        public DniInvalidoException() : this("DNI con Error de formato.")
        {
        
        }

        public DniInvalidoException(string message) : base(message)
        {

        }

        public DniInvalidoException(Exception e) : this(e.Message)
        {

        }

        public DniInvalidoException(string message, Exception e): base(message, e)
        {

        }

    }
}
