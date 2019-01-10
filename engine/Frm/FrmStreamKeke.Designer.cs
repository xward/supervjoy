namespace SupervJoy.engine.Frm
{
    partial class FrmStreamKeke
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStreamKeke));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxPitchYawRoll = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxStrafe = new System.Windows.Forms.PictureBox();
            this.panelT = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxAim = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPitchYaw = new System.Windows.Forms.Panel();
            this.panelRoll = new System.Windows.Forms.Panel();
            this.panelStrafes = new System.Windows.Forms.Panel();
            this.panelMainGaz = new System.Windows.Forms.Panel();
            this.panelAim = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPitchYawRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStrafe)).BeginInit();
            this.panelT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAim)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 35;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBoxPitchYawRoll
            // 
            this.pictureBoxPitchYawRoll.Location = new System.Drawing.Point(89, 14);
            this.pictureBoxPitchYawRoll.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.pictureBoxPitchYawRoll.Name = "pictureBoxPitchYawRoll";
            this.pictureBoxPitchYawRoll.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxPitchYawRoll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPitchYawRoll.TabIndex = 0;
            this.pictureBoxPitchYawRoll.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "YAW";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "PITCH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(11, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "ROLL";
            // 
            // pictureBoxStrafe
            // 
            this.pictureBoxStrafe.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStrafe.Image")));
            this.pictureBoxStrafe.Location = new System.Drawing.Point(239, 42);
            this.pictureBoxStrafe.Name = "pictureBoxStrafe";
            this.pictureBoxStrafe.Size = new System.Drawing.Size(286, 100);
            this.pictureBoxStrafe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxStrafe.TabIndex = 4;
            this.pictureBoxStrafe.TabStop = false;
            // 
            // panelT
            // 
            this.panelT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelT.Controls.Add(this.panelMainGaz);
            this.panelT.Location = new System.Drawing.Point(557, 14);
            this.panelT.Name = "panelT";
            this.panelT.Size = new System.Drawing.Size(75, 128);
            this.panelT.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(333, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "STRAFES";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(639, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "MAIN";
            // 
            // pictureBoxAim
            // 
            this.pictureBoxAim.Location = new System.Drawing.Point(742, 14);
            this.pictureBoxAim.Name = "pictureBoxAim";
            this.pictureBoxAim.Size = new System.Drawing.Size(140, 128);
            this.pictureBoxAim.TabIndex = 8;
            this.pictureBoxAim.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(888, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "AIM";
            // 
            // panelPitchYaw
            // 
            this.panelPitchYaw.BackColor = System.Drawing.Color.Lime;
            this.panelPitchYaw.Location = new System.Drawing.Point(129, 78);
            this.panelPitchYaw.Name = "panelPitchYaw";
            this.panelPitchYaw.Size = new System.Drawing.Size(12, 12);
            this.panelPitchYaw.TabIndex = 10;
            // 
            // panelRoll
            // 
            this.panelRoll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelRoll.Location = new System.Drawing.Point(135, 31);
            this.panelRoll.Name = "panelRoll";
            this.panelRoll.Size = new System.Drawing.Size(10, 10);
            this.panelRoll.TabIndex = 11;
            // 
            // panelStrafes
            // 
            this.panelStrafes.BackColor = System.Drawing.Color.Lime;
            this.panelStrafes.Location = new System.Drawing.Point(359, 81);
            this.panelStrafes.Name = "panelStrafes";
            this.panelStrafes.Size = new System.Drawing.Size(12, 12);
            this.panelStrafes.TabIndex = 12;
            // 
            // panelMainGaz
            // 
            this.panelMainGaz.BackColor = System.Drawing.Color.Red;
            this.panelMainGaz.Location = new System.Drawing.Point(22, 37);
            this.panelMainGaz.Name = "panelMainGaz";
            this.panelMainGaz.Size = new System.Drawing.Size(18, 31);
            this.panelMainGaz.TabIndex = 0;
            // 
            // panelAim
            // 
            this.panelAim.BackColor = System.Drawing.Color.Red;
            this.panelAim.Location = new System.Drawing.Point(793, 53);
            this.panelAim.Name = "panelAim";
            this.panelAim.Size = new System.Drawing.Size(12, 12);
            this.panelAim.TabIndex = 13;
            // 
            // FrmStreamKeke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(939, 148);
            this.Controls.Add(this.panelAim);
            this.Controls.Add(this.panelStrafes);
            this.Controls.Add(this.panelRoll);
            this.Controls.Add(this.panelPitchYaw);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBoxAim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelT);
            this.Controls.Add(this.pictureBoxStrafe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxPitchYawRoll);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "FrmStreamKeke";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStreamKeke";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.FrmStreamKeke_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPitchYawRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStrafe)).EndInit();
            this.panelT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBoxPitchYawRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxStrafe;
        private System.Windows.Forms.Panel panelT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxAim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelPitchYaw;
        private System.Windows.Forms.Panel panelRoll;
        private System.Windows.Forms.Panel panelStrafes;
        private System.Windows.Forms.Panel panelMainGaz;
        private System.Windows.Forms.Panel panelAim;
    }
}