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
using System.Reflection;
using Turks_POS_System.Properties;
using System.Text.RegularExpressions;

namespace Turks_POS_System
{
    public partial class Preupgrade_Dialog : Form
    {
        string ingmeat1 = "";
        string ingmeat2 = "";
        string ingmeat3 = "";
        string ingmeat4 = "";
        string ingmeat5 = "";
        string ingveggie1 = "";
        string ingveggie2 = "";
        string ingveggie3 = "";
        string ingveggie4 = "";
        string ingveggie5 = "";
        string ingsauce1 = "";
        string ingsauce2 = "";
        string ingsauce3 = "";
        string ingsauce4 = "";
        string ingsauce5 = "";
        string xingmeat1 = "";
        string xingmeat2 = "";
        string xingmeat3 = "";
        string xingmeat4 = "";
        string xingmeat5 = "";
        string xingveggie1 = "";
        string xingveggie2 = "";
        string xingveggie3 = "";
        string xingveggie4 = "";
        string xingveggie5 = "";
        string xingsauce1 = "";
        string xingsauce2 = "";
        string xingsauce3 = "";
        string xingsauce4 = "";
        string xingsauce5 = "";
        string plat = "";
        private string _i;
        public string inp
        {
            get { return _i; }
            set { _i = value; qty_input.Text = value; }
        }

        private string itemname;
        public string uname
        {
            get { return itemname; }
            set { itemname = value; }
        }

        private string itemname1;
        public string uname1
        {
            get { return itemname1; }
            set { itemname1 = value; }
        }

        private string itemname2;
        public string uname2
        {
            get { return itemname2; }
            set { itemname2 = value; }
        }

        private string itemname3;
        public string uname3
        {
            get { return itemname3; }
            set { itemname3 = value; }
        }

        private string itemname4;
        public string uname4
        {
            get { return itemname4; }
            set { itemname4 = value; }
        }

        private string itemname5;
        public string uname5
        {
            get { return itemname5; }
            set { itemname5 = value; }
        }

        private string _i1;
        public string inp1
        {
            get { return _i1; }
            set { _i1 = value; }
        }

        private string _i2;
        public string inp2
        {
            get { return _i2; }
            set { _i2 = value; }
        }

        private string _i3;
        public string inp3
        {
            get { return _i3; }
            set { _i3 = value; }
        }

        private string _i4;
        public string inp4
        {
            get { return _i4; }
            set { _i4 = value; }
        }

        private string _i5;
        public string inp5
        {
            get { return _i5; }
            set { _i5 = value; }
        }

        private string _o1;
        public string oext1
        {
            get { return _o1; }
            set { _o1 = value; }
        }

        private string _o2;
        public string oext2
        {
            get { return _o2; }
            set { _o2 = value; }
        }

        private string _o3;
        public string oext3
        {
            get { return _o3; }
            set { _o3 = value; }
        }

        private string _o4;
        public string oext4
        {
            get { return _o4; }
            set { _o4 = value; }
        }

        private string _o5;
        public string oext5
        {
            get { return _o5; }
            set { _o5 = value; }
        }

        public Preupgrade_Dialog()
        {
            InitializeComponent();
            btn_confirm_split.Visible = false;
            this.Text = "Pre-upgrade Food Item";
            panel_qty.Visible = false;
            panel_splits.Visible = false;
            check_split1.Enabled = false;
            check_split1.Checked = true;
            lbl_split1.Click += lbl_split1_Click;

            //INP_QTY
            inp_qty_split1.Text = "1";
            inp_qty_split2.Text = "0";
            inp_qty_split3.Text = "0";
            inp_qty_split4.Text = "0";
            inp_qty_split5.Text = "0";
            panel_inqty_split1.Visible = false;
            panel_inqty_split2.Visible = false;
            panel_inqty_split3.Visible = false;
            panel_inqty_split4.Visible = false;
            panel_inqty_split5.Visible = false;

            check_split3.Enabled = false;
            check_split4.Enabled = false;
            check_split5.Enabled = false;
        }

        private void btn_split_Click(object sender, EventArgs e)
        {
            meatlayout_split1.Controls.Clear();
            meatlayout_split2.Controls.Clear();
            meatlayout_split3.Controls.Clear();
            meatlayout_split4.Controls.Clear();
            meatlayout_split5.Controls.Clear();
            veggielayout_split1.Controls.Clear();
            veggielayout_split2.Controls.Clear();
            veggielayout_split3.Controls.Clear();
            veggielayout_split4.Controls.Clear();
            veggielayout_split5.Controls.Clear();
            saucelayout_split1.Controls.Clear();
            saucelayout_split2.Controls.Clear();
            saucelayout_split3.Controls.Clear();
            saucelayout_split4.Controls.Clear();
            saucelayout_split5.Controls.Clear();

            btn_confirm_split.Visible = true;
            btn_confirm.Visible = false;
            panel_qty.Visible = true;
            panel_splits.Visible = true;
            lbl_qty.Text = qty_input.Text;
            btn_get_split1.Enabled = true;
            btn_get_split2.Enabled = true;
            btn_get_split3.Enabled = true;
            btn_get_split4.Enabled = true;
            btn_get_split5.Enabled = true;

            check_split2.Checked = false;
            check_split3.Checked = false;
            check_split4.Checked = false;
            check_split5.Checked = false;

            RemoveClickEvent(lbl_split2);
            RemoveClickEvent(lbl_split3);
            RemoveClickEvent(lbl_split4);
            RemoveClickEvent(lbl_split5);

            //INP_QTY
            //inp_qty_split1.Text = "1";
            inp_qty_split1.Text = qty_input.Text;
            inp_qty_split2.Text = "0";
            inp_qty_split3.Text = "0";
            inp_qty_split4.Text = "0";
            inp_qty_split5.Text = "0";
            panel_inqty_split1.Visible = true;
            panel_inqty_split2.Visible = false;
            panel_inqty_split3.Visible = false;
            panel_inqty_split4.Visible = false;
            panel_inqty_split5.Visible = false;

            food_panel_split1.Controls.Clear();
            food_panel_split2.Controls.Clear();
            food_panel_split3.Controls.Clear();
            food_panel_split4.Controls.Clear();
            food_panel_split5.Controls.Clear();

            //lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
            lbl_qty.Text = "0";

            if (lbl_qty.Text == "0")
            {
                btn_get_split1.Enabled = false;
                //check_split2.Enabled = false;
            }
            else
            {
                btn_get_split1.Enabled = true;
                check_split2.Enabled = true;
            }
            
            string fn = "";
            fn = Fname;

            if (Regex.Matches(fn, "Pita").Count == 1 || Regex.Matches(fn, "Wrap").Count == 1)
            {
                fetchings("Pita", fn);
            }
            else if (Regex.Matches(fn, "Rice").Count == 1 || Regex.Matches(fn, "Bowl").Count == 1)
            {
                fetchings("Rice", fn);
            }
            else if (Regex.Matches(fn, "Platter").Count == 1)
            {
                fetchings("Platter", fn);
                plat = "Platter";
            }
            else if (Regex.Matches(fn, "Steak").Count == 1)
            {
                fetchings("Steak", fn);
            }
        }

        private void lbl_split1_Click(object sender, EventArgs e)
        {
            ings_split1.Visible = true;
            food_panel_split1.Visible = true;
            panel_inqty_split1.Visible = true;

            ings_split2.Visible = false;
            food_panel_split2.Visible = false;
            panel_inqty_split2.Visible = false;

            ings_split3.Visible = false;
            food_panel_split3.Visible = false;
            panel_inqty_split3.Visible = false;

            ings_split4.Visible = false;
            food_panel_split4.Visible = false;
            panel_inqty_split4.Visible = false;

            ings_split5.Visible = false;
            food_panel_split5.Visible = false;
            panel_inqty_split5.Visible = false;

            panel_split1.BackColor = SystemColors.Control;
            panel_split2.BackColor = SystemColors.ControlDark;
            panel_split3.BackColor = SystemColors.ControlDark;
            panel_split4.BackColor = SystemColors.ControlDark;
            panel_split5.BackColor = SystemColors.ControlDark;

            check_split1.BackColor = SystemColors.Control;
            check_split2.BackColor = SystemColors.ControlDark;
            check_split3.BackColor = SystemColors.ControlDark;
            check_split4.BackColor = SystemColors.ControlDark;
            check_split5.BackColor = SystemColors.ControlDark;
        }

