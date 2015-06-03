using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUCook
{
    public partial class AddScreen : Form
    {
        private uCookContract.Recipe recipe;

        public AddScreen()
        {
            InitializeComponent();
            recipe = new uCookContract.Recipe();
        }

        private void Appliances_SelectionChangeCommitted(object sender, EventArgs e)
        {
            bool unique = true;

            for (int i = 0; i < lbAppliances.Items.Count; i++)
            {  
                if(lbAppliances.Items[i].ToString() == cbAppliances.SelectedItem.ToString())
                {
                    unique = false;
                }
            }

            if(unique)
            {
                lbAppliances.Items.Add(cbAppliances.SelectedItem);
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(tbIngredient.Text))
            {
                MessageBox.Show("Please enter an ingredient");
            }
            else if(String.IsNullOrWhiteSpace(tbAmount.Text))
            {
                MessageBox.Show("Please enter the required amount");
            }
            else
            {
                lbIngredients.Items.Add(tbIngredient.Text);
                tbIngredient.Text = "";
                lbAmounts.Items.Add(tbAmount.Text);
                tbAmount.Text = "";
            }
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(tbAction.Text))
            {
                MessageBox.Show("Please enter an action.");
            }
            else if(String.IsNullOrWhiteSpace(tbDuration.Text))
            {
                MessageBox.Show("Please enter a Duration in minutes for this action.");
            }
            else
            {
                try
                {
                    int duration = Convert.ToInt16(tbDuration.Text);
                    lbActions.Items.Add(tbAction.Text);
                    tbAction.Text = "";
                    lbDurations.Items.Add(duration);
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number for the duration.");
                }
                
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Please enter a name");
            }
            if(lbAppliances.Items.Count < 1)
            {
                MessageBox.Show("Please add the uCook Appliances needed for this recipe.");
            }
            else
            {
                recipe.name = tbName.Text;
                
                for(int i = 0; i < lbAppliances.Items.Count; i++)
                {
                    recipe.addAppliance(lbAppliances.Items[0].ToString());
                }
                for(int i = 0; i < lbIngredients.Items.Count; i++)
                {
                    string n = lbIngredients.Items[i].ToString();
                    string a = lbAmounts.Items[i].ToString();
                    recipe.addIngredient(new uCookContract.Ingredient(n, a));
                }
                for(int i = 0; i < lbActions.Items.Count; i++)
                {
                    string a = lbActions.Items[i].ToString();
                    int d = Convert.ToInt16(lbDurations.Items[i]);
                    recipe.timeLine.addTimeSlot(a, d);
                }
                recipe.setTotalTime();

                //copy local version to public recipe
                uCookClient.newRecipe = recipe;

                this.Close();
            }
        }

        private void AddScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            uCookClient.mainScreen.Enabled = true;
        }
    }
}
