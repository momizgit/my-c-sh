using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Agent___GUI
{
    public partial class loadingForm : Form
    {
        public loadingForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var mainFormvar = new mainform();
            
            if (!File.Exists("Settings.ini"))
            {
                using (StreamWriter LogWriter = File.CreateText("Settings.ini"))
                {
                    LogWriter.WriteLine("[Local]\ninterval_ms=2000\nIPSartWith=1\nScriptLocalLocation=C:\\Temp\\SimpleAgent\n[remote]\nhost=8.8.8.8\nScriptRemoteLocation=\nScripDownloadMin=1");
                    LogWriter.Close();
                }
            }
            this.Hide();
            mainFormvar.Show();
            timer1.Enabled = false;
            loadingTray.Visible = false;
        }

        private void loadingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
