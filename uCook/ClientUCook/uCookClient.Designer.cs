namespace ClientUCook
{
    partial class uCookClient
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
            this.findRecipeBtn = new System.Windows.Forms.Button();
            this.addRecipeBtn = new System.Windows.Forms.Button();
            this.removeRecipeBtn = new System.Windows.Forms.Button();
            this.lbResults = new System.Windows.Forms.ListBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.messageReceiveTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // findRecipeBtn
            // 
            this.findRecipeBtn.Location = new System.Drawing.Point(227, 11);
            this.findRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.findRecipeBtn.Name = "findRecipeBtn";
            this.findRecipeBtn.Size = new System.Drawing.Size(56, 19);
            this.findRecipeBtn.TabIndex = 0;
            this.findRecipeBtn.Text = "find";
            this.findRecipeBtn.UseVisualStyleBackColor = true;
            this.findRecipeBtn.Click += new System.EventHandler(this.findRecipeBtn_Click);
            // 
            // addRecipeBtn
            // 
            this.addRecipeBtn.Location = new System.Drawing.Point(227, 35);
            this.addRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addRecipeBtn.Name = "addRecipeBtn";
            this.addRecipeBtn.Size = new System.Drawing.Size(56, 19);
            this.addRecipeBtn.TabIndex = 1;
            this.addRecipeBtn.Text = "add";
            this.addRecipeBtn.UseVisualStyleBackColor = true;
            this.addRecipeBtn.Click += new System.EventHandler(this.addRecipeBtn_Click);
            // 
            // removeRecipeBtn
            // 
            this.removeRecipeBtn.Location = new System.Drawing.Point(227, 58);
            this.removeRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.removeRecipeBtn.Name = "removeRecipeBtn";
            this.removeRecipeBtn.Size = new System.Drawing.Size(56, 19);
            this.removeRecipeBtn.TabIndex = 2;
            this.removeRecipeBtn.Text = "remove";
            this.removeRecipeBtn.UseVisualStyleBackColor = true;
            this.removeRecipeBtn.Click += new System.EventHandler(this.removeRecipeBtn_Click);
            // 
            // lbResults
            // 
            this.lbResults.FormattingEnabled = true;
            this.lbResults.Location = new System.Drawing.Point(9, 35);
            this.lbResults.Margin = new System.Windows.Forms.Padding(2);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(186, 212);
            this.lbResults.TabIndex = 4;
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(9, 11);
            this.tbInput.Margin = new System.Windows.Forms.Padding(2);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(186, 20);
            this.tbInput.TabIndex = 5;
            // 
            // messageReceiveTimer
            // 
            this.messageReceiveTimer.Tick += new System.EventHandler(this.messageReceiveTimer_Tick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(227, 81);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(56, 19);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // uCookClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 264);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.removeRecipeBtn);
            this.Controls.Add(this.addRecipeBtn);
            this.Controls.Add(this.findRecipeBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uCookClient";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.uCookClient_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findRecipeBtn;
        private System.Windows.Forms.Button addRecipeBtn;
        private System.Windows.Forms.Button removeRecipeBtn;
        private System.Windows.Forms.ListBox lbResults;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Timer messageReceiveTimer;
        private System.Windows.Forms.Button btnSend;
    }
}

