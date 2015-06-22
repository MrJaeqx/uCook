namespace ClientUCook
{
    partial class TimeLineClient
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
            this.btnNext = new System.Windows.Forms.Button();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.tbNext = new System.Windows.Forms.TextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.readMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.durationTimer = new System.Windows.Forms.Timer(this.components);
            this.updateAppliancesTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(214, 226);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(58, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbCurrent
            // 
            this.tbCurrent.Enabled = false;
            this.tbCurrent.Location = new System.Drawing.Point(12, 42);
            this.tbCurrent.Multiline = true;
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.Size = new System.Drawing.Size(120, 165);
            this.tbCurrent.TabIndex = 1;
            // 
            // tbNext
            // 
            this.tbNext.Enabled = false;
            this.tbNext.Location = new System.Drawing.Point(152, 42);
            this.tbNext.Multiline = true;
            this.tbNext.Name = "tbNext";
            this.tbNext.Size = new System.Drawing.Size(120, 165);
            this.tbNext.TabIndex = 2;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(40, 13);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(64, 13);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "Current step";
            // 
            // lblNext
            // 
            this.lblNext.AutoSize = true;
            this.lblNext.Location = new System.Drawing.Point(194, 13);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(52, 13);
            this.lblNext.TabIndex = 4;
            this.lblNext.Text = "Next step";
            // 
            // readMessageTimer
            // 
            this.readMessageTimer.Interval = 15;
            this.readMessageTimer.Tick += new System.EventHandler(this.readMessageTimer_Tick);
            // 
            // tbDuration
            // 
            this.tbDuration.Enabled = false;
            this.tbDuration.Location = new System.Drawing.Point(12, 226);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(196, 20);
            this.tbDuration.TabIndex = 5;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(31, 210);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(78, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Time remaining";
            // 
            // durationTimer
            // 
            this.durationTimer.Interval = 60000;
            this.durationTimer.Tick += new System.EventHandler(this.durationTimer_Tick);
            // 
            // updateAppliancesTimer
            // 
            this.updateAppliancesTimer.Interval = 500;
            this.updateAppliancesTimer.Tick += new System.EventHandler(this.updateAppliancesTimer_Tick);
            // 
            // TimeLineClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.tbNext);
            this.Controls.Add(this.tbCurrent);
            this.Controls.Add(this.btnNext);
            this.Name = "TimeLineClient";
            this.Text = "TimeLineClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TimeLineClient_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox tbCurrent;
        private System.Windows.Forms.TextBox tbNext;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Timer readMessageTimer;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer durationTimer;
        private System.Windows.Forms.Timer updateAppliancesTimer;
    }
}