using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayApp
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        private Form mainForm;
        public SingleInstanceController(Form form)
        {
            //We keep a reference to main form 
            //To run and also use it when we need to bring to front
            mainForm = form;
            this.IsSingleInstance = true;
            this.StartupNextInstance += this_StartupNextInstance;
        }

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            //Here we bring application to front
            //e.BringToForeground = false;
            //mainForm.ShowInTaskbar = false;
            //mainForm.WindowState = FormWindowState.Minimized;
            //mainForm.Show();
            //mainForm.WindowState = FormWindowState.Normal;

            // Se o programa for executado pela linha de comando ou por serviço agenda e 
            // tiver o parametro "NOGUI" (sem interface grafica de usuário), exemplo C:\PRONIM> ExtratorFilaESocial.exe NOGUI
            // O programa não abre o Form principal
            if (e.CommandLine.Count > 1)
            {
                if (e.CommandLine[1].ToUpper() == "NOGUI")
                {
                    frmPrincipal form = MainForm as frmPrincipal; //My derived form type
                    form.Processar();
                }
                else
                {
                    //Se não tiver o argumento "NOGUI" executa a aplicação normal (tray)
                    Application.EnableVisualStyles();
                    //Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmPrincipal());
                }
            }
        }

        protected override void OnCreateMainForm()
        {
            this.MainForm = mainForm;
        }
    }
}
