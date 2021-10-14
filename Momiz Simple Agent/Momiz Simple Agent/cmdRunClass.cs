using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Momiz_Simple_Agent
{
    class cmdRunClass
    {
        public bool IsInitialized;
        private static string varProcessOutput = "", varCommandExecutable = "cmd.exe", varProcessCommandName = "dir /s c:", ErrorOutString = "";
        private static Thread RunCommadThread { get; set; }

        public cmdRunClass()
        {
            IsInitialized = true;
        }

        public void run()
        {
            RunCommadThread = new Thread(new ThreadStart(() =>
            {
                try
                {

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = varCommandExecutable;
                    if (!(varCommandExecutable.ToLower().EndsWith("exe") && varCommandExecutable.ToLower().EndsWith("vbs"))) process.StartInfo.FileName = varCommandExecutable + ".exe";
                    if (varCommandExecutable.ToLower().StartsWith("powershell"))
                    {

                        if (varProcessCommandName.ToLower().EndsWith(".ps1"))
                        {
                            process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{varProcessCommandName}\"";
                        }
                        else
                        {
                            var psCommandBytes = System.Text.Encoding.Unicode.GetBytes(varProcessCommandName);
                            var psCommandBase64 = Convert.ToBase64String(psCommandBytes);
                            process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy remotesigned -EncodedCommand {psCommandBase64}";

                        }
                    }
                    if (varCommandExecutable.ToLower().StartsWith("cmd")) process.StartInfo.Arguments = @"/C " + varProcessCommandName;
                    if (varCommandExecutable.ToLower().StartsWith("cscript")) process.StartInfo.Arguments = @"/C " + varProcessCommandName;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardInput = true;
                    process.Start();
                    StreamReader StreamRead = process.StandardOutput;
                    while (!process.HasExited)
                    {
                        if (!StreamRead.EndOfStream)
                        {
                            varProcessOutput = StreamRead.ReadToEnd();
                            // trying to do the control update directly will result in an invalid cross-thread operation exception
                            // instead, we invoke the control update on the window thread using this.Invoke(...)
                            //this.Invoke(new Action<string>(s => { lblCmdOutput.Text += s; }), procOutput);
                        }

                    }
                }
                catch (Exception e)
                {
                    ErrorOutString = e.Message;
                }
            }));
            RunCommadThread.Start();
        }  // End of run

        public string GetOutput()
        {
            return varProcessOutput;
        }

        public void CommandExecutableName(String CommandExecutableinput = null)
        {
            varCommandExecutable = CommandExecutableinput;
        }

        public void CommandArgument(String varProcessCommandNameInput)
        {
            varProcessCommandName = varProcessCommandNameInput;
        }

        public string RunningStatus()
        {
            return RunCommadThread.ThreadState.ToString();
        }

        public bool isRunCommandAlive()
        {
            return RunCommadThread.IsAlive;
        }
    }
}
