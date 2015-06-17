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
            this.serialPortSelectionBox = new System.Windows.Forms.ComboBox();
            this.scanSerialPorts = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.readMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // serialPortSelectionBox
            // 
            this.serialPortSelectionBox.FormattingEnabled = true;
            this.serialPortSelectionBox.Location = new System.Drawing.Point(96, 12);
            this.serialPortSelectionBox.Name = "serialPortSelectionBox";
            this.serialPortSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.serialPortSelectionBox.TabIndex = 5;
            // 
            // scanSerialPorts
            // 
            this.scanSerialPorts.Location = new System.Drawing.Point(15, 12);
            this.scanSerialPorts.Name = "scanSerialPorts";
            this.scanSerialPorts.Size = new System.Drawing.Size(75, 23);
            this.scanSerialPorts.TabIndex = 6;
            this.scanSerialPorts.Text = "Scan ports";
            this.scanSerialPorts.UseVisualStyleBackColor = true;
            this.scanSerialPorts.Click += new System.EventHandler(this.button1_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(223, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 7;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // readMessageTimer
            // 
            this.readMessageTimer.Interval = 15;
            this.readMessageTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 56);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.scanSerialPorts);
            this.Controls.Add(this.serialPortSelectionBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox serialPortSelectionBox;
        private System.Windows.Forms.Button scanSerialPorts;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Timer readMessageTimer;
    }
}

