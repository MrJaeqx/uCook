namespace Voorbeeldje
{
    partial class Form1
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
            this.readMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnArduino = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaster = new System.Windows.Forms.Label();
            this.timerDevReq = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // readMessageTimer
            // 
            this.readMessageTimer.Interval = 15;
            this.readMessageTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(135, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send!";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(12, 12);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(100, 20);
            this.tbSend.TabIndex = 1;
            // 
            // btnArduino
            // 
            this.btnArduino.Location = new System.Drawing.Point(239, 9);
            this.btnArduino.Name = "btnArduino";
            this.btnArduino.Size = new System.Drawing.Size(72, 69);
            this.btnArduino.TabIndex = 3;
            this.btnArduino.Text = "Arduino knop";
            this.btnArduino.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 117);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(113, 186);
            this.listBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // lblMaster
            // 
            this.lblMaster.AutoSize = true;
            this.lblMaster.ForeColor = System.Drawing.Color.Red;
            this.lblMaster.Location = new System.Drawing.Point(13, 75);
            this.lblMaster.Name = "lblMaster";
            this.lblMaster.Size = new System.Drawing.Size(73, 13);
            this.lblMaster.TabIndex = 7;
            this.lblMaster.Text = "Master offline.";
            // 
            // timerDevReq
            // 
            this.timerDevReq.Interval = 5000;
            this.timerDevReq.Tick += new System.EventHandler(this.timerDevReq_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(322, 315);
            this.Controls.Add(this.lblMaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnArduino);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.btnSend);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer readMessageTimer;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btnArduino;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaster;
        private System.Windows.Forms.Timer timerDevReq;
    }
}

