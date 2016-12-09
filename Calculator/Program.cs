using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrammarOfArithmetic;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists(Environment.CurrentDirectory + "\\CurrenciesHistory\\"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\CurrenciesHistory\\");
            if (!Directory.Exists(Environment.CurrentDirectory + "\\SavedCalculations\\"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\SavedCalculations\\");
            Application.Run(new Calculator(new Parser()));
        }
    }
}
