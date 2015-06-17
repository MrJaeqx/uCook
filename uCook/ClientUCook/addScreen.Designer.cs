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
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbAppliances = new System.Windows.Forms.ListBox();
            this.cbAppliances = new System.Windows.Forms.ComboBox();
            this.gbIngedients = new System.Windows.Forms.GroupBox();
            this.lbAmounts = new System.Windows.Forms.ListBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.lbIngredients = new System.Windows.Forms.ListBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbIngredient = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblIngredient = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.tbAction = new System.Windows.Forms.TextBox();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lbDurations = new System.Windows.Forms.ListBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.lbActions = new System.Windows.Forms.ListBox();
            this.gbIngedients.SuspendLayout();
            this.gbActions.SuspendLayout();
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
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(90, 13);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(648, 20);
            this.tbName.TabIndex = 1;
            // 
            // lbAppliances
            // 
            this.lbAppliances.FormattingEnabled = true;
            this.lbAppliances.Location = new System.Drawing.Point(276, 133);
            this.lbAppliances.Name = "lbAppliances";
            this.lbAppliances.Size = new System.Drawing.Size(114, 108);
            this.lbAppliances.TabIndex = 2;
            // 
            // cbAppliances
            // 
            this.cbAppliances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppliances.FormattingEnabled = true;
            this.cbAppliances.Location = new System.Drawing.Point(221, 80);
            this.cbAppliances.Name = "cbAppliances";
            this.cbAppliances.Size = new System.Drawing.Size(114, 21);
            this.cbAppliances.TabIndex = 3;
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
            this.gbIngedients.Location = new System.Drawing.Point(16, 40);
            this.gbIngedients.Name = "gbIngedients";
            this.gbIngedients.Size = new System.Drawing.Size(274, 209);
            this.gbIngedients.TabIndex = 4;
            this.gbIngedients.TabStop = false;
            this.gbIngedients.Text = "Ingedients";
            // 
            // lbAmounts
            // 
            this.lbAmounts.FormattingEnabled = true;
            this.lbAmounts.Location = new System.Drawing.Point(201, 93);
            this.lbAmounts.Name = "lbAmounts";
            this.lbAmounts.Size = new System.Drawing.Size(67, 108);
            this.lbAmounts.TabIndex = 6;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(6, 64);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(262, 23);
            this.btnAddIngredient.TabIndex = 5;
            this.btnAddIngredient.Text = "add ingredient";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // lbIngredients
            // 
            this.lbIngredients.FormattingEnabled = true;
            this.lbIngredients.Location = new System.Drawing.Point(6, 95);
            this.lbIngredients.Name = "lbIngredients";
            this.lbIngredients.Size = new System.Drawing.Size(189, 108);
            this.lbIngredients.TabIndex = 4;
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
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.label1);
            this.gbActions.Controls.Add(this.cbAppliances);
            this.gbActions.Controls.Add(this.tbDuration);
            this.gbActions.Controls.Add(this.lbAppliances);
            this.gbActions.Controls.Add(this.tbAction);
            this.gbActions.Controls.Add(this.btnAddAction);
            this.gbActions.Controls.Add(this.lblDuration);
            this.gbActions.Controls.Add(this.lbDurations);
            this.gbActions.Controls.Add(this.lblAction);
            this.gbActions.Controls.Add(this.lbActions);
            this.gbActions.Location = new System.Drawing.Point(296, 40);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(442, 254);
            this.gbActions.TabIndex = 6;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Action list";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(221, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 45);
            this.label1.TabIndex = 8;
            this.label1.Text = "Please select Appliance needed for this action.";
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(341, 80);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(95, 20);
            this.tbDuration.TabIndex = 6;
            // 
            // tbAction
            // 
            this.tbAction.Location = new System.Drawing.Point(9, 33);
            this.tbAction.Multiline = true;
            this.tbAction.Name = "tbAction";
            this.tbAction.Size = new System.Drawing.Size(206, 68);
            this.tbAction.TabIndex = 5;
            // 
            // btnAddAction
            // 
            this.btnAddAction.Location = new System.Drawing.Point(6, 107);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(430, 23);
            this.btnAddAction.TabIndex = 4;
            this.btnAddAction.Text = "add Action";
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(341, 29);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(95, 48);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Duration in minutes, leave blank if unknown";
            // 
            // lbDurations
            // 
            this.lbDurations.FormattingEnabled = true;
            this.lbDurations.Location = new System.Drawing.Point(396, 133);
            this.lbDurations.Name = "lbDurations";
            this.lbDurations.Size = new System.Drawing.Size(40, 108);
            this.lbDurations.TabIndex = 1;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(6, 16);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(37, 13);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Action";
            // 
            // lbActions
            // 
            this.lbActions.FormattingEnabled = true;
            this.lbActions.Location = new System.Drawing.Point(6, 133);
            this.lbActions.Name = "lbActions";
            this.lbActions.Size = new System.Drawing.Size(264, 108);
            this.lbActions.TabIndex = 0;
            // 
            // AddScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 299);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gbIngedients);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Name = "AddScreen";
            this.Text = "addScreen";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddScreen_FormClosing);
            this.gbIngedients.ResumeLayout(false);
            this.gbIngedients.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.gbActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ListBox lbAppliances;
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
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.TextBox tbAction;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.ListBox lbDurations;
        private System.Windows.Forms.ListBox lbActions;
        private System.Windows.Forms.Label label1;
    }
}