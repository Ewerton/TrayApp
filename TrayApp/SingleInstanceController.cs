using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayApp
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        //private Form mainForm;

        public SingleInstanceController() //   public SingleInstanceController(Form form)
        {
            this.IsSingleInstance = true;
            this.StartupNextInstance += this_StartupNextInstance;

            MessageBox.Show("Construtor Single Instance");
        }

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            if (e.CommandLine.Count > 1 && e.CommandLine[1].ToUpper() == "NOGUI")
            {
                frmPrincipal form = MainForm as frmPrincipal; //My derived form type
                MessageBox.Show("SingleInstance -> Processar...");
            }
            else
            {
                frmPrincipal form = MainForm as frmPrincipal;
                form.trayIcon.ShowBalloonTip(0, "Aviso", "A aplicação já está em execução", ToolTipIcon.Info);
            }

        }

        protected override void OnCreateMainForm()
        {
            MessageBox.Show("OnCreateMainForm...");
            this.MainForm = new frmPrincipal();
        }
    }
}
