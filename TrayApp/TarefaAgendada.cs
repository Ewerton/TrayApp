using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrayApp
{
    public static class TarefaAgendada
    {
        private const string TaskName = "MyScheduledTask";
        private const int intervaloPadraoMinutos = 1;

        public static void EnableTask()
        {
            using (TaskService ts = new TaskService())
            {
                ts.GetTask(TaskName).Enabled = true;
            }
        }

        public static void DisableTask()
        {
            using (TaskService ts = new TaskService())
            {
                ts.GetTask(TaskName).Enabled = false;
            }
        }

        public static void CreateOrUpdateTaskAgendamento()
        {
            CreateOrUpdateTaskAgendamento(intervaloPadraoMinutos);
        }

        public static void CreateOrUpdateTaskAgendamento(int intervaloRepeticaoEmMinutos)
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.GetTask(TaskName) == null) // se a task ainda não existe
                {
                    // Cria uma task e seta algumas propriedades
                    TaskDefinition td = ts.NewTask();

                    td.RegistrationInfo.Description = "Some scheduled task example.";

                    Trigger tr = CriarTrigger(intervaloRepeticaoEmMinutos);
                    td.Triggers.Add(tr);

                    string aplicacaoExecutar = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    td.Actions.Add(new ExecAction(aplicacaoExecutar, "NOGUI", null));
                    //td.Actions.Add(new ExecAction("C:\\Windows\\notepad.exe"));

                    ts.RootFolder.RegisterTaskDefinition(TaskName, td);

                    //Task t = ObterTaskAgendamento();
                    //if (t != null)
                    //    t.Run();
                }
            }

        }

        private static Trigger CriarTrigger(int intervaloRepeticaoEmMinutos)
        {
            //Tarefa que é executada assim que criada ou alterada.
            RegistrationTrigger rt = new RegistrationTrigger();
            rt.Repetition.Interval = TimeSpan.FromMinutes(intervaloRepeticaoEmMinutos);
            return rt;
        }


    }
}
