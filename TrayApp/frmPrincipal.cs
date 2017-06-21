using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayApp
{
    public partial class frmPrincipal : Form
    {
        public NotifyIcon trayIcon = new NotifyIcon(); // cleaned up on the form dispose
        private ContextMenu trayMenu = new ContextMenu();

        public frmPrincipal()
        {
            InitializeComponent();
            MessageBox.Show("frmPrincipal -> Construtor.");

            //Create the schedule task and enables It
            TarefaAgendada.CreateOrUpdateTaskAgendamento();
            TarefaAgendada.EnableTask();

            CriarMenuContextoTray();
            CriarTrayIcon();
        }

        private void CriarTrayIcon()
        {
            //trayIcon = new NotifyIcon();

            //Cria o icone no Tray
            trayIcon.Text = "Gerenciador da Fila de Envio para o eSocial";
            trayIcon.Icon = SystemIcons.WinLogo; // new Icon(Resources.transmit, 32, 32); // SystemIcons.Application, 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            trayIcon.BalloonTipClosed += (sender, e) =>
            {
                //var thisIcon = (NotifyIcon)sender;
                //thisIcon.Visible = false;
                //thisIcon.Dispose();
                //MessageBox.Show("msg");
            };
        }

        private void CriarMenuContextoTray()
        {
            // cria um menu que é mostrado quando clica com o botão direito em cma do icone do Tray.
            //trayMenu = new ContextMenu();

            trayMenu.MenuItems.Add("Configurações", OnConfiguracoesClick);
            trayMenu.MenuItems[0].DefaultItem = true;
            trayMenu.MenuItems.Add("Fila", OnHabilitadoClick);
            trayMenu.MenuItems.Add("Exit", OnExit);
        }

        private void OnHabilitadoClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnConfiguracoesClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnExit(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                TarefaAgendada.DisableTask();
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }
        //private NotifyIcon trayIcon;
        //private ContextMenu trayMenu;
        //public frmPrincipal()
        //{
        //InitializeComponent();

        //Create the schedule task and enables It
        //TarefaAgendada.CreateOrUpdateTaskAgendamento();
        //TarefaAgendada.EnableTask();

        //Create the ContextMenu
        //trayMenu = new ContextMenu();
        //trayMenu.MenuItems.Add("MenuItem1", MenuItem1Click);
        //trayMenu.MenuItems.Add("MenuItem2", MenuItem2Click);
        //trayMenu.MenuItems.Add("Exit", OnExit);


        ////Create the TrayIcon
        //trayIcon = new NotifyIcon();
        //trayIcon.Text = "My Tray App";
        //trayIcon.Icon = this.Icon; //The Form Icon;

        //// Add menu to tray icon and show it.
        //trayIcon.ContextMenu = trayMenu;
        //trayIcon.Visible = true;

        //// trayIcon.BalloonTipClosed += TrayIcon_BalloonTipClosed;
        //trayIcon.BalloonTipClosed += (sender, e) =>
        //{
        //    var thisIcon = (NotifyIcon)sender;
        //    thisIcon.Visible = false;
        //    thisIcon.Dispose();
        //};

        //}

        //private void TrayIcon_BalloonTipClosed(object sender, EventArgs e)
        //{
        //    var thisIcon = (NotifyIcon)sender;
        //    thisIcon.Visible = false;
        //    thisIcon.Dispose();
        //}

        //[STAThread]
        //static void Main(string[] args)
        //{
        //Assert that just one instance will be ruinning 
        // When called by the scheduler, it will have the "NOGUI" arg

        //To debug, run application from the Bin/debug folder, attach the process, put brakpoint in the
        // SingleInstanceController.this_StartupNextInstance
        //  var controller = new SingleInstanceController(new frmPrincipal());

        //Execute the application
        // controller.Run(Environment.GetCommandLineArgs());
        // }

        //public void Processar()
        //{
        //    //trayIcon.ShowBalloonTip(0, "Teste", "Teste", ToolTipIcon.Info); // Do some "brackground tasks";
        //}



        //protected override void OnLoad(EventArgs e)
        //{
        //    Visible = false; // Hide form window.
        //    ShowInTaskbar = false; // Remove from taskbar.

        //    base.OnLoad(e);
        //}

        //protected void Dispose(bool isDisposing)
        //{
        //   icon disposing is called on Designer.cs dispose method
        //}


        //private void MenuItem1Click(object sender, EventArgs e)
        //{

        //}
        //private void MenuItem2Click(object sender, EventArgs e)
        //{

        //}
    }
}
