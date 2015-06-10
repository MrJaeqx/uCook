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

        public AddScreen(List<uCookContract.Appliances> appliances)
        {
            InitializeComponent();
            recipe = new uCookContract.Recipe();

            
            foreach(uCookContract.Appliances a in appliances)
            {
                cbAppliances.Items.Add(a);
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
                lbDurations.Items.Add(0);
                lbActions.Items.Add(tbAction.Text);
                tbAction.Text = "";
                tbDuration.Text = "";
                lbAppliances.Items.Add(cbAppliances.SelectedItem);
                cbAppliances.SelectedIndex = -1;
            }
            else if(cbAppliances.SelectedItem == null)
            {
                MessageBox.Show("Please select the required Appliance needed for this action.");
            }
            else
            {
                try
                {
                    int duration = Convert.ToInt16(tbDuration.Text);
                    lbActions.Items.Add(tbAction.Text);
                    tbAction.Text = "";
                    lbDurations.Items.Add(duration);
                    tbDuration.Text = "";
                    lbAppliances.Items.Add(cbAppliances.SelectedItem);
                    cbAppliances.SelectedIndex = -1;
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number for the duration or leave blank.");
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
                    if(!recipe.appliances.Contains((uCookContract.Appliances)lbAppliances.Items[i]))
                    {
                        recipe.addAppliance((uCookContract.Appliances)lbAppliances.Items[i]);
                    }
                }
                for(int i = 0; i < lbIngredients.Items.Count; i++)
                {
                    string n = lbIngredients.Items[i].ToString();
                    string a = lbAmounts.Items[i].ToString();
                    recipe.addIngredient(new uCookContract.Ingredient(n, a));
                }
                for(int i = 0; i < lbActions.Items.Count; i++)
                {
                    string action = lbActions.Items[i].ToString();
                    int d = Convert.ToInt16(lbDurations.Items[i]);
                    uCookContract.Appliances app = (uCookContract.Appliances)lbAppliances.Items[i];
                    recipe.timeLine.addTimeSlot(action, d, app);
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
