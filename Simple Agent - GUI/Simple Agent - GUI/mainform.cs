using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MyINIFile;
using Simple_Agent_GUI_RunCommand;


namespace Simple_Agent___GUI
{
    // [Guid("16589CA1-C06E-4A94-AA31-5D1F1AF06941")]
    public partial class mainform : Form
    {
        private string remoteHost = "8.8.8.8";
        private String iniFileName = "Settings.ini";
        private int ScriptDownloadMin = 1;
        RunCommand RC = new RunCommand();



        public mainform()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openAbout = new aboutform();
            openAbout.ShowDialog();
        }  // End of aboutToolStripMenuItem_Click

        private void mainform_Load(object sender, EventArgs e)
        {
            remoteHost = iniReadwithError("host", "remote");
            timer1.Interval = int.Parse(iniReadwithError("interval_ms", "Local"));
            iPToolStripMenuItem.Text = GetLocalIPAddress(iniReadwithError("IPSartWith", "Local"));
            if(!Directory.Exists(iniReadwithError("ScriptLocalLocation", "Local")))
            {
                Directory.CreateDirectory(iniReadwithError("ScriptLocalLocation", "Local"));
            }
            WriteToLog("Service started");
        }  // End of mainform_Load

        private void WriteToLog(String message)
        {
            String apppath = AppDomain.CurrentDomain.BaseDirectory + "SA-Log";
            if (!Directory.Exists(apppath))
            {
                Directory.CreateDirectory(apppath);
            }
            String LogFile = apppath + @"\SA-Log.log";
            FileInfo infoOfFile = new FileInfo(LogFile);
            if ((infoOfFile.Length >= 20480)&&(File.Exists(LogFile)))
            {
                File.Delete(LogFile);
            }
            StreamWriter LogWriter = File.AppendText(LogFile);
            infoOfFile = new FileInfo(LogFile);
            LogWriter.WriteLine(message + "      " + DateTime.Now + "     " + infoOfFile.Length + "B");
            LogWriter.Close();
        }  // End of WriteToLog

