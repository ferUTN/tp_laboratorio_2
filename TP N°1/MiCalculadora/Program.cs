using System;
using System.Windows.Forms;

namespace MiCalculadora
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada a la aplicación
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormCalculadora());
        }
    }
}
