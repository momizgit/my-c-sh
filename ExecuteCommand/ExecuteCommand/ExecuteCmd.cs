using System;
using System.Threading;

namespace ExecuteCommand
{
    public class ExecuteCmd
    {

        private String CommandExec = "cmd";

        public ExecuteCmd(String ExeNameString= "cmd")
        {
            this.CommandExec = ExeNameString;
        }

        public void ExecuteCommand(object ArgString)
        {
            this.RunCommand(ArgString);
        }
        private void RunCommand(object command)
        {
            try
            {
                if(!this.CommandExec.ToLower().EndsWith("exe"))
                {
                    this.CommandExec += ".exe";
                }

                if(this.CommandExec.ToLower().Equals("cmd.exe"))
                {
                    command = "/c " + command;
                }
                Console.WriteLine(command);
                Console.WriteLine(this.CommandExec);
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(this.CommandExec, command.ToString());
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }

        public void ExecuteCommandinThread(string command)
        {
            try
            {
                Thread objThread = new Thread(new ParameterizedThreadStart(RunCommand));
                objThread.IsBackground = true;
                objThread.Priority = ThreadPriority.AboveNormal;
                objThread.Start(command);
            }
            catch (ThreadStartException objException)
            {
                // Log the exception
            }
            catch (ThreadAbortException objException)
            {
                // Log the exception
            }
            catch (Exception objException)
            {
                // Log the exception
            }
        }      
    }
}
