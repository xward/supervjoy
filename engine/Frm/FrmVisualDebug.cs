using NsSupervJoy.engine;
using NsSupervJoy.Engine;
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

namespace NsSupervJoy
{
    public partial class FrmVisualDebug : Form
    {

        static PictureBox[] PictsAxis = new PictureBox[16];
        static Label[] LabelValueAxis = new Label[16];

        static Thread simulationThread = new Thread(() =>
                {
        });

        public FrmVisualDebug()
        {
            InitializeComponent();
        }

        private void FrmVisualDebug_Load(object sender, EventArgs e)
        {
            comboBoxSimulateOutput.Items.Clear();
            comboBoxSimulateOutput.Items.Add("Disabled");
            foreach (OutAxis axe in (OutAxis[])Enum.GetValues(typeof(OutAxis)))
            {
                comboBoxSimulateOutput.Items.Add("Simulate axis " + axe.ToString());
            }
            comboBoxSimulateOutput.SelectedIndex = 0;


            for (int a = 0; a < SuperVJoy.maxOutputAxisCountIWantToUse; a++)
            {
                PictureBox p = new PictureBox
                {
                    Parent = pictCurve,
                    Width = 10,
                    Height = 10,
                    BorderStyle = BorderStyle.Fixed3D,
                    BackColor = Color.Red 
                };
                PictsAxis[a] = p;
                Label l = new Label
                {
                    Parent = pictCurve,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Gray,
                    Font = new Font(FontFamily.GenericMonospace, 15)

                };
                LabelValueAxis[a] = l;
            }

            SuperVJoy.plzOutputToDebugFrm = true;
            pictCurve.Image = CurveTool.generateBitmapCurveAllAxis();
            TmrRefreshCurves.Enabled = true;
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SuperVJoy.plzOutputToDebugFrm = false;
            TmrRefreshCurves.Enabled = false;
        }

        private void displayDebugWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<string> events = new List<string>(SuperVJoy.debugFrmEvents);
            SuperVJoy.debugFrmEvents.Clear();

            foreach(string ename in events) {
                listBoxEventsLog.Items.Add(ename); // GOT AN NUL ITEM
            }
            listBoxEventsLog.SelectedIndex = listBoxEventsLog.Items.Count -1;
            int pad = SuperVJoy.MAX_RANGE / 256;



            int ii = 0;
            foreach (OutAxis axe in (OutAxis[])Enum.GetValues(typeof(OutAxis)))
            {
                PictureBox p = PictsAxis[ii];
                int y = (int)(1.0 * ii / 3);
                int x = (int)(1.0 * ii - y * 3);

                double outValue = SuperVJoy.vjoy.curValueOf(ii + 1);
                double inValue = SuperVJoy.debugFrmCurvedAxis[axe.ToString()];

                p.Left = pad * x + (int)(Math.Round(inValue) * pad / 100) - p.Width / 2;
                p.Top = pad * y + pad - (int)(Math.Round(outValue) * pad / 100) - p.Width / 2;

                LabelValueAxis[ii].Left = pad * x + pad - 70;
                LabelValueAxis[ii].Top = pad * y + pad - 25;
                LabelValueAxis[ii].Text = "" + String.Format("{0:n1}", Math.Round(SuperVJoy.vjoy.curValueOf(ii + 1) * 10) / 10) + "%";

                ii++;
                if (ii == SuperVJoy.maxOutputAxisCountIWantToUse) break;
            }

            lblLagDisplay.Text = "Engine overall lag=" + SuperVJoy.engineLag + " microsec " + SuperVJoy.processed;
        }

        private void comboBoxSimulateOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            simulationThread.Abort();
            if (comboBoxSimulateOutput.SelectedIndex > 0)
            {
                SuperVJoy.disable = true;

                OutAxis axisidx = (OutAxis) comboBoxSimulateOutput.SelectedIndex;
                int idx = comboBoxSimulateOutput.SelectedIndex;
                simulationThread = new Thread(() =>
                {
                    try
                    {
                        SimulateJoyOutputAxis(axisidx);
                    }
                    catch
                    {
                        vjoy.setAxisPerc(50, idx);
                        vjoy.applyValues();
                        Console.WriteLine("End!!!");
                    }
               
                });
                simulationThread.Start();
            }
            else
            {
                SuperVJoy.disable = false;
            }
        }
    }
}
