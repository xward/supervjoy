namespace SupervJoy.engine.Frm
{
    partial class FrmTrayIcon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrayIcon));
            this.notifyIconMainTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayDebugWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconMainTray
            // 
            this.notifyIconMainTray.ContextMenuStrip = this.contextMenuStripTrayIcon;
            this.notifyIconMainTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMainTray.Icon")));
            this.notifyIconMainTray.Text = "SupervJoy";
            this.notifyIconMainTray.Visible = true;
            // 
            // contextMenuStripTrayIcon
            // 
            this.contextMenuStripTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayDebugWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.helpToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStripTrayIcon.Name = "contextMenuStripTrayIcon";
            this.contextMenuStripTrayIcon.Size = new System.Drawing.Size(200, 98);
            // 
            // displayDebugWindowToolStripMenuItem
            // 
            this.displayDebugWindowToolStripMenuItem.Name = "displayDebugWindowToolStripMenuItem";
            this.displayDebugWindowToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.displayDebugWindowToolStripMenuItem.Text = "Show debug dashboard";
            this.displayDebugWindowToolStripMenuItem.Click += new System.EventHandler(this.displayDebugWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.githubPageToolStripMenuItem,
            this.discordToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.helpToolStripMenuItem.Text = "Help (v1.0.0)";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // githubPageToolStripMenuItem
            // 
            this.githubPageToolStripMenuItem.Name = "githubPageToolStripMenuItem";
            this.githubPageToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.githubPageToolStripMenuItem.Text = "Github page / Documentation";
            this.githubPageToolStripMenuItem.Click += new System.EventHandler(this.githubPageToolStripMenuItem_Click);
            // 
            // discordToolStripMenuItem
            // 
            this.discordToolStripMenuItem.Name = "discordToolStripMenuItem";
            this.discordToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.discordToolStripMenuItem.Text = "Discord";
            this.discordToolStripMenuItem.Click += new System.EventHandler(this.discordToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // FrmTrayIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(292, 169);
            this.Name = "FrmTrayIcon";
            this.Text = "FrmTrayIcon";
            this.Load += new System.EventHandler(this.FrmTrayIcon_Load);
            this.contextMenuStripTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NotifyIcon notifyIconMainTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem displayDebugWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}