        private void WriteScriptLog(String scriptFileName, bool reWriteNewLogFile = false)
        {
            String LogFile = AppDomain.CurrentDomain.BaseDirectory + @"\ScriptLog.log";
            if (File.Exists(LogFile))
            {
                FileInfo infoOfFile = new FileInfo(LogFile);
                if (reWriteNewLogFile)
                {
                    File.Delete(LogFile);
                    return;
                }
                infoOfFile = new FileInfo(LogFile);
                StreamWriter LogWriter = File.AppendText(LogFile);
                infoOfFile = new FileInfo(LogFile);
                LogWriter.WriteLine(scriptFileName + "      " + DateTime.Now);
                LogWriter.Close();
            }
        }  // End of WriteScriptLog

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }  // End of exitToolStripMenuItem_Click

        private string GetLocalIPAddress(string IPmatch)
        {
            String IPtoList = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if(ip.ToString().StartsWith(IPmatch))
                //if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPtoList = IPtoList + ip.ToString() + "; ";
                }
            }
            return IPtoList;
        }  // End of GetLocalIPAddress

        private void timer1_Tick(object sender, EventArgs e)
        {
            ScriptDownloadMin++;
            try
            {
                if (ScriptDownloadMin >= int.Parse(iniReadwithError("ScripDownloadMin", "remote")))
                {
                    GetScripFiles();
                    ScriptDownloadMin = 1;

                }
            }
            catch(System.FormatException ex)
            {
                WriteToLog("Error: " + ex.Message);
            }
        }  // End of timer1_Tick

        private void iPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Clipboard.SetText(iPToolStripMenuItem.Text);
            MessageBox.Show("Your IP address Data\n\n"+iPToolStripMenuItem.Text+"\n\nis now copied to the memory.");
        }  // End of iPToolStripMenuItem_Click

        private string iniReadwithError(string Key,String Sec)
        {
            var MyIni = new IniFileClass(iniFileName);
            MyIni = new IniFileClass(iniFileName);
            string LocationRectifier = "";

            try 
            {
                LocationRectifier =  MyIni.Read(Key, Sec);
                if (LocationRectifier.EndsWith("\\")) return LocationRectifier.Remove(LocationRectifier.Length - 1, 1);
                else return LocationRectifier;
                //return MyIni.Read(Key, Sec);
            }
            catch (System.Exception ex)
            {
                WriteErrorLog(ex.ToString());
                return "Error";
            }

        }  // End of iniReadwithError

        private void WriteErrorLog(string ErrorMessage)
        {
            WriteToLog("Error: " + ErrorMessage);
        }  // End of WriteErrorLog

        private void tempGetScripFiles(string fileExtension = "ps1")
        {
            if (!Directory.Exists(iniReadwithError("ScriptRemoteLocation", "remote")))
            {
                WriteToLog("Script ");
                return;
            }
            //MessageBox.Show(iniReadwithError("ScriptRemoteLocation", "remote") + "\\" + Dns.GetHostName() + "*." + fileExtension);
            String[] FileList = Directory.GetFiles(iniReadwithError("ScriptRemoteLocation", "remote"),Dns.GetHostName() + "*." + fileExtension);
            if (FileList.Count() > 0)
            {
                foreach(var eachfile in FileList)
                {
                    if(!File.Exists(iniReadwithError("ScriptLocalLocation", "Local") + "\\" + Path.GetFileName(eachfile)))
                    {
                        File.Copy(eachfile, iniReadwithError("ScriptLocalLocation", "Local") + "\\" + Path.GetFileName(eachfile));
                    }
                        
                }
            }
            else
            {
                FileList = Directory.GetFiles(iniReadwithError("ScriptLocalLocation", "Local"), Dns.GetHostName() + "*." + fileExtension);
                if (FileList.Count() > 0)
                {
                    foreach(var eachFile in FileList)
                    {
                        File.Delete(eachFile);
                    }
                }
            }

            FileList = Directory.GetFiles(iniReadwithError("ScriptRemoteLocation", "remote"),"Script*." + fileExtension);
            if (FileList.Count() > 0)
            {
                foreach (var eachfile in FileList)
                {
                    if (!File.Exists(iniReadwithError("ScriptLocalLocation", "Local") + "\\" + Path.GetFileName(eachfile)))
                    {
                        File.Copy(eachfile, iniReadwithError("ScriptLocalLocation", "Local") + "\\" + Path.GetFileName(eachfile));
                    }
                }
            }
            else
            {
                FileList = Directory.GetFiles(iniReadwithError("ScriptLocalLocation", "Local"), "Script*." + fileExtension);
                if (FileList.Count() > 0)
                {
                    foreach (var eachFile in FileList)
                    {
                        File.Delete(eachFile);
                    }
                }
            }
        }  // End of tempGetScripFiles

        private void GetScripFiles()
        {
            if (Directory.Exists(iniReadwithError("ScriptRemoteLocation", "remote")))
            {
                string[] LocalFileList = Directory.GetFiles(iniReadwithError("ScriptLocalLocation", "Local"), "*.*");
                foreach(var f in LocalFileList) 
                {
                    if (!(f.ToLower().EndsWith("bat") || f.ToLower().EndsWith("ps1") || f.ToLower().EndsWith("vbs"))) //Delete anything not Script.
                    {
                        File.Delete(f);
                    }
                    else 
                    { 
                        if(!File.Exists(iniReadwithError("ScriptRemoteLocation", "remote") + "\\" + Path.GetFileName(f)))
                        {
                            File.Delete(f);
                        }
                    }
                }

                //txt1.Items.Add(DateTime.Now.ToString("yyyyMMddHH"));

                var varFileList = Directory.GetFiles(iniReadwithError("ScriptRemoteLocation", "remote"), "*.*").Where(s => s.ToLower().EndsWith(".bat") || s.ToLower().EndsWith(".ps1")|| s.ToLower().EndsWith(".vbs"));
                string[] remoteFileList = varFileList.ToArray();
                //string[] FileList = Directory.GetFiles(iniReadwithError("ScriptRemoteLocation", "remote"), "*.*");
                if (remoteFileList.Count() > 0)
                {
                    foreach(var f in remoteFileList)
                    {                      
                        var GetTheFileName = Path.GetFileName(f);
                        
                        if (!File.Exists(iniReadwithError("ScriptLocalLocation", "Local") + "\\" + GetTheFileName))
                        {
                            if (GetTheFileName.ToLower().Contains("daily")||GetTheFileName.ToLower().Contains(DateTime.Now.ToString("yyyy-MM-dd-HH"))|| GetTheFileName.ToLower().Contains(Dns.GetHostName().ToLower()))
                            {
                                File.Copy(f, iniReadwithError("ScriptLocalLocation", "Local") + "\\" + GetTheFileName);
                                
                            }
                            //txt1.Items.Add(GetTheFileName);
                        }
                    }
                }
                else 
                {
                    WriteToLog("Remote location is empty");
                    String[] LocalScriptFiles = Directory.GetFiles(iniReadwithError("ScriptLocalLocation", "Local"));
                    //foreach ( var LocalScriptFile in LocalScriptFiles) File.Delete(LocalScriptFile);
                    WriteToLog("Clean up local Scripts is done!");
                }
            }        
        }  // End of GetScripFiles

        private void netTimer_Tick(object sender, EventArgs e)
        {
            if(IsMachineUp(iniReadwithError("host", "remote")))
            {
                mainformTray.Visible = true;
                connectionFailed.Visible = false;

            }
            else
            {
                mainformTray.Visible = false;
                connectionFailed.Visible = true;
            }
        } // End of netTimer_Tick


        private bool IsMachineUp(string hostName)
        {
            bool retVal = false;
            try
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                // Use the default Ttl value which is 128,
                // but change the fragmentation behavior.
                options.DontFragment = true;
                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 5000;

                PingReply reply = pingSender.Send(hostName, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                retVal = false;
                Console.WriteLine(ex.Message);
            }
            return retVal;
        } // End of IsMachineUp


        private void showToast() 
        {

        }  // End of showToast

        private void timer2_Tick(object sender, EventArgs e)
        {
            lb1.Text = RC.RunningStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RC.CommandExecutableName("CMD.exe");
            RC.CommandArgument("dir /s c:");
            RC.run();
            txt1.Text = RC.GetOutput();
        }
    } //End of mainform

} // End of Simple_Agent___GUI
