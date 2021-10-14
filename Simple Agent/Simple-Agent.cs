using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using static System.IO.StreamWriter;

namespace Simple_Agent
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToLog("Service Started " + DateTime.Now);
        }

        protected override void OnStop()
        {
            WriteToLog("Service Stopped " + DateTime.Now);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void WriteToLog(String message)
        {
            
            String apppath = AppDomain.CurrentDomain.BaseDirectory + "SA_Log";
            if (!Directory.Exists(apppath))
            {
                Directory.CreateDirectory(apppath);
            }
            String LogFile = apppath + @"\SA-Log" + ".log";
            
            if (File.Exists(LogFile))
            {
                StreamWriter LogWriter = File.AppendText(LogFile);
            }
            else
            {
                StreamWriter LogWriter = File.CreateText(LogFile);
            }
        }

        private void Looptimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
