namespace ClientUCook
{
    partial class AddScreen
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
            this.lblName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbAppliances = new System.Windows.Forms.ListBox();
            this.gbAppliances = new System.Windows.Forms.GroupBox();
            this.cbAppliances = new System.Windows.Forms.ComboBox();
            this.gbIngedients = new System.Windows.Forms.GroupBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbIngredient = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblIngredient = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbIngredients = new System.Windows.Forms.ListBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.lbAmounts = new System.Windows.Forms.ListBox();
            this.gbAppliances.SuspendLayout();
            this.gbIngedients.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Recipe name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(334, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lbAppliances
            // 
            this.lbAppliances.FormattingEnabled = true;
            this.lbAppliances.Location = new System.Drawing.Point(7, 44);
            this.lbAppliances.Name = "lbAppliances";
            this.lbAppliances.Size = new System.Drawing.Size(114, 160);
            this.lbAppliances.TabIndex = 2;
            // 
            // gbAppliances
            // 
            this.gbAppliances.Controls.Add(this.cbAppliances);
            this.gbAppliances.Controls.Add(this.lbAppliances);
            this.gbAppliances.Location = new System.Drawing.Point(16, 39);
            this.gbAppliances.Name = "gbAppliances";
            this.gbAppliances.Size = new System.Drawing.Size(127, 210);
            this.gbAppliances.TabIndex = 3;
            this.gbAppliances.TabStop = false;
            this.gbAppliances.Text = "Appliances";
            // 
            // cbAppliances
            // 
            this.cbAppliances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppliances.FormattingEnabled = true;
            this.cbAppliances.Items.AddRange(new object[] {
            "uCook kookpan",
            "uCook braadpan",
            "uCook waterkoker"});
            this.cbAppliances.Location = new System.Drawing.Point(7, 20);
            this.cbAppliances.Name = "cbAppliances";
            this.cbAppliances.Size = new System.Drawing.Size(114, 21);
            this.cbAppliances.TabIndex = 3;
            this.cbAppliances.SelectionChangeCommitted += new System.EventHandler(this.Appliances_SelectionChangeCommitted);
            // 
            // gbIngedients
            // 
            this.gbIngedients.Controls.Add(this.lbAmounts);
            this.gbIngedients.Controls.Add(this.btnAddIngredient);
            this.gbIngedients.Controls.Add(this.lbIngredients);
            this.gbIngedients.Controls.Add(this.tbAmount);
            this.gbIngedients.Controls.Add(this.tbIngredient);
            this.gbIngedients.Controls.Add(this.lblAmount);
            this.gbIngedients.Controls.Add(this.lblIngredient);
            this.gbIngedients.Location = new System.Drawing.Point(150, 40);
            this.gbIngedients.Name = "gbIngedients";
            this.gbIngedients.Size = new System.Drawing.Size(274, 209);
            this.gbIngedients.TabIndex = 4;
            this.gbIngedients.TabStop = false;
            this.gbIngedients.Text = "Ingedients";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(201, 38);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(67, 20);
            this.tbAmount.TabIndex = 3;
            // 
            // tbIngredient
            // 
            this.tbIngredient.Location = new System.Drawing.Point(7, 37);
            this.tbIngredient.Name = "tbIngredient";
            this.tbIngredient.Size = new System.Drawing.Size(188, 20);
            this.tbIngredient.TabIndex = 2;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(225, 22);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "Amount";
            // 
            // lblIngredient
            // 
            this.lblIngredient.AutoSize = true;
            this.lblIngredient.Location = new System.Drawing.Point(7, 20);
            this.lblIngredient.Name = "lblIngredient";
            this.lblIngredient.Size = new System.Drawing.Size(54, 13);
            this.lblIngredient.TabIndex = 0;
            this.lblIngredient.Text = "Ingredient";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(16, 255);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(127, 39);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // lbIngredients
            // 
            this.lbIngredients.FormattingEnabled = true;
            this.lbIngredients.Location = new System.Drawing.Point(6, 95);
            this.lbIngredients.Name = "lbIngredients";
            this.lbIngredients.Size = new System.Drawing.Size(189, 108);
            this.lbIngredients.TabIndex = 4;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(10, 64);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(258, 23);
            this.btnAddIngredient.TabIndex = 5;
            this.btnAddIngredient.Text = "add ingredient";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            // 
            // lbAmounts
            // 
            this.lbAmounts.FormattingEnabled = true;
            this.lbAmounts.Location = new System.Drawing.Point(201, 93);
            this.lbAmounts.Name = "lbAmounts";
            this.lbAmounts.Size = new System.Drawing.Size(67, 108);
            this.lbAmounts.TabIndex = 6;
            // 
            // AddScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 306);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gbIngedients);
            this.Controls.Add(this.gbAppliances);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblName);
            this.Name = "AddScreen";
            this.Text = "addScreen";
            this.TopMost = true;
            this.gbAppliances.ResumeLayout(false);
            this.gbIngedients.ResumeLayout(false);
            this.gbIngedients.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lbAppliances;
        private System.Windows.Forms.GroupBox gbAppliances;
        private System.Windows.Forms.ComboBox cbAppliances;
        private System.Windows.Forms.GroupBox gbIngedients;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.TextBox tbIngredient;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblIngredient;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ListBox lbAmounts;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.ListBox lbIngredients;
    }
}