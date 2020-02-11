using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turks_POS_System
{
    public partial class Qty_Dialog : Form
    {
        private string _i;
        public string inp
        {
            get { return _i; }
            set { _i = value; qty_input.Text = value; }
        }
        
        public Qty_Dialog()
        {
            InitializeComponent();
            this.Text = "Edit Quantity";
        }

        private void add_Click(object sender, EventArgs e)
        {
            btn_sub.Enabled = true;
            int current = Convert.ToInt32(qty_input.Text);
            current += 1;
            qty_input.Text = current.ToString();
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            int check = Convert.ToInt32(qty_input.Text);
            if(check == 1)
            {
                btn_sub.Enabled = false;
            }
            else
            {
                int current = Convert.ToInt32(qty_input.Text);
                current -= 1;
                qty_input.Text = current.ToString();
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            
        }

        private void qty_input_TextChanged(object sender, EventArgs e)
        {
            inp = qty_input.Text;
        }
    }
}
