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
    public partial class uCookClient : Form
    {
        //Proxy for communication with server
        private uCookService.RecipesClient proxy;

        //Public Recipe for sharing between forms
        public static uCookContract.Recipe newRecipe = null;

        //Instance of AddScreen for adding new Recipes
        AddScreen addScreen;

        //Instance of TimeLineclient for showing current recipe
        TimeLineClient timeLineScreen;

        //Used to enable calls to this screen from other screens
        public static uCookClient mainScreen;

        //list of found recipes
        private List<uCookContract.Recipe> foundRecipes;

        public uCookClient()
        {
            InitializeComponent();
            mainScreen = this;

            //proxy init
            proxy = new uCookService.RecipesClient();

            //add screen init
            addScreen = new AddScreen(proxy.getAvailableAppliances());
        }

        /////////////////////
        //button handling
        /////////////////////
        private void addRecipeBtn_Click(object sender, EventArgs e)
        {
            addScreen.Show();
            this.Enabled = false;
        }

        private void findRecipeBtn_Click(object sender, EventArgs e)
        {
            foundRecipes = proxy.findRecipe(tbSearch.Text);

            lbResults.Items.Clear();
            if (foundRecipes.Count > 0)
            {
                foreach (uCookContract.Recipe r in foundRecipes)
                {
                    lbResults.Items.Add(r.name);
                }
            }
            else
            {
                lbResults.Items.Add("no results found");
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if(lbResults.SelectedItem != null)
            {
                timeLineScreen = new TimeLineClient(foundRecipes[lbResults.SelectedIndex]);
                timeLineScreen.Show();
                this.Enabled = false;
            }
        }

        //////////////////////
        //Events
        /////////////////////
        private void uCookClient_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                if (newRecipe != null)
                {
                    proxy.addRecipe(newRecipe);
                    newRecipe = null;
                }
            }
        }
    }
}