        private void lbl_split2_Click(object sender, EventArgs e)
        {
            ings_split1.Visible = false;
            food_panel_split1.Visible = false;
            panel_inqty_split1.Visible = false;

            ings_split2.Visible = true;
            food_panel_split2.Visible = true;
            panel_inqty_split2.Visible = true;

            ings_split3.Visible = false;
            food_panel_split3.Visible = false;
            panel_inqty_split3.Visible = false;

            ings_split4.Visible = false;
            food_panel_split4.Visible = false;
            panel_inqty_split4.Visible = false;

            ings_split5.Visible = false;
            food_panel_split5.Visible = false;
            panel_inqty_split5.Visible = false;

            panel_split1.BackColor = SystemColors.ControlDark;
            panel_split2.BackColor = SystemColors.Control;
            panel_split3.BackColor = SystemColors.ControlDark;
            panel_split4.BackColor = SystemColors.ControlDark;
            panel_split5.BackColor = SystemColors.ControlDark;

            check_split1.BackColor = SystemColors.ControlDark;
            check_split2.BackColor = SystemColors.Control;
            check_split3.BackColor = SystemColors.ControlDark;
            check_split4.BackColor = SystemColors.ControlDark;
            check_split5.BackColor = SystemColors.ControlDark;
        }

        private void lbl_split3_Click(object sender, EventArgs e)
        {
            ings_split1.Visible = false;
            food_panel_split1.Visible = false;
            panel_inqty_split1.Visible = false;

            ings_split2.Visible = false;
            food_panel_split2.Visible = false;
            panel_inqty_split2.Visible = false;

            ings_split3.Visible = true;
            food_panel_split3.Visible = true;
            panel_inqty_split3.Visible = true;

            ings_split4.Visible = false;
            food_panel_split4.Visible = false;
            panel_inqty_split4.Visible = false;

            ings_split5.Visible = false;
            food_panel_split5.Visible = false;
            panel_inqty_split5.Visible = false;

            panel_split1.BackColor = SystemColors.ControlDark;
            panel_split2.BackColor = SystemColors.ControlDark;
            panel_split3.BackColor = SystemColors.Control;
            panel_split4.BackColor = SystemColors.ControlDark;
            panel_split5.BackColor = SystemColors.ControlDark;

            check_split1.BackColor = SystemColors.ControlDark;
            check_split2.BackColor = SystemColors.ControlDark;
            check_split3.BackColor = SystemColors.Control;
            check_split4.BackColor = SystemColors.ControlDark;
            check_split5.BackColor = SystemColors.ControlDark;
        }

        private void lbl_split4_Click(object sender, EventArgs e)
        {
            ings_split1.Visible = false;
            food_panel_split1.Visible = false;
            panel_inqty_split1.Visible = false;

            ings_split2.Visible = false;
            food_panel_split2.Visible = false;
            panel_inqty_split2.Visible = false;

            ings_split3.Visible = false;
            food_panel_split3.Visible = false;
            panel_inqty_split3.Visible = false;

            ings_split4.Visible = true;
            food_panel_split4.Visible = true;
            panel_inqty_split4.Visible = true;

            ings_split5.Visible = false;
            food_panel_split5.Visible = false;
            panel_inqty_split5.Visible = false;

            panel_split1.BackColor = SystemColors.ControlDark;
            panel_split2.BackColor = SystemColors.ControlDark;
            panel_split3.BackColor = SystemColors.ControlDark;
            panel_split4.BackColor = SystemColors.Control;
            panel_split5.BackColor = SystemColors.ControlDark;

            check_split1.BackColor = SystemColors.ControlDark;
            check_split2.BackColor = SystemColors.ControlDark;
            check_split3.BackColor = SystemColors.ControlDark;
            check_split4.BackColor = SystemColors.Control;
            check_split5.BackColor = SystemColors.ControlDark;
        }

        private void lbl_split5_Click(object sender, EventArgs e)
        {
            ings_split1.Visible = false;
            food_panel_split1.Visible = false;
            panel_inqty_split1.Visible = false;

            ings_split2.Visible = false;
            food_panel_split2.Visible = false;
            panel_inqty_split2.Visible = false;

            ings_split3.Visible = false;
            food_panel_split3.Visible = false;
            panel_inqty_split3.Visible = false;

            ings_split4.Visible = false;
            food_panel_split4.Visible = false;
            panel_inqty_split4.Visible = false;

            ings_split5.Visible = true;
            food_panel_split5.Visible = true;
            panel_inqty_split5.Visible = true;

            panel_split1.BackColor = SystemColors.ControlDark;
            panel_split2.BackColor = SystemColors.ControlDark;
            panel_split3.BackColor = SystemColors.ControlDark;
            panel_split4.BackColor = SystemColors.ControlDark;
            panel_split5.BackColor = SystemColors.Control;

            check_split1.BackColor = SystemColors.ControlDark;
            check_split2.BackColor = SystemColors.ControlDark;
            check_split3.BackColor = SystemColors.ControlDark;
            check_split4.BackColor = SystemColors.ControlDark;
            check_split5.BackColor = SystemColors.Control;
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

        public object selected1;
        public void Fooditem_Split1_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in food_panel_split1.Controls)
            {
                if (c is FoodItem_Split1)
                {
                    ((FoodItem_Split1)c).IsSelected = false;
                    uname1 = ((FoodItem_Split1)c).Fname;
                }
            }

            selected1 = sender;
        }

