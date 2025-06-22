using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_shop
{
    public partial class admin_panel : Form
    {
        public admin_panel()
        {
            InitializeComponent();
        }









        private void button1_Click(object sender, EventArgs e)
        {
            panel_add_items panel_Add_Items = new panel_add_items();
            panel_Add_Items.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_edit_items panel_Edit_Items = new panel_edit_items();
            panel_Edit_Items.ShowDialog();
        }
    }
}
