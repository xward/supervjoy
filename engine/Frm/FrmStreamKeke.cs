using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupervJoy.engine.Frm
{
    public partial class FrmStreamKeke : Form
    {
        public FrmStreamKeke()
        {
            InitializeComponent();
        }

        private void FrmStreamKeke_Load(object sender, EventArgs e)
        {
            int size = 128;

            Bitmap img = new Bitmap(size, size);
            Graphics g =  Graphics.FromImage(img);
            // paint it black
            // g.FillRectangle(new SolidBrush(Color.FromArgb( ), new Rectangle(0, 0, img.Width, img.Height));
      

            int innerRoll = 6;
            g.DrawEllipse(new Pen(Color.CornflowerBlue, 3), new Rectangle(innerRoll, innerRoll, size-1- innerRoll * 2, size-1- innerRoll * 2));

            g.DrawLine(new Pen(Color.Gray, 5), new Point(0, size / 2), new Point(size - 1, size / 2));
            g.DrawLine(new Pen(Color.Gray, 5), new Point(size / 2, 0), new Point(size / 2, size - 1));


            pictureBoxPitchYawRoll.Image = img;
            pictureBoxAim.Image = img;



            panelPitchYaw.Parent = pictureBoxPitchYawRoll;
            panelRoll.Parent = pictureBoxPitchYawRoll;
            panelStrafes.Parent = pictureBoxStrafe;

            panelMainGaz.Parent = panelT;
            panelMainGaz.Width = panelT.Width;
            panelMainGaz.Left = 0;

            panelAim.Parent = pictureBoxAim;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double pitch = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(4);
            double roll = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(5);
            double yaw = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(6);

            panelPitchYaw.Left = pictureBoxPitchYawRoll.Width / 2 - panelPitchYaw.Width / 2 + (int) ((1.0 * yaw / 100.0 - 0.5) * pictureBoxPitchYawRoll.Width);
            panelPitchYaw.Top = pictureBoxPitchYawRoll.Height - (pictureBoxPitchYawRoll.Height / 2 + panelPitchYaw.Height / 2 + (int)((1.0 * pitch / 100.0 - 0.5) * pictureBoxPitchYawRoll.Height));

            panelRoll.Left = pictureBoxPitchYawRoll.Width / 2 - panelRoll.Width / 2 + (int)((1.0 * roll / 100.0 - 0.5) * pictureBoxPitchYawRoll.Width);
            panelRoll.Top = 15;

            double strafeLR = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(1);
           
            double strafeUD = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(3);

            panelStrafes.Left = pictureBoxStrafe.Width / 2 - panelStrafes.Width / 2 + (int)((1.0 * strafeLR / 100.0 - 0.5) * pictureBoxStrafe.Width);
            panelStrafes.Top = pictureBoxStrafe.Height -  (pictureBoxStrafe.Height / 2 + panelStrafes.Height / 2 + (int)((1.0 * strafeUD / 100.0 - 0.5) * pictureBoxStrafe.Height));

            double strafeFB = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(2);
            double gaz = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(7);

            if (gaz == 0)
                gaz = strafeFB;
            else
                gaz = gaz / 2 + 50;

            if (gaz > 50)
            {
                panelMainGaz.Top = (int)( (100.0-gaz) * (panelT.Height / 2) / 50.0);
                panelMainGaz.Height = panelT.Height / 2 - panelMainGaz.Top;
            }
            else
            {
                panelMainGaz.Top = panelT.Height /2;
                panelMainGaz.Height =(int)((50.0 - gaz) * (panelT.Height / 2) / 50.0);
            }

            double aimYaw = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(8);
            double aimPitch = NsSupervJoy.Engine.SuperVJoy.vjoy.curValueOf(9);

            panelAim.Left = pictureBoxAim.Width / 2 - panelAim.Width / 2 + (int)((1.0 * aimYaw / 100.0 - 0.5) * pictureBoxAim.Width);
            panelAim.Top = pictureBoxAim.Height - (pictureBoxAim.Height / 2 + panelAim.Height / 2 + (int)((1.0 * aimPitch / 100.0 - 0.5) * pictureBoxAim.Height));

        }
    }
}
