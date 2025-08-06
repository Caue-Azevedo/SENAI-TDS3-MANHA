using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC_SENAI_CAUE_GUEDES
{
    internal static class Program
    {

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread] // controla pra usar thread como single-threaded pra UI //
        static void Main()
        {

            Application.EnableVisualStyles(); // habilita estilos pra usar o tema do Windows //
            Application.SetCompatibleTextRenderingDefault(false); // controla como o texto é renderizado, pra usar o GDI+ //
            Application.Run(new Form1()); // inicia o aplicativo pelo Form1 //
        }
    }
}
