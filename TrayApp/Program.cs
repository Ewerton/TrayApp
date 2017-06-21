using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrayApp;

namespace TrayApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MessageBox.Show("Program  -> Main");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] args = Environment.GetCommandLineArgs();

            MessageBox.Show("Program -> Abrindo normal...");
            SingleInstanceController controller = new SingleInstanceController();
            controller.Run(args);

        }
    }
}
