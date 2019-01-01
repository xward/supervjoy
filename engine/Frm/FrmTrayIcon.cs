using NsSupervJoy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NsSupervJoy.Engine.SuperVJoy;

namespace SupervJoy.engine.Frm
{
    public partial class FrmTrayIcon : Form
    {
        public FrmTrayIcon()
        {
            InitializeComponent();
        }

        private void FrmTrayIcon_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void displayDebugWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Application.Run(new FrmVisualDebug());
            }).Start();
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/mp5Qu6");
        }

        private void githubPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xward/supervjoy");
        }

        private void displayFancyAxisVisualOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulateJoyOutputAxis(OutAxis.RZ);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
