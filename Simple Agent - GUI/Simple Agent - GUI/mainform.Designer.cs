
namespace Simple_Agent___GUI
{
    partial class mainform
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainformTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.connectionFailed = new System.Windows.Forms.NotifyIcon(this.components);
            this.netTimer = new System.Windows.Forms.Timer(this.components);
            this.txt1 = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.iPToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 118);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(155, 38);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // iPToolStripMenuItem
            // 
            this.iPToolStripMenuItem.Name = "iPToolStripMenuItem";
            this.iPToolStripMenuItem.Size = new System.Drawing.Size(155, 38);
            this.iPToolStripMenuItem.Text = "IP:";
            this.iPToolStripMenuItem.Click += new System.EventHandler(this.iPToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 38);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainformTray
            // 
            this.mainformTray.ContextMenuStrip = this.contextMenuStrip1;
            this.mainformTray.Icon = ((System.Drawing.Icon)(resources.GetObject("mainformTray.Icon")));
            this.mainformTray.Text = "Simple Agent - Connected";
            // 
            // connectionFailed
            // 
            this.connectionFailed.ContextMenuStrip = this.contextMenuStrip1;
            this.connectionFailed.Icon = ((System.Drawing.Icon)(resources.GetObject("connectionFailed.Icon")));
            this.connectionFailed.Text = "Simple Agent - connection failed";
            this.connectionFailed.Visible = true;
            // 
            // netTimer
            // 
            this.netTimer.Enabled = true;
            this.netTimer.Interval = 3000;
            this.netTimer.Tick += new System.EventHandler(this.netTimer_Tick);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(30, 21);
            this.txt1.Multiline = true;
            this.txt1.Name = "txt1";
            this.txt1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt1.Size = new System.Drawing.Size(948, 375);
            this.txt1.TabIndex = 3;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 59);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(122, 419);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(70, 25);
            this.lb1.TabIndex = 5;
            this.lb1.Text = "label1";
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 538);
            this.ControlBox = false;
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "mainform";
            this.ShowInTaskbar = false;
            this.Text = "Simple Agent";
            this.Load += new System.EventHandler(this.mainform_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon mainformTray;
        private System.Windows.Forms.NotifyIcon connectionFailed;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer netTimer;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lb1;
    }
}