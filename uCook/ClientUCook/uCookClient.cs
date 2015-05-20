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
        private uCookService.RecipesClient proxy;
        public uCookClient()
        {
            InitializeComponent();
            proxy = new uCookService.RecipesClient();
        }



        private void addRecipeBtn_Click(object sender, EventArgs e)
        {
            proxy.addRecipe(null);
        }

        private void removeRecipeBtn_Click(object sender, EventArgs e)
        {
            proxy.removeRecipe(textBox1.ToString());
        }

        private void findRecipeBtn_Click(object sender, EventArgs e)
        {
            proxy.findRecipe(textBox1.ToString());
        }
    }
}
