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
            this.findRecipeBtn = new System.Windows.Forms.Button();
            this.addRecipeBtn = new System.Windows.Forms.Button();
            this.removeRecipeBtn = new System.Windows.Forms.Button();
            this.lbResults = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // findRecipeBtn
            // 
            this.findRecipeBtn.Location = new System.Drawing.Point(238, 19);
            this.findRecipeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findRecipeBtn.Name = "findRecipeBtn";
            this.findRecipeBtn.Size = new System.Drawing.Size(56, 19);
            this.findRecipeBtn.TabIndex = 0;
            this.findRecipeBtn.Text = "find";
            this.findRecipeBtn.UseVisualStyleBackColor = true;
            this.findRecipeBtn.Click += new System.EventHandler(this.findRecipeBtn_Click);
            // 
            // addRecipeBtn
            // 
            this.addRecipeBtn.Location = new System.Drawing.Point(238, 42);
            this.addRecipeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addRecipeBtn.Name = "addRecipeBtn";
            this.addRecipeBtn.Size = new System.Drawing.Size(56, 19);
            this.addRecipeBtn.TabIndex = 1;
            this.addRecipeBtn.Text = "add";
            this.addRecipeBtn.UseVisualStyleBackColor = true;
            this.addRecipeBtn.Click += new System.EventHandler(this.addRecipeBtn_Click);
            // 
            // removeRecipeBtn
            // 
            this.removeRecipeBtn.Location = new System.Drawing.Point(238, 66);
            this.removeRecipeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.lbResults.Location = new System.Drawing.Point(9, 99);
            this.lbResults.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(186, 134);
            this.lbResults.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 5;
            // 
            // uCookClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 264);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.removeRecipeBtn);
            this.Controls.Add(this.addRecipeBtn);
            this.Controls.Add(this.findRecipeBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "uCookClient";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button findRecipeBtn;
        private System.Windows.Forms.Button addRecipeBtn;
        private System.Windows.Forms.Button removeRecipeBtn;
        private System.Windows.Forms.ListBox lbResults;
        private System.Windows.Forms.TextBox textBox1;
    }
}

