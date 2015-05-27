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
        public AddScreen()
        {
            InitializeComponent();
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
    }
}
