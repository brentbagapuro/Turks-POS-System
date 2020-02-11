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
    public partial class Confirm_Dialog : Form
    {
        private string _t;
        private string temp = "";

        public string tot
        {
            get { return _t; }
            set { _t = value; lbl_total.Text = value; temp = value; }
        }

        public Confirm_Dialog()
        {
            InitializeComponent();
            this.Text = "Confirm Order";
        }

        private void cust_cash_TextChanged(object sender, EventArgs e)
        {
            if(cust_cash.Text != "")
            {
                int to = Convert.ToInt32(cust_cash.Text);
                string s = temp;
                int len = s.Length;
                len -= 4;
                string sub = s.Substring(1, len);
                int n = Convert.ToInt32(sub) - to;
                if(n<=0)
                {
                    lbl_total.Text = "P0.00";
                }
                else
                {
                    lbl_total.Text = "P" + n.ToString() + ".00";
                }
            }
            else
            {
                lbl_total.Text = temp;
            }
        }
    }
}
