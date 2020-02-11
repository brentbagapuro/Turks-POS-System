using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Turks_POS_System
{
    public partial class Upgrade_Dialog : Form
    {
        private string _i;
        private string itemname;
        public string inp
        {
            get { return _i; }
            set { _i = value; qty_input.Text = value; }
        }

        public string uname
        {
            get { return itemname; }
            set { itemname = value; }
        }

        public Upgrade_Dialog()
        {
            InitializeComponent();
            this.Text = "Upgrade Food Item";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            btn_sub.Enabled = true;
            int current = Convert.ToInt32(qty_input.Text);
            current += 1;
            qty_input.Text = current.ToString();
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
            int check = Convert.ToInt32(qty_input.Text);
            if (check == 1)
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

        public object selected;

        public SQLiteConnection myConnection;
        public void Fooditem2_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in foodpanel.Controls)
            {
                if (c is FoodItem2)
                {
                    ((FoodItem2)c).IsSelected = false;
                    uname = ((FoodItem2)c).Fname;
                }
            }
            selected = sender;
        }

        public void openConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
                myConnection.Open();
        }

        public void closeConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
                myConnection.Close();
        }

        private void Btn_confirm(object sender, EventArgs e)
        {
            foreach (Control c in foodpanel.Controls)
            {
                if (c is FoodItem2)
                {
                    if(selected != null)
                    {
                        if (c == selected)
                        {
                            uname = ((FoodItem2)c).Fname;
                        }
                    }
                }
            }
        }

        private void qty_input_TextChanged(object sender, EventArgs e)
        {
            inp = qty_input.Text;
        }
    }
}
