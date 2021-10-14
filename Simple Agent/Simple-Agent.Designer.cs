
namespace Simple_Agent
{
    partial class Service1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Service1));
            this.Connecting = new System.Windows.Forms.NotifyIcon(this.components);
            this.NetConnected = new System.Windows.Forms.NotifyIcon(this.components);
            this.NetFailed = new System.Windows.Forms.NotifyIcon(this.components);
            this.Looptimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutForm = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            // 
            // Connecting
            // 
            this.Connecting.ContextMenuStrip = this.contextMenuStrip1;
            this.Connecting.Icon = ((System.Drawing.Icon)(resources.GetObject("Connecting.Icon")));
            this.Connecting.Text = "Connecting...";
            this.Connecting.Visible = true;
            // 
            // NetConnected
            // 
            this.NetConnected.ContextMenuStrip = this.contextMenuStrip1;
            this.NetConnected.Icon = ((System.Drawing.Icon)(resources.GetObject("NetConnected.Icon")));
            this.NetConnected.Text = "Simple Agent";
            // 
            // NetFailed
            // 
            this.NetFailed.ContextMenuStrip = this.contextMenuStrip1;
            this.NetFailed.Icon = ((System.Drawing.Icon)(resources.GetObject("NetFailed.Icon")));
            this.NetFailed.Text = "Connection failed!";
            // 
            // Looptimer
            // 
            this.Looptimer.Interval = 2000;
            this.Looptimer.Tick += new System.EventHandler(this.Looptimer_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenu,
            this.aboutForm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 80);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(155, 38);
            this.exitMenu.Text = "E&xit";
            // 
            // aboutForm
            // 
            this.aboutForm.Name = "aboutForm";
            this.aboutForm.Size = new System.Drawing.Size(155, 38);
            this.aboutForm.Text = "&About";
            // 
            // Service1
            // 
            this.ServiceName = "Service1";
            this.contextMenuStrip1.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Connecting;
        private System.Windows.Forms.NotifyIcon NetConnected;
        private System.Windows.Forms.NotifyIcon NetFailed;
        private System.Windows.Forms.Timer Looptimer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutForm;
    }
}
