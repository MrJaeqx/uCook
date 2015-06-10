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
            this.btnFindRecipe = new System.Windows.Forms.Button();
            this.addRecipeBtn = new System.Windows.Forms.Button();
            this.lbResults = new System.Windows.Forms.ListBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.readMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.btnChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFindRecipe
            // 
            this.btnFindRecipe.Location = new System.Drawing.Point(210, 32);
            this.btnFindRecipe.Margin = new System.Windows.Forms.Padding(2);
            this.btnFindRecipe.Name = "btnFindRecipe";
            this.btnFindRecipe.Size = new System.Drawing.Size(95, 19);
            this.btnFindRecipe.TabIndex = 0;
            this.btnFindRecipe.Text = "Find recipe";
            this.btnFindRecipe.UseVisualStyleBackColor = true;
            this.btnFindRecipe.Click += new System.EventHandler(this.findRecipeBtn_Click);
            // 
            // addRecipeBtn
            // 
            this.addRecipeBtn.Location = new System.Drawing.Point(11, 237);
            this.addRecipeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addRecipeBtn.Name = "addRecipeBtn";
            this.addRecipeBtn.Size = new System.Drawing.Size(294, 19);
            this.addRecipeBtn.TabIndex = 1;
            this.addRecipeBtn.Text = "Add new recipe";
            this.addRecipeBtn.UseVisualStyleBackColor = true;
            this.addRecipeBtn.Click += new System.EventHandler(this.addRecipeBtn_Click);
            // 
            // lbResults
            // 
            this.lbResults.FormattingEnabled = true;
            this.lbResults.Location = new System.Drawing.Point(9, 60);
            this.lbResults.Margin = new System.Windows.Forms.Padding(2);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(186, 173);
            this.lbResults.TabIndex = 4;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(9, 32);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(186, 20);
            this.tbSearch.TabIndex = 5;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(199, 192);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(106, 41);
            this.btnChoose.TabIndex = 8;
            this.btnChoose.Text = "Choose recipe";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // uCookClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 264);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.addRecipeBtn);
            this.Controls.Add(this.btnFindRecipe);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "uCookClient";
            this.Text = "uCookClient";
            this.EnabledChanged += new System.EventHandler(this.uCookClient_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindRecipe;
        private System.Windows.Forms.Button addRecipeBtn;
        private System.Windows.Forms.ListBox lbResults;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Timer readMessageTimer;
        private System.Windows.Forms.Button btnChoose;
    }
}

