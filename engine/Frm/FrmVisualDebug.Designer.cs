namespace NsSupervJoy
{
    partial class FrmVisualDebug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualDebug));
            this.TmrRefreshCurves = new System.Windows.Forms.Timer(this.components);
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblLagDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSimulateOutput = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxEventsLog = new System.Windows.Forms.ListBox();
            this.listBoxLastInputs = new System.Windows.Forms.ListBox();
            this.panelMainRight = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictCurve = new System.Windows.Forms.PictureBox();
            this.panelLeft.SuspendLayout();
            this.panelMainRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictCurve)).BeginInit();
            this.SuspendLayout();
            // 
            // TmrRefreshCurves
            // 
            this.TmrRefreshCurves.Interval = 15;
            this.TmrRefreshCurves.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblLagDisplay);
            this.panelLeft.Controls.Add(this.label3);
            this.panelLeft.Controls.Add(this.comboBoxSimulateOutput);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Controls.Add(this.listBoxEventsLog);
            this.panelLeft.Controls.Add(this.listBoxLastInputs);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(254, 801);
            this.panelLeft.TabIndex = 2;
            // 
            // lblLagDisplay
            // 
            this.lblLagDisplay.AutoSize = true;
            this.lblLagDisplay.ForeColor = System.Drawing.Color.White;
            this.lblLagDisplay.Location = new System.Drawing.Point(23, 14);
            this.lblLagDisplay.Name = "lblLagDisplay";
            this.lblLagDisplay.Size = new System.Drawing.Size(27, 13);
            this.lblLagDisplay.TabIndex = 6;
            this.lblLagDisplay.Text = "lag=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Simulate output axis (for in game configuration)";
            // 
            // comboBoxSimulateOutput
            // 
            this.comboBoxSimulateOutput.FormattingEnabled = true;
            this.comboBoxSimulateOutput.Location = new System.Drawing.Point(12, 64);
            this.comboBoxSimulateOutput.Name = "comboBoxSimulateOutput";
            this.comboBoxSimulateOutput.Size = new System.Drawing.Size(232, 21);
            this.comboBoxSimulateOutput.TabIndex = 4;
            this.comboBoxSimulateOutput.SelectedIndexChanged += new System.EventHandler(this.comboBoxSimulateOutput_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Events log :";
            // 
            // listBoxEventsLog
            // 
            this.listBoxEventsLog.FormattingEnabled = true;
            this.listBoxEventsLog.Location = new System.Drawing.Point(12, 536);
            this.listBoxEventsLog.Name = "listBoxEventsLog";
            this.listBoxEventsLog.Size = new System.Drawing.Size(232, 251);
            this.listBoxEventsLog.TabIndex = 2;
            // 
            // listBoxLastInputs
            // 
            this.listBoxLastInputs.FormattingEnabled = true;
            this.listBoxLastInputs.Location = new System.Drawing.Point(12, 124);
            this.listBoxLastInputs.Name = "listBoxLastInputs";
            this.listBoxLastInputs.Size = new System.Drawing.Size(232, 381);
            this.listBoxLastInputs.TabIndex = 0;
            this.listBoxLastInputs.Visible = false;
            // 
            // panelMainRight
            // 
            this.panelMainRight.Controls.Add(this.label2);
            this.panelMainRight.Controls.Add(this.pictCurve);
            this.panelMainRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainRight.Location = new System.Drawing.Point(254, 0);
            this.panelMainRight.Name = "panelMainRight";
            this.panelMainRight.Size = new System.Drawing.Size(784, 801);
            this.panelMainRight.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output and Curves";
            // 
            // pictCurve
            // 
            this.pictCurve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictCurve.Location = new System.Drawing.Point(6, 23);
            this.pictCurve.Name = "pictCurve";
            this.pictCurve.Size = new System.Drawing.Size(775, 775);
            this.pictCurve.TabIndex = 3;
            this.pictCurve.TabStop = false;
            // 
            // FrmVisualDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1038, 801);
            this.Controls.Add(this.panelMainRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmVisualDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SupervJoy Debug Window";
            this.Load += new System.EventHandler(this.FrmVisualDebug_Load);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelMainRight.ResumeLayout(false);
            this.panelMainRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictCurve)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TmrRefreshCurves;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelMainRight;
        private System.Windows.Forms.PictureBox pictCurve;
        private System.Windows.Forms.ListBox listBoxLastInputs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxEventsLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSimulateOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLagDisplay;
    }
}