        public object selected2;
        public void Fooditem_Split2_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in food_panel_split2.Controls)
            {
                if (c is FoodItem_Split2)
                {
                    ((FoodItem_Split2)c).IsSelected = false;
                    uname2 = ((FoodItem_Split2)c).Fname;
                }
            }

            selected2 = sender;
        }

        public object selected3;
        public void Fooditem_Split3_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in food_panel_split3.Controls)
            {
                if (c is FoodItem_Split3)
                {
                    ((FoodItem_Split3)c).IsSelected = false;
                    uname3 = ((FoodItem_Split3)c).Fname;
                }
            }

            selected3 = sender;
        }

        public object selected4;
        public void Fooditem_Split4_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in food_panel_split4.Controls)
            {
                if (c is FoodItem_Split4)
                {
                    ((FoodItem_Split4)c).IsSelected = false;
                    uname4 = ((FoodItem_Split4)c).Fname;
                }
            }

            selected4 = sender;
        }

        public object selected5;
        public void Fooditem_Split5_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in food_panel_split5.Controls)
            {
                if (c is FoodItem_Split5)
                {
                    ((FoodItem_Split5)c).IsSelected = false;
                    uname5 = ((FoodItem_Split5)c).Fname;
                }
            }

            selected5 = sender;
        }

        private void Btn_confirm(object sender, EventArgs e)
        {
            foreach (Control c in foodpanel.Controls)
            {
                if (c is FoodItem2)
                {
                    if (selected != null)
                    {
                        if (c == selected)
                        {
                            uname = ((FoodItem2)c).Fname;
                        }
                    }
                }
            }
        }

        private void btn_confirm_split_Click(object sender, EventArgs e)
        {
            if(inp_qty_split1.Text != "0")
            {
                inp1 = inp_qty_split1.Text;
                string[] extmeat1 = xingmeat1.Split(',');
                string[] extveggie1 = xingveggie1.Split(',');
                string[] extsauce1 = xingsauce1.Split(',');
                getext1(extmeat1, extveggie1, extsauce1, plat);
                foreach (Control c in food_panel_split1.Controls)
                {
                    if (c is FoodItem_Split1)
                    {
                        if (selected1 != null)
                        {
                            if (c == selected1)
                            {
                                uname1 = ((FoodItem_Split1)c).Fname;
                            }
                        }
                    }
                }
            }
            if(inp_qty_split2.Text != "0")
            {
                inp2 = inp_qty_split2.Text;
                string[] extmeat2 = xingmeat2.Split(',');
                string[] extveggie2 = xingveggie2.Split(',');
                string[] extsauce2 = xingsauce2.Split(',');
                getext2(extmeat2, extveggie2, extsauce2, plat);
                foreach (Control c in food_panel_split2.Controls)
                {
                    if (c is FoodItem_Split2)
                    {
                        if (selected2 != null)
                        {
                            if (c == selected2)
                            {
                                uname2 = ((FoodItem_Split2)c).Fname;
                            }
                        }
                    }
                }
            }
            if (inp_qty_split3.Text != "0")
            {
                inp3 = inp_qty_split3.Text;
                string[] extmeat3 = xingmeat3.Split(',');
                string[] extveggie3 = xingveggie3.Split(',');
                string[] extsauce3 = xingsauce3.Split(',');
                getext3(extmeat3, extveggie3, extsauce3, plat);
                foreach (Control c in food_panel_split3.Controls)
                {
                    if (c is FoodItem_Split3)
                    {
                        if (selected3 != null)
                        {
                            if (c == selected3)
                            {
                                uname3 = ((FoodItem_Split3)c).Fname;
                            }
                        }
                    }
                }
            }
            if (inp_qty_split4.Text != "0")
            {
                inp4 = inp_qty_split4.Text;
                string[] extmeat4 = xingmeat4.Split(',');
                string[] extveggie4 = xingveggie4.Split(',');
                string[] extsauce4 = xingsauce4.Split(',');
                getext4(extmeat4, extveggie4, extsauce4, plat);
                foreach (Control c in food_panel_split4.Controls)
                {
                    if (c is FoodItem_Split4)
                    {
                        if (selected4 != null)
                        {
                            if (c == selected4)
                            {
                                uname4 = ((FoodItem_Split4)c).Fname;
                            }
                        }
                    }
                }
            }
            if (inp_qty_split5.Text != "0")
            {
                inp5 = inp_qty_split5.Text;
                string[] extmeat5 = xingmeat5.Split(',');
                string[] extveggie5 = xingveggie5.Split(',');
                string[] extsauce5 = xingsauce5.Split(',');
                getext5(extmeat5, extveggie5, extsauce5, plat);
                foreach (Control c in food_panel_split5.Controls)
                {
                    if (c is FoodItem_Split5)
                    {
                        if (selected5 != null)
                        {
                            if (c == selected5)
                            {
                                uname5 = ((FoodItem_Split5)c).Fname;
                            }
                        }
                    }
                }
            }
        }

        private void qty_input_TextChanged(object sender, EventArgs e)
        {
            inp = qty_input.Text;
        }

        //START OF SQL CONNECTION
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
        //END OF SQL CONNECTION

        private void btn_back_Click(object sender, EventArgs e)
        {
            btn_confirm_split.Visible = false;
            btn_confirm.Visible = true;
            btn_confirm.Visible = true;
            panel_qty.Visible = false;
            panel_splits.Visible = false;
            panel_inqty_split2.Visible = false;

            //INP_QTY
            inp_qty_split1.Text = "0";
            inp_qty_split2.Text = "0";
            inp_qty_split3.Text = "0";
            inp_qty_split4.Text = "0";
            inp_qty_split5.Text = "0";
            panel_inqty_split1.Visible = false;
            panel_inqty_split2.Visible = false;
            panel_inqty_split3.Visible = false;
            panel_inqty_split4.Visible = false;
            panel_inqty_split5.Visible = false;
        }

        private void btn_get_split1_Click(object sender, EventArgs e)
        {
            int current = Convert.ToInt32(inp_qty_split1.Text);
            current += 1;
            inp_qty_split1.Text = current.ToString();
            lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
            if (lbl_qty.Text == "0")
            {
                btn_get_split1.Enabled = false;
                //btn_get_split2.Enabled = false;
                btn_get_split3.Enabled = false;
                btn_get_split4.Enabled = false;
                btn_get_split5.Enabled = false;
            }
            btn_no_split1.Enabled = true;
            btn_no_split2.Enabled = true;
            btn_no_split3.Enabled = true;
            btn_no_split4.Enabled = true;
            btn_no_split5.Enabled = true;
        }

        private void btn_no_split1_Click(object sender, EventArgs e)
        {
            int check = Convert.ToInt32(inp_qty_split1.Text);
            if (check == 1)
            {
                btn_sub.Enabled = false;
            }
            else
            {
                int current = Convert.ToInt32(inp_qty_split1.Text);
                current -= 1;
                inp_qty_split1.Text = current.ToString();
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + 1).ToString();
                if (inp_qty_split1.Text == "1")
                {
                    btn_no_split1.Enabled = false;
                }
                btn_get_split1.Enabled = true;
                btn_get_split2.Enabled = true;
                btn_get_split3.Enabled = true;
                btn_get_split4.Enabled = true;
                btn_get_split5.Enabled = true;
            }
        }

        private void btn_get_split2_Click(object sender, EventArgs e)
        {
            if (lbl_qty.Text == "0")
            {
                inp_qty_split1.Text = (Convert.ToInt32(inp_qty_split1.Text) - 1).ToString();
                int current = Convert.ToInt32(inp_qty_split2.Text);
                current += 1;
                inp_qty_split2.Text = current.ToString();
                if(inp_qty_split1.Text == "1")
                {
                    btn_get_split2.Enabled = false;
                }
                //btn_get_split1.Enabled = false;
                //btn_get_split2.Enabled = false;
                //btn_get_split3.Enabled = false;
                //btn_get_split4.Enabled = false;
                //btn_get_split5.Enabled = false;
            }
            else
            {
                int current = Convert.ToInt32(inp_qty_split2.Text);
                current += 1;
                inp_qty_split2.Text = current.ToString();
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
                if (lbl_qty.Text == "0")
                {
                    btn_get_split1.Enabled = false;
                    btn_get_split2.Enabled = false;
                }
            }

            btn_no_split1.Enabled = true;
            btn_no_split2.Enabled = true;
            btn_no_split3.Enabled = true;
            btn_no_split4.Enabled = true;
            btn_no_split5.Enabled = true;
        }

        private void btn_no_split2_Click(object sender, EventArgs e)
        {
            int check = Convert.ToInt32(inp_qty_split2.Text);
            if (check == 1)
            {
                btn_sub.Enabled = false;
            }
            else
            {
                int current = Convert.ToInt32(inp_qty_split2.Text);
                current -= 1;
                inp_qty_split2.Text = current.ToString();
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + 1).ToString();
                if (inp_qty_split2.Text == "1")
                {
                    btn_no_split2.Enabled = false;
                }
                btn_get_split1.Enabled = true;
                btn_get_split2.Enabled = true;
                btn_get_split3.Enabled = true;
                btn_get_split4.Enabled = true;
                btn_get_split5.Enabled = true;
            }
        }

        private void btn_get_split3_Click(object sender, EventArgs e)
        {
            int current = Convert.ToInt32(inp_qty_split3.Text);
            current += 1;
            inp_qty_split3.Text = current.ToString();
            lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
            if (lbl_qty.Text == "0")
            {
                btn_get_split1.Enabled = false;
                btn_get_split2.Enabled = false;
                btn_get_split3.Enabled = false;
                btn_get_split4.Enabled = false;
                btn_get_split5.Enabled = false;
            }
            btn_no_split1.Enabled = true;
            btn_no_split2.Enabled = true;
            btn_no_split3.Enabled = true;
            btn_no_split4.Enabled = true;
            btn_no_split5.Enabled = true;
        }

        private void btn_no_split3_Click(object sender, EventArgs e)
        {
            int check = Convert.ToInt32(inp_qty_split3.Text);
            if (check == 1)
            {
                btn_sub.Enabled = false;
            }
            else
            {
                int current = Convert.ToInt32(inp_qty_split3.Text);
                current -= 1;
                inp_qty_split3.Text = current.ToString();
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + 1).ToString();
                if (inp_qty_split3.Text == "1")
                {
                    btn_no_split3.Enabled = false;
                }
                btn_get_split1.Enabled = true;
                btn_get_split2.Enabled = true;
                btn_get_split3.Enabled = true;
                btn_get_split4.Enabled = true;
                btn_get_split5.Enabled = true;
            }
        }

        private void btn_get_split4_Click(object sender, EventArgs e)
        {
            int current = Convert.ToInt32(inp_qty_split4.Text);
            current += 1;
            inp_qty_split4.Text = current.ToString();
            lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
            if (lbl_qty.Text == "0")
            {
                btn_get_split1.Enabled = false;
                btn_get_split2.Enabled = false;
                btn_get_split3.Enabled = false;
                btn_get_split4.Enabled = false;
                btn_get_split5.Enabled = false;
            }
            btn_no_split1.Enabled = true;
            btn_no_split2.Enabled = true;
            btn_no_split3.Enabled = true;
            btn_no_split4.Enabled = true;
            btn_no_split5.Enabled = true;
        }

        private void btn_no_split4_Click(object sender, EventArgs e)
        {
            int check = Convert.ToInt32(inp_qty_split4.Text);
            if (check == 1)
            {
                btn_sub.Enabled = false;
            }
            else
            {
                int current = Convert.ToInt32(inp_qty_split4.Text);
                current -= 1;
                inp_qty_split4.Text = current.ToString();
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + 1).ToString();
                if (inp_qty_split4.Text == "1")
                {
                    btn_no_split4.Enabled = false;
                }
                btn_get_split1.Enabled = true;
                btn_get_split2.Enabled = true;
                btn_get_split3.Enabled = true;
                btn_get_split4.Enabled = true;
                btn_get_split5.Enabled = true;
            }
        }

        private void btn_get_split5_Click(object sender, EventArgs e)
        {
            int current = Convert.ToInt32(inp_qty_split5.Text);
            current += 1;
            inp_qty_split5.Text = current.ToString();
            lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
            if (lbl_qty.Text == "0")
            {
                btn_get_split1.Enabled = false;
                btn_get_split2.Enabled = false;
                btn_get_split3.Enabled = false;
                btn_get_split4.Enabled = false;
                btn_get_split5.Enabled = false;
            }
            btn_no_split1.Enabled = true;
            btn_no_split2.Enabled = true;
            btn_no_split3.Enabled = true;
            btn_no_split4.Enabled = true;
            btn_no_split5.Enabled = true;
        }

        private void btn_no_split5_Click(object sender, EventArgs e)
        {
            int check = Convert.ToInt32(inp_qty_split5.Text);
            if (check == 1)
            {
                btn_sub.Enabled = false;
            }
            else
            {
                int current = Convert.ToInt32(inp_qty_split5.Text);
                current -= 1;
                inp_qty_split5.Text = current.ToString();
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + 1).ToString();
                if (inp_qty_split5.Text == "1")
                {
                    btn_no_split5.Enabled = false;
                }
                btn_get_split1.Enabled = true;
                btn_get_split2.Enabled = true;
                btn_get_split3.Enabled = true;
                btn_get_split4.Enabled = true;
                btn_get_split5.Enabled = true;
            }
        }

        private void cb_meat_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_meat.Checked)
            {
                foreach (Control b in meatlayout.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb_meat.Checked)
            {
                foreach (Control b in meatlayout.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb_veggie_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_veggie.Checked)
            {
                foreach (Control b in veggielayout.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb_veggie.Checked)
            {
                foreach (Control b in veggielayout.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb_sauce_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sauce.Checked)
            {
                foreach (Control b in saucelayout.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb_sauce.Checked)
            {
                foreach (Control b in saucelayout.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void check_split2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_split2.Checked == true)
            {
                lbl_split2.Click += lbl_split2_Click;
                check_split3.Enabled = true;
                btn_get_split2.Enabled = true;
                btn_no_split2.Enabled = true;
                if(lbl_qty.Text != "0")
                {
                    lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
                    inp_qty_split2.Text = "1";
                    if(lbl_qty.Text == "0")
                    {
                        btn_get_split1.Enabled = false;
                        btn_get_split2.Enabled = false;
                        //btn_get_split3.Enabled = false;
                        //btn_get_split4.Enabled = false;
                        //btn_get_split5.Enabled = false;
                    }
                }
                else
                {
                    //btn_get_split2.Enabled = false;
                    //btn_get_split3.Enabled = false;
                    //btn_get_split4.Enabled = false;
                    //btn_get_split5.Enabled = false;
                }

                if(inp_qty_split2.Text == "0")
                {
                    btn_no_split2.Enabled = false;
                    btn_no_split3.Enabled = false;
                    btn_no_split4.Enabled = false;
                    btn_no_split5.Enabled = false;
                }
            }
            else if (check_split2.Checked == false)
            {
                RemoveClickEvent(lbl_split2);
                check_split3.Enabled = false;
                check_split3.Checked = false;
                check_split4.Checked = false;
                check_split5.Checked = false;
                btn_get_split2.Enabled = false;
                btn_no_split2.Enabled = false;
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + Convert.ToInt32(inp_qty_split2.Text)).ToString();
                inp_qty_split2.Text = "0";
                if (lbl_qty.Text != "0")
                {
                    btn_get_split1.Enabled = true;
                    btn_get_split3.Enabled = true;
                    btn_get_split4.Enabled = true;
                    btn_get_split5.Enabled = true;
                }
            }
        }

        private void check_split3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_split3.Checked == true)
            {
                lbl_split3.Click += lbl_split3_Click;
                check_split4.Enabled = true;
                btn_get_split3.Enabled = true;
                btn_no_split3.Enabled = true;
                if (lbl_qty.Text != "0")
                {
                    lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
                    inp_qty_split3.Text = "1";
                    if (lbl_qty.Text == "0")
                    {
                        btn_get_split1.Enabled = false;
                        btn_get_split2.Enabled = false;
                        btn_get_split3.Enabled = false;
                        btn_get_split4.Enabled = false;
                        btn_get_split5.Enabled = false;
                    }
                }
                else
                {
                    //btn_get_split2.Enabled = false;
                    btn_get_split3.Enabled = false;
                    btn_get_split4.Enabled = false;
                    btn_get_split5.Enabled = false;
                }

                if (inp_qty_split3.Text == "0")
                {
                    btn_no_split3.Enabled = false;
                    btn_no_split4.Enabled = false;
                    btn_no_split5.Enabled = false;
                }
            }
            else if (check_split3.Checked == false)
            {
                RemoveClickEvent(lbl_split3);
                check_split4.Enabled = false;
                check_split4.Checked = false;
                check_split5.Checked = false;
                btn_get_split3.Enabled = false;
                btn_no_split3.Enabled = false;
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + Convert.ToInt32(inp_qty_split3.Text)).ToString();
                inp_qty_split3.Text = "0";
                if (lbl_qty.Text != "0")
                {
                    btn_get_split1.Enabled = true;
                    btn_get_split2.Enabled = true;
                    btn_get_split4.Enabled = true;
                    btn_get_split5.Enabled = true;
                }
            }
        }

        private void check_split4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_split4.Checked == true)
            {
                lbl_split4.Click += lbl_split4_Click;
                check_split5.Enabled = true;
                check_split5.Enabled = true;
                btn_get_split4.Enabled = true;
                btn_no_split4.Enabled = true;
                if (lbl_qty.Text != "0")
                {
                    lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
                    inp_qty_split4.Text = "1";
                    if (lbl_qty.Text == "0")
                    {
                        btn_get_split1.Enabled = false;
                        btn_get_split2.Enabled = false;
                        btn_get_split3.Enabled = false;
                        btn_get_split4.Enabled = false;
                        btn_get_split5.Enabled = false;
                    }
                }
                else
                {
                    //btn_get_split2.Enabled = false;
                    //btn_get_split3.Enabled = false;
                    btn_get_split4.Enabled = false;
                    btn_get_split5.Enabled = false;
                }

                if (inp_qty_split4.Text == "0")
                {
                    btn_no_split4.Enabled = false;
                    btn_no_split5.Enabled = false;
                }
            }
            else if (check_split4.Checked == false)
            {
                RemoveClickEvent(lbl_split4);
                check_split5.Enabled = false;
                check_split5.Checked = false;
                btn_get_split4.Enabled = false;
                btn_no_split4.Enabled = false;
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + Convert.ToInt32(inp_qty_split4.Text)).ToString();
                inp_qty_split4.Text = "0";
                if (lbl_qty.Text != "0")
                {
                    btn_get_split1.Enabled = true;
                    btn_get_split2.Enabled = true;
                    btn_get_split3.Enabled = true;
                    btn_get_split5.Enabled = true;
                }
            }
        }

        private void check_split5_CheckedChanged(object sender, EventArgs e)
        {
            if (check_split5.Checked == true)
            {
                lbl_split5.Click += lbl_split5_Click;
                btn_get_split5.Enabled = true;
                btn_no_split5.Enabled = true;
                if (lbl_qty.Text != "0")
                {
                    lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) - 1).ToString();
                    inp_qty_split5.Text = "1";
                    if (lbl_qty.Text == "0")
                    {
                        btn_get_split1.Enabled = false;
                        btn_get_split2.Enabled = false;
                        btn_get_split3.Enabled = false;
                        btn_get_split4.Enabled = false;
                        btn_get_split5.Enabled = false;
                    }
                }
                else
                {
                    //btn_get_split2.Enabled = false;
                    //btn_get_split3.Enabled = false;
                    //btn_get_split4.Enabled = false;
                    btn_get_split5.Enabled = false;
                }

                if (inp_qty_split5.Text == "0")
                {
                    btn_no_split5.Enabled = false;
                }
            }
            else if (check_split5.Checked == false)
            {
                RemoveClickEvent(lbl_split5);
                btn_get_split5.Enabled = false;
                btn_no_split5.Enabled = false;
                lbl_qty.Text = (Convert.ToInt32(lbl_qty.Text) + Convert.ToInt32(inp_qty_split5.Text)).ToString();
                inp_qty_split5.Text = "0";
                if (lbl_qty.Text != "0")
                {
                    btn_get_split1.Enabled = true;
                    btn_get_split2.Enabled = true;
                    btn_get_split3.Enabled = true;
                    btn_get_split4.Enabled = true;
                }
            }
        }

        private void RemoveClickEvent(Label b)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(b);
            PropertyInfo pi = b.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private string _s;
        public string Fname
        {
            get { return _s; }
            set { _s = value; }
        }

        CheckBox[] box_split1 = new CheckBox[20];
        CheckBox[] box_split2 = new CheckBox[20];
        CheckBox[] box_split3 = new CheckBox[20];
        CheckBox[] box_split4 = new CheckBox[20];
        CheckBox[] box_split5 = new CheckBox[20];
        CheckBox[] box2_split1 = new CheckBox[20];
        CheckBox[] box2_split2 = new CheckBox[20];
        CheckBox[] box2_split3 = new CheckBox[20];
        CheckBox[] box2_split4 = new CheckBox[20];
        CheckBox[] box2_split5 = new CheckBox[20];
        CheckBox[] box3_split1 = new CheckBox[20];
        CheckBox[] box3_split2 = new CheckBox[20];
        CheckBox[] box3_split3 = new CheckBox[20];
        CheckBox[] box3_split4 = new CheckBox[20];
        CheckBox[] box3_split5 = new CheckBox[20];
        public void fetchings(string food_type, string fn)
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            //SELECT FROM DATABASE
            string q = "SELECT * FROM tbl_menu WHERE food_name = '" + fn + "'";
            SQLiteCommand Cmd = new SQLiteCommand(q, myConnection);
            openConnection();
            SQLiteDataReader res = Cmd.ExecuteReader();

            string s = "";
            string ic = "";
            if (res.HasRows)
            {
                while (res.Read())
                {
                    s = res["sub"].ToString();
                    ic = res["food_ingcheck"].ToString();
                }
            }

            string qry = "SELECT * FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND up_sub = '" + fn + "'";
            string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND up_sub = '" + fn + "'";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            int len = Convert.ToInt32(myCommand2.ExecuteScalar());
            SQLiteDataReader result2 = myCommand.ExecuteReader();
            string[] foods = new string[len];
            string[] img = new string[len];
            string[] prices = new string[len];
            int i = 0;
            if (result2.HasRows)
            {
                while (result2.Read())
                {
                    img[i] = result2["up_image"].ToString();
                    foods[i] = result2["up_name"].ToString();
                    prices[i] = "P" + result2["up_price"].ToString() + ".00";
                    i++;
                }
            }
            FoodItem_Split1[] fooditems_split1 = new FoodItem_Split1[len];
            for (i = 0; i < fooditems_split1.Length; i++)
            {
                object o2 = Resources.ResourceManager.GetObject(img[i]);
                fooditems_split1[i] = new FoodItem_Split1();
                fooditems_split1[i].Pic = (Image)o2;
                fooditems_split1[i].Fname = foods[i];
                fooditems_split1[i].Price = prices[i];

                fooditems_split1[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                fooditems_split1[i].WasClicked += Fooditem_Split1_WasClicked;
                food_panel_split1.Controls.Add(fooditems_split1[i]);
            }

            FoodItem_Split2[] fooditems_split2 = new FoodItem_Split2[len];
            for (i = 0; i < fooditems_split2.Length; i++)
            {
                object o2 = Resources.ResourceManager.GetObject(img[i]);
                fooditems_split2[i] = new FoodItem_Split2();
                fooditems_split2[i].Pic = (Image)o2;
                fooditems_split2[i].Fname = foods[i];
                fooditems_split2[i].Price = prices[i];

                fooditems_split2[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                fooditems_split2[i].WasClicked += Fooditem_Split2_WasClicked;
                food_panel_split2.Controls.Add(fooditems_split2[i]);
            }

            FoodItem_Split3[] fooditems_split3 = new FoodItem_Split3[len];
            for (i = 0; i < fooditems_split3.Length; i++)
            {
                object o2 = Resources.ResourceManager.GetObject(img[i]);
                fooditems_split3[i] = new FoodItem_Split3();
                fooditems_split3[i].Pic = (Image)o2;
                fooditems_split3[i].Fname = foods[i];
                fooditems_split3[i].Price = prices[i];

                fooditems_split3[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                fooditems_split3[i].WasClicked += Fooditem_Split3_WasClicked;
                food_panel_split3.Controls.Add(fooditems_split3[i]);
            }

            FoodItem_Split4[] fooditems_split4 = new FoodItem_Split4[len];
            for (i = 0; i < fooditems_split4.Length; i++)
            {
                object o2 = Resources.ResourceManager.GetObject(img[i]);
                fooditems_split4[i] = new FoodItem_Split4();
                fooditems_split4[i].Pic = (Image)o2;
                fooditems_split4[i].Fname = foods[i];
                fooditems_split4[i].Price = prices[i];

                fooditems_split4[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                fooditems_split4[i].WasClicked += Fooditem_Split4_WasClicked;
                food_panel_split4.Controls.Add(fooditems_split4[i]);
            }

            FoodItem_Split5[] fooditems_split5 = new FoodItem_Split5[len];
            for (i = 0; i < fooditems_split5.Length; i++)
            {
                object o2 = Resources.ResourceManager.GetObject(img[i]);
                fooditems_split5[i] = new FoodItem_Split5();
                fooditems_split5[i].Pic = (Image)o2;
                fooditems_split5[i].Fname = foods[i];
                fooditems_split5[i].Price = prices[i];

                fooditems_split5[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                fooditems_split5[i].WasClicked += Fooditem_Split5_WasClicked;
                food_panel_split5.Controls.Add(fooditems_split5[i]);
            }
            
            //INGREDIENTS
            string[] ings = ic.Split(',');
            int ilen = ings.Length;
            //MEAT INGREDIENTS
            string[] meat = new string[ilen];
            i = 0;
            foreach (string ing in ings)
            {
                string qry3 = "SELECT * FROM tbl_ingredients WHERE in_name = '" + ing + "' AND in_type = 'Meat'";
                SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                SQLiteDataReader result3 = myCommand3.ExecuteReader();
                if (result3.HasRows)
                {
                    while (result3.Read())
                    {
                        meat[i] = result3["in_name"].ToString();
                        i++;
                    }
                }
            }
            meat = meat.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (i = 0; i < meat.Length; i++)
            {
                box_split1[i] = new CheckBox();
                box_split1[i].Tag = i.ToString();
                box_split1[i].Checked = true;
                box_split1[i].Text = meat[i];
                box_split1[i].AutoSize = false;
                box_split1[i].Width = 220;
                box_split1[i].Height = 27;
                box_split1[i].Font = new Font(box_split1[i].Font.FontFamily, 13);
                box_split1[i].CheckedChanged += new EventHandler(box_split1_CheckedChanged);
                meatlayout_split1.Controls.Add(box_split1[i]);
            }

            for (i = 0; i < meat.Length; i++)
            {
                box_split2[i] = new CheckBox();
                box_split2[i].Tag = i.ToString();
                box_split2[i].Checked = true;
                box_split2[i].Text = meat[i];
                box_split2[i].AutoSize = false;
                box_split2[i].Width = 220;
                box_split2[i].Height = 27;
                box_split2[i].Font = new Font(box_split2[i].Font.FontFamily, 13);
                box_split2[i].CheckedChanged += new EventHandler(box_split2_CheckedChanged);
                meatlayout_split2.Controls.Add(box_split2[i]);
            }

            for (i = 0; i < meat.Length; i++)
            {
                box_split3[i] = new CheckBox();
                box_split3[i].Tag = i.ToString();
                box_split3[i].Checked = true;
                box_split3[i].Text = meat[i];
                box_split3[i].AutoSize = false;
                box_split3[i].Width = 220;
                box_split3[i].Height = 27;
                box_split3[i].Font = new Font(box_split3[i].Font.FontFamily, 13);
                box_split3[i].CheckedChanged += new EventHandler(box_split3_CheckedChanged);
                meatlayout_split3.Controls.Add(box_split3[i]);
            }

            for (i = 0; i < meat.Length; i++)
            {
                box_split4[i] = new CheckBox();
                box_split4[i].Tag = i.ToString();
                box_split4[i].Checked = true;
                box_split4[i].Text = meat[i];
                box_split4[i].AutoSize = false;
                box_split4[i].Width = 220;
                box_split4[i].Height = 27;
                box_split4[i].Font = new Font(box_split4[i].Font.FontFamily, 13);
                box_split4[i].CheckedChanged += new EventHandler(box_split4_CheckedChanged);
                meatlayout_split4.Controls.Add(box_split4[i]);
            }

            for (i = 0; i < meat.Length; i++)
            {
                box_split5[i] = new CheckBox();
                box_split5[i].Tag = i.ToString();
                box_split5[i].Checked = true;
                box_split5[i].Text = meat[i];
                box_split5[i].AutoSize = false;
                box_split5[i].Width = 220;
                box_split5[i].Height = 27;
                box_split5[i].Font = new Font(box_split5[i].Font.FontFamily, 13);
                box_split5[i].CheckedChanged += new EventHandler(box_split5_CheckedChanged);
                meatlayout_split5.Controls.Add(box_split5[i]);
            }

            //VEGGIE INGREDIENTS
            string[] veggie = new string[ilen];
            i = 0;
            foreach (string ing in ings)
            {
                string qry3 = "SELECT * FROM tbl_ingredients WHERE in_name = '" + ing + "' AND in_type = 'Veggie'";
                SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                SQLiteDataReader result3 = myCommand3.ExecuteReader();
                if (result3.HasRows)
                {
                    while (result3.Read())
                    {
                        veggie[i] = result3["in_name"].ToString();
                        i++;
                    }
                }
            }
            veggie = veggie.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (i = 0; i < veggie.Length; i++)
            {
                box2_split1[i] = new CheckBox();
                box2_split1[i].Tag = i.ToString();
                box2_split1[i].Checked = true;
                box2_split1[i].Text = veggie[i];
                box2_split1[i].AutoSize = false;
                box2_split1[i].Width = 220;
                box2_split1[i].Height = 27;
                box2_split1[i].Font = new Font(box2_split1[i].Font.FontFamily, 13);
                box2_split1[i].CheckedChanged += new EventHandler(box2_split1_CheckedChanged);
                veggielayout_split1.Controls.Add(box2_split1[i]);
            }

            for (i = 0; i < veggie.Length; i++)
            {
                box2_split2[i] = new CheckBox();
                box2_split2[i].Tag = i.ToString();
                box2_split2[i].Checked = true;
                box2_split2[i].Text = veggie[i];
                box2_split2[i].AutoSize = false;
                box2_split2[i].Width = 220;
                box2_split2[i].Height = 27;
                box2_split2[i].Font = new Font(box2_split2[i].Font.FontFamily, 13);
                box2_split2[i].CheckedChanged += new EventHandler(box2_split2_CheckedChanged);
                veggielayout_split2.Controls.Add(box2_split2[i]);
            }

            for (i = 0; i < veggie.Length; i++)
            {
                box2_split3[i] = new CheckBox();
                box2_split3[i].Tag = i.ToString();
                box2_split3[i].Checked = true;
                box2_split3[i].Text = veggie[i];
                box2_split3[i].AutoSize = false;
                box2_split3[i].Width = 220;
                box2_split3[i].Height = 27;
                box2_split3[i].Font = new Font(box2_split3[i].Font.FontFamily, 13);
                box2_split3[i].CheckedChanged += new EventHandler(box2_split3_CheckedChanged);
                veggielayout_split3.Controls.Add(box2_split3[i]);
            }

            for (i = 0; i < veggie.Length; i++)
            {
                box2_split4[i] = new CheckBox();
                box2_split4[i].Tag = i.ToString();
                box2_split4[i].Checked = true;
                box2_split4[i].Text = veggie[i];
                box2_split4[i].AutoSize = false;
                box2_split4[i].Width = 220;
                box2_split4[i].Height = 27;
                box2_split4[i].Font = new Font(box2_split4[i].Font.FontFamily, 13);
                box2_split4[i].CheckedChanged += new EventHandler(box2_split4_CheckedChanged);
                veggielayout_split4.Controls.Add(box2_split4[i]);
            }

            for (i = 0; i < veggie.Length; i++)
            {
                box2_split5[i] = new CheckBox();
                box2_split5[i].Tag = i.ToString();
                box2_split5[i].Checked = true;
                box2_split5[i].Text = veggie[i];
                box2_split5[i].AutoSize = false;
                box2_split5[i].Width = 220;
                box2_split5[i].Height = 27;
                box2_split5[i].Font = new Font(box2_split5[i].Font.FontFamily, 13);
                box2_split5[i].CheckedChanged += new EventHandler(box2_split5_CheckedChanged);
                veggielayout_split5.Controls.Add(box2_split5[i]);
            }

            //SAUCE INGREDIENTS
            string[] sauce = new string[ilen];
            i = 0;
            foreach (string ing in ings)
            {
                string qry3 = "SELECT * FROM tbl_ingredients WHERE in_name = '" + ing + "' AND in_type = 'Sauce'";
                SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                SQLiteDataReader result3 = myCommand3.ExecuteReader();
                if (result3.HasRows)
                {
                    while (result3.Read())
                    {
                        sauce[i] = result3["in_name"].ToString();
                        i++;
                    }
                }
            }
            sauce = sauce.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            for (i = 0; i < sauce.Length; i++)
            {
                box3_split1[i] = new CheckBox();
                box3_split1[i].Tag = i.ToString();
                box3_split1[i].Checked = true;
                box3_split1[i].Text = sauce[i];
                box3_split1[i].AutoSize = false;
                box3_split1[i].Width = 220;
                box3_split1[i].Height = 27;
                box3_split1[i].Font = new Font(box3_split1[i].Font.FontFamily, 13);
                box3_split1[i].CheckedChanged += new EventHandler(box3_split1_CheckedChanged);
                saucelayout_split1.Controls.Add(box3_split1[i]);
            }

            for (i = 0; i < sauce.Length; i++)
            {
                box3_split2[i] = new CheckBox();
                box3_split2[i].Tag = i.ToString();
                box3_split2[i].Checked = true;
                box3_split2[i].Text = sauce[i];
                box3_split2[i].AutoSize = false;
                box3_split2[i].Width = 220;
                box3_split2[i].Height = 27;
                box3_split2[i].Font = new Font(box3_split2[i].Font.FontFamily, 13);
                box3_split2[i].CheckedChanged += new EventHandler(box3_split2_CheckedChanged);
                saucelayout_split2.Controls.Add(box3_split2[i]);
            }

            for (i = 0; i < sauce.Length; i++)
            {
                box3_split3[i] = new CheckBox();
                box3_split3[i].Tag = i.ToString();
                box3_split3[i].Checked = true;
                box3_split3[i].Text = sauce[i];
                box3_split3[i].AutoSize = false;
                box3_split3[i].Width = 220;
                box3_split3[i].Height = 27;
                box3_split3[i].Font = new Font(box3_split3[i].Font.FontFamily, 13);
                box3_split3[i].CheckedChanged += new EventHandler(box3_split3_CheckedChanged);
                saucelayout_split3.Controls.Add(box3_split3[i]);
            }

            for (i = 0; i < sauce.Length; i++)
            {
                box3_split4[i] = new CheckBox();
                box3_split4[i].Tag = i.ToString();
                box3_split4[i].Checked = true;
                box3_split4[i].Text = sauce[i];
                box3_split4[i].AutoSize = false;
                box3_split4[i].Width = 220;
                box3_split4[i].Height = 27;
                box3_split4[i].Font = new Font(box3_split4[i].Font.FontFamily, 13);
                box3_split4[i].CheckedChanged += new EventHandler(box3_split4_CheckedChanged);
                saucelayout_split4.Controls.Add(box3_split4[i]);
            }

            for (i = 0; i < sauce.Length; i++)
            {
                box3_split5[i] = new CheckBox();
                box3_split5[i].Tag = i.ToString();
                box3_split5[i].Checked = true;
                box3_split5[i].Text = sauce[i];
                box3_split5[i].AutoSize = false;
                box3_split5[i].Width = 220;
                box3_split5[i].Height = 27;
                box3_split5[i].Font = new Font(box3_split5[i].Font.FontFamily, 13);
                box3_split5[i].CheckedChanged += new EventHandler(box3_split5_CheckedChanged);
                saucelayout_split5.Controls.Add(box3_split5[i]);
            }

            closeConnection();
        }

        private void box_split1_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box_split1.Length];
            Array.Copy(box_split1, b, box_split1.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingmeat1 = toDisplay;
            xingmeat1 = toDisplay2;
        }

        private void box_split2_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box_split2.Length];
            Array.Copy(box_split2, b, box_split2.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingmeat2 = toDisplay;
            xingmeat2 = toDisplay2;
        }

        private void box_split3_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box_split3.Length];
            Array.Copy(box_split3, b, box_split3.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingmeat3 = toDisplay;
            xingmeat3 = toDisplay2;
        }

        private void box_split4_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box_split4.Length];
            Array.Copy(box_split4, b, box_split4.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingmeat4 = toDisplay;
            xingmeat4 = toDisplay2;
        }

        private void box_split5_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box_split5.Length];
            Array.Copy(box_split5, b, box_split5.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingmeat5 = toDisplay;
            xingmeat5 = toDisplay2;
        }

        private void box2_split1_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box2_split1.Length];
            Array.Copy(box2_split1, b, box2_split1.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingveggie1 = toDisplay;
            xingveggie1 = toDisplay2;
        }

        private void box2_split2_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box2_split2.Length];
            Array.Copy(box2_split2, b, box2_split2.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingveggie2 = toDisplay;
            xingveggie2 = toDisplay2;
        }

        private void box2_split3_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box2_split3.Length];
            Array.Copy(box2_split3, b, box2_split3.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingveggie3 = toDisplay;
            xingveggie3 = toDisplay2;
        }

        private void box2_split4_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box2_split4.Length];
            Array.Copy(box2_split4, b, box2_split4.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingveggie4 = toDisplay;
            xingveggie4 = toDisplay2;
        }

        private void box2_split5_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box2_split5.Length];
            Array.Copy(box2_split5, b, box2_split5.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingveggie5 = toDisplay;
            xingveggie5 = toDisplay2;
        }

        private void box3_split1_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box3_split1.Length];
            Array.Copy(box3_split1, b, box3_split1.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingsauce1 = toDisplay;
            xingsauce1 = toDisplay2;
        }

        private void box3_split2_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box3_split2.Length];
            Array.Copy(box3_split2, b, box3_split2.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingsauce2 = toDisplay;
            xingsauce2 = toDisplay2;
        }

        private void box3_split3_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box3_split3.Length];
            Array.Copy(box3_split3, b, box3_split3.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingsauce3 = toDisplay;
            xingsauce3 = toDisplay2;
        }

        private void box3_split4_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box3_split4.Length];
            Array.Copy(box3_split4, b, box3_split4.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingsauce4 = toDisplay;
            xingsauce4 = toDisplay2;
        }

        private void box3_split5_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box3_split5.Length];
            Array.Copy(box3_split5, b, box3_split5.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Checked == true)
                {
                    s[i] = b[i].Text;
                }
                if (!b[i].Checked == true)
                {
                    s2[i] = b[i].Text;
                }
            }

            s = s.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            s2 = s2.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string toDisplay = string.Join(",", s);
            string toDisplay2 = string.Join(",", s2);
            ingsauce5 = toDisplay;
            xingsauce5 = toDisplay2;
        }

        public void getext1(string[] extmeat, string[] extveggie, string[] extsauce, string plat)
        {
            string em = "";
            string ev = "";
            string es = "";
            string e = "";
            string rice = "";
            string pita = "";
            int i = 0;
            //string toDisplay = string.Join(Environment.NewLine, extmeat);
            //MessageBox.Show(toDisplay.ToString());
            for (i = 0; i < extmeat.Length; i++)
            {
                if (extmeat[i] == "Beef")
                    em = em + "(no beef) ";
                else if (extmeat[i] == "Chicken")
                    em = em + "(no chicken) ";
                else if (extmeat[i] == "Kebab")
                    em = em + "(no kebab) ";
                else if (extmeat[i] == "Beef Steak")
                    em = em + "(no steak) ";
                else if (extmeat[i] == "Chicken Steak")
                    em = em + "(no steak) ";
            }
            if (plat == "Platter")
            {
                if (em == "(no kebab) (no beef) " || em == "(no beef) (no chicken) " || em == "(no kebab) (no chicken) ")
                {
                    em = "(vegetarian) ";
                }
            }
            else
            {
                if (em == "(no beef) " || em == "(no chicken) " || em == "(no kebab) " || em == "(no steak) ")
                {
                    em = "(vegetarian) ";
                }
            }

            //string toDisplay2 = string.Join(Environment.NewLine, extveggie);
            //MessageBox.Show(toDisplay2.ToString());
            for (i = 0; i < extveggie.Length; i++)
            {
                if (extveggie[i] == "Mini Pita")
                    pita += "(no pita) ";
                else if (extveggie[i] == "Tomatoes")
                    ev += "(no tomatoes) ";
                else if (extveggie[i] == "Onions")
                    ev += "(no onions) ";
                else if (extveggie[i] == "Cucumber")
                    ev += "(no cucumber) ";
                else if (extveggie[i] == "Rice")
                    rice += "(no rice) ";
            }
            if (ev == "(no tomatoes) (no onions) (no cucumber) ")
                ev = "(no veggies) ";
            ev = rice + ev + pita;
            //string toDisplay3 = string.Join(Environment.NewLine, extsauce);
            //MessageBox.Show(toDisplay3.ToString());
            for (i = 0; i < extsauce.Length; i++)
            {
                if (extsauce[i] == "Cheese Sauce")
                    es = es + "(no cheese sauce) ";
                else if (extsauce[i] == "Garlic Sauce")
                    es = es + "(no garlic sauce) ";
            }
            if (es == "(no cheese sauce) (no garlic sauce) " || es == "(no garlic sauce) (no cheese sauce) ")
                es = "(no sauce) ";

            e = em + ev + es;

            if (em == "(vegetarian) " && ev == "(no veggies) ")
                e = "(sauce only) ";
            //MessageBox.Show(e);
            oext1 = e;
        }

        public void getext2(string[] extmeat, string[] extveggie, string[] extsauce, string plat)
        {
            string em = "";
            string ev = "";
            string es = "";
            string e = "";
            string rice = "";
            string pita = "";
            int i = 0;
            //string toDisplay = string.Join(Environment.NewLine, extmeat);
            //MessageBox.Show(toDisplay.ToString());
            for (i = 0; i < extmeat.Length; i++)
            {
                if (extmeat[i] == "Beef")
                    em = em + "(no beef) ";
                else if (extmeat[i] == "Chicken")
                    em = em + "(no chicken) ";
                else if (extmeat[i] == "Kebab")
                    em = em + "(no kebab) ";
                else if (extmeat[i] == "Beef Steak")
                    em = em + "(no steak) ";
                else if (extmeat[i] == "Chicken Steak")
                    em = em + "(no steak) ";
            }
            if (plat == "Platter")
            {
                if (em == "(no kebab) (no beef) " || em == "(no beef) (no chicken) " || em == "(no kebab) (no chicken) ")
                {
                    em = "(vegetarian) ";
                }
            }
            else
            {
                if (em == "(no beef) " || em == "(no chicken) " || em == "(no kebab) " || em == "(no steak) ")
                {
                    em = "(vegetarian) ";
                }
            }

            //string toDisplay2 = string.Join(Environment.NewLine, extveggie);
            //MessageBox.Show(toDisplay2.ToString());
            for (i = 0; i < extveggie.Length; i++)
            {
                if (extveggie[i] == "Mini Pita")
                    pita += "(no pita) ";
                else if (extveggie[i] == "Tomatoes")
                    ev += "(no tomatoes) ";
                else if (extveggie[i] == "Onions")
                    ev += "(no onions) ";
                else if (extveggie[i] == "Cucumber")
                    ev += "(no cucumber) ";
                else if (extveggie[i] == "Rice")
                    rice += "(no rice) ";
            }
            if (ev == "(no tomatoes) (no onions) (no cucumber) ")
                ev = "(no veggies) ";
            ev = rice + ev + pita;
            //string toDisplay3 = string.Join(Environment.NewLine, extsauce);
            //MessageBox.Show(toDisplay3.ToString());
            for (i = 0; i < extsauce.Length; i++)
            {
                if (extsauce[i] == "Cheese Sauce")
                    es = es + "(no cheese sauce) ";
                else if (extsauce[i] == "Garlic Sauce")
                    es = es + "(no garlic sauce) ";
            }
            if (es == "(no cheese sauce) (no garlic sauce) " || es == "(no garlic sauce) (no cheese sauce) ")
                es = "(no sauce) ";

            e = em + ev + es;

            if (em == "(vegetarian) " && ev == "(no veggies) ")
                e = "(sauce only) ";
            //MessageBox.Show(e);
            oext2 = e;
        }

        public void getext3(string[] extmeat, string[] extveggie, string[] extsauce, string plat)
        {
            string em = "";
            string ev = "";
            string es = "";
            string e = "";
            string rice = "";
            string pita = "";
            int i = 0;
            //string toDisplay = string.Join(Environment.NewLine, extmeat);
            //MessageBox.Show(toDisplay.ToString());
            for (i = 0; i < extmeat.Length; i++)
            {
                if (extmeat[i] == "Beef")
                    em = em + "(no beef) ";
                else if (extmeat[i] == "Chicken")
                    em = em + "(no chicken) ";
                else if (extmeat[i] == "Kebab")
                    em = em + "(no kebab) ";
                else if (extmeat[i] == "Beef Steak")
                    em = em + "(no steak) ";
                else if (extmeat[i] == "Chicken Steak")
                    em = em + "(no steak) ";
            }
            if (plat == "Platter")
            {
                if (em == "(no kebab) (no beef) " || em == "(no beef) (no chicken) " || em == "(no kebab) (no chicken) ")
                {
                    em = "(vegetarian) ";
                }
            }
            else
            {
                if (em == "(no beef) " || em == "(no chicken) " || em == "(no kebab) " || em == "(no steak) ")
                {
                    em = "(vegetarian) ";
                }
            }

            //string toDisplay2 = string.Join(Environment.NewLine, extveggie);
            //MessageBox.Show(toDisplay2.ToString());
            for (i = 0; i < extveggie.Length; i++)
            {
                if (extveggie[i] == "Mini Pita")
                    pita += "(no pita) ";
                else if (extveggie[i] == "Tomatoes")
                    ev += "(no tomatoes) ";
                else if (extveggie[i] == "Onions")
                    ev += "(no onions) ";
                else if (extveggie[i] == "Cucumber")
                    ev += "(no cucumber) ";
                else if (extveggie[i] == "Rice")
                    rice += "(no rice) ";
            }
            if (ev == "(no tomatoes) (no onions) (no cucumber) ")
                ev = "(no veggies) ";
            ev = rice + ev + pita;
            //string toDisplay3 = string.Join(Environment.NewLine, extsauce);
            //MessageBox.Show(toDisplay3.ToString());
            for (i = 0; i < extsauce.Length; i++)
            {
                if (extsauce[i] == "Cheese Sauce")
                    es = es + "(no cheese sauce) ";
                else if (extsauce[i] == "Garlic Sauce")
                    es = es + "(no garlic sauce) ";
            }
            if (es == "(no cheese sauce) (no garlic sauce) " || es == "(no garlic sauce) (no cheese sauce) ")
                es = "(no sauce) ";

            e = em + ev + es;

            if (em == "(vegetarian) " && ev == "(no veggies) ")
                e = "(sauce only) ";
            //MessageBox.Show(e);
            oext3 = e;
        }

        public void getext4(string[] extmeat, string[] extveggie, string[] extsauce, string plat)
        {
            string em = "";
            string ev = "";
            string es = "";
            string e = "";
            string rice = "";
            string pita = "";
            int i = 0;
            //string toDisplay = string.Join(Environment.NewLine, extmeat);
            //MessageBox.Show(toDisplay.ToString());
            for (i = 0; i < extmeat.Length; i++)
            {
                if (extmeat[i] == "Beef")
                    em = em + "(no beef) ";
                else if (extmeat[i] == "Chicken")
                    em = em + "(no chicken) ";
                else if (extmeat[i] == "Kebab")
                    em = em + "(no kebab) ";
                else if (extmeat[i] == "Beef Steak")
                    em = em + "(no steak) ";
                else if (extmeat[i] == "Chicken Steak")
                    em = em + "(no steak) ";
            }
            if (plat == "Platter")
            {
                if (em == "(no kebab) (no beef) " || em == "(no beef) (no chicken) " || em == "(no kebab) (no chicken) ")
                {
                    em = "(vegetarian) ";
                }
            }
            else
            {
                if (em == "(no beef) " || em == "(no chicken) " || em == "(no kebab) " || em == "(no steak) ")
                {
                    em = "(vegetarian) ";
                }
            }

            //string toDisplay2 = string.Join(Environment.NewLine, extveggie);
            //MessageBox.Show(toDisplay2.ToString());
            for (i = 0; i < extveggie.Length; i++)
            {
                if (extveggie[i] == "Mini Pita")
                    pita += "(no pita) ";
                else if (extveggie[i] == "Tomatoes")
                    ev += "(no tomatoes) ";
                else if (extveggie[i] == "Onions")
                    ev += "(no onions) ";
                else if (extveggie[i] == "Cucumber")
                    ev += "(no cucumber) ";
                else if (extveggie[i] == "Rice")
                    rice += "(no rice) ";
            }
            if (ev == "(no tomatoes) (no onions) (no cucumber) ")
                ev = "(no veggies) ";
            ev = rice + ev + pita;
            //string toDisplay3 = string.Join(Environment.NewLine, extsauce);
            //MessageBox.Show(toDisplay3.ToString());
            for (i = 0; i < extsauce.Length; i++)
            {
                if (extsauce[i] == "Cheese Sauce")
                    es = es + "(no cheese sauce) ";
                else if (extsauce[i] == "Garlic Sauce")
                    es = es + "(no garlic sauce) ";
            }
            if (es == "(no cheese sauce) (no garlic sauce) " || es == "(no garlic sauce) (no cheese sauce) ")
                es = "(no sauce) ";

            e = em + ev + es;

            if (em == "(vegetarian) " && ev == "(no veggies) ")
                e = "(sauce only) ";
            //MessageBox.Show(e);
            oext4 = e;
        }

        public void getext5(string[] extmeat, string[] extveggie, string[] extsauce, string plat)
        {
            string em = "";
            string ev = "";
            string es = "";
            string e = "";
            string rice = "";
            string pita = "";
            int i = 0;
            //string toDisplay = string.Join(Environment.NewLine, extmeat);
            //MessageBox.Show(toDisplay.ToString());
            for (i = 0; i < extmeat.Length; i++)
            {
                if (extmeat[i] == "Beef")
                    em = em + "(no beef) ";
                else if (extmeat[i] == "Chicken")
                    em = em + "(no chicken) ";
                else if (extmeat[i] == "Kebab")
                    em = em + "(no kebab) ";
                else if (extmeat[i] == "Beef Steak")
                    em = em + "(no steak) ";
                else if (extmeat[i] == "Chicken Steak")
                    em = em + "(no steak) ";
            }
            if (plat == "Platter")
            {
                if (em == "(no kebab) (no beef) " || em == "(no beef) (no chicken) " || em == "(no kebab) (no chicken) ")
                {
                    em = "(vegetarian) ";
                }
            }
            else
            {
                if (em == "(no beef) " || em == "(no chicken) " || em == "(no kebab) " || em == "(no steak) ")
                {
                    em = "(vegetarian) ";
                }
            }

            //string toDisplay2 = string.Join(Environment.NewLine, extveggie);
            //MessageBox.Show(toDisplay2.ToString());
            for (i = 0; i < extveggie.Length; i++)
            {
                if (extveggie[i] == "Mini Pita")
                    pita += "(no pita) ";
                else if (extveggie[i] == "Tomatoes")
                    ev += "(no tomatoes) ";
                else if (extveggie[i] == "Onions")
                    ev += "(no onions) ";
                else if (extveggie[i] == "Cucumber")
                    ev += "(no cucumber) ";
                else if (extveggie[i] == "Rice")
                    rice += "(no rice) ";
            }
            if (ev == "(no tomatoes) (no onions) (no cucumber) ")
                ev = "(no veggies) ";
            ev = rice + ev + pita;
            //string toDisplay3 = string.Join(Environment.NewLine, extsauce);
            //MessageBox.Show(toDisplay3.ToString());
            for (i = 0; i < extsauce.Length; i++)
            {
                if (extsauce[i] == "Cheese Sauce")
                    es = es + "(no cheese sauce) ";
                else if (extsauce[i] == "Garlic Sauce")
                    es = es + "(no garlic sauce) ";
            }
            if (es == "(no cheese sauce) (no garlic sauce) " || es == "(no garlic sauce) (no cheese sauce) ")
                es = "(no sauce) ";

            e = em + ev + es;

            if (em == "(vegetarian) " && ev == "(no veggies) ")
                e = "(sauce only) ";
            //MessageBox.Show(e);
            oext5 = e;
        }

        private void cb1_split1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1_split1.Checked)
            {
                foreach (Control b in meatlayout_split1.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb1_split1.Checked)
            {
                foreach (Control b in meatlayout_split1.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb1_split2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1_split2.Checked)
            {
                foreach (Control b in meatlayout_split2.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb1_split2.Checked)
            {
                foreach (Control b in meatlayout_split2.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb1_split3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1_split3.Checked)
            {
                foreach (Control b in meatlayout_split3.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb1_split3.Checked)
            {
                foreach (Control b in meatlayout_split3.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb1_split4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1_split4.Checked)
            {
                foreach (Control b in meatlayout_split4.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb1_split4.Checked)
            {
                foreach (Control b in meatlayout_split4.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb1_split5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1_split5.Checked)
            {
                foreach (Control b in meatlayout_split5.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb1_split5.Checked)
            {
                foreach (Control b in meatlayout_split5.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb2_split1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2_split1.Checked)
            {
                foreach (Control b in veggielayout_split1.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb2_split1.Checked)
            {
                foreach (Control b in veggielayout_split1.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb2_split2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2_split2.Checked)
            {
                foreach (Control b in veggielayout_split2.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb2_split2.Checked)
            {
                foreach (Control b in veggielayout_split2.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb2_split3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2_split3.Checked)
            {
                foreach (Control b in veggielayout_split3.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb2_split3.Checked)
            {
                foreach (Control b in veggielayout_split3.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb2_split4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2_split4.Checked)
            {
                foreach (Control b in veggielayout_split4.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb2_split4.Checked)
            {
                foreach (Control b in veggielayout_split4.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb2_split5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2_split5.Checked)
            {
                foreach (Control b in veggielayout_split5.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb2_split5.Checked)
            {
                foreach (Control b in veggielayout_split5.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb3_split1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb3_split1.Checked)
            {
                foreach (Control b in saucelayout_split1.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb3_split1.Checked)
            {
                foreach (Control b in saucelayout_split1.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb3_split2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb3_split2.Checked)
            {
                foreach (Control b in saucelayout_split2.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb3_split2.Checked)
            {
                foreach (Control b in saucelayout_split2.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb3_split3_CheckedChanged(object sender, EventArgs e)
        {
            if (cb3_split3.Checked)
            {
                foreach (Control b in saucelayout_split3.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb3_split3.Checked)
            {
                foreach (Control b in saucelayout_split3.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb3_split4_CheckedChanged(object sender, EventArgs e)
        {
            if (cb3_split4.Checked)
            {
                foreach (Control b in saucelayout_split4.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb3_split4.Checked)
            {
                foreach (Control b in saucelayout_split4.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }

        private void cb3_split5_CheckedChanged(object sender, EventArgs e)
        {
            if (cb3_split5.Checked)
            {
                foreach (Control b in saucelayout_split5.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = true;
                    }
                }
            }
            else if (!cb3_split5.Checked)
            {
                foreach (Control b in saucelayout_split5.Controls)
                {
                    if (b is CheckBox)
                    {
                        CheckBox cb = (CheckBox)b;
                        cb.Checked = false;
                    }
                }
            }
        }
    }
}
