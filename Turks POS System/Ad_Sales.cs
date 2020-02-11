using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using Turks_POS_System.Properties;
using System.Text.RegularExpressions;

namespace Turks_POS_System
{
    public partial class Ad_Sales : UserControl
    {
        public string food_type;
        public SQLiteConnection myConnection;
        public object selected;
        public object selected2;
        public object selected3;
        public object selected4;
        string ingmeat = "";
        string ingveggie = "";
        string ingsauce = "";
        string xingmeat = "";
        string xingveggie = "";
        string xingsauce = "";
        string oext = "";

        //FOOD FILTER
        public Ad_Sales()
        {
            InitializeComponent();
            FilterPanel.BringToFront();
            FilterPanel.Visible = true;
            PitaPanel.Visible = false;
            PitaPanel.Visible = false;
            RicePanel.Visible = false;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = false;

            btn_confirm.Enabled = false;
            btn_discounts.Enabled = false;
            btn_cancel.Enabled = false;
            btn_remove.Enabled = false;
            btn_editqty.Enabled = false;
            btn_split.Enabled = false;
            btn_upgrade.Enabled = false;
        }

        private void Pita_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = false;
            PitaPanel.Visible = true;
            RicePanel.Visible = false;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = false;
            food_type = (sender as Button).Name;
        }

        private void Rice_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = false;
            PitaPanel.Visible = false;
            RicePanel.Visible = true;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = false;
            food_type = (sender as Button).Name;
        }

        private void Platter_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = false;
            PitaPanel.Visible = false;
            RicePanel.Visible = false;
            PlatterPanel.Visible = true;
            SteakPanel.Visible = false;
            food_type = (sender as Button).Name;
        }

        private void Steak_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = false;
            PitaPanel.Visible = false;
            RicePanel.Visible = false;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = true;
            food_type = (sender as Button).Name;
        }

        private void pitaback_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = true;
            PitaPanel.Visible = false;
            RicePanel.Visible = false;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = false;
            foodlayout.Controls.Clear();
        }

        private void riceback_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = true;
            PitaPanel.Visible = false;
            RicePanel.Visible = false;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = false;
            foodlayout.Controls.Clear();
        }

        private void platterback_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = true;
            PitaPanel.Visible = false;
            RicePanel.Visible = false;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = false;
            foodlayout.Controls.Clear();
        }

        private void steakback_Click(object sender, EventArgs e)
        {
            FilterPanel.Visible = true;
            PitaPanel.Visible = false;
            RicePanel.Visible = false;
            PlatterPanel.Visible = false;
            SteakPanel.Visible = false;
            foodlayout.Controls.Clear();
        }

        private void solo_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void duo_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void trio_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void Solo_rice_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void Duo_rice_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void Solo_platter_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void Duo_platter_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void Solo_steak_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void Duo_steak_Click(object sender, EventArgs e)
        {
            filter(sender);
        }

        private void Add_on_Click(object sender, EventArgs e)
        {
            PitaPanel.Visible = false;
            food_type = (sender as Button).Name;
            foodlayout.Visible = true;
            foodlayout.BringToFront();

            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            //SELECT FROM DATABASE
            string qry = "SELECT * FROM tbl_menu WHERE food_type LIKE '%" + food_type + "%'";
            string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_type LIKE '%" + food_type + "%'";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            openConnection();
            int len = Convert.ToInt32(myCommand2.ExecuteScalar());
            SQLiteDataReader result = myCommand.ExecuteReader();
            string[] foods = new string[len];
            string[] img = new string[len];
            string[] prices = new string[len];
            int i = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    img[i] = result["food_image"].ToString();
                    foods[i] = result["food_name"].ToString();
                    prices[i] = "P" + result["food_price"].ToString() + ".00";
                    i++;
                }
            }
            FoodItem[] fooditems = new FoodItem[len];
            foodlayout.Controls.Clear();
            for (i = 0; i < fooditems.Length; i++)
            {
                object o = Resources.ResourceManager.GetObject(img[i]);
                fooditems[i] = new FoodItem();
                fooditems[i].Pic = (Image)o;
                fooditems[i].Fname = foods[i];
                fooditems[i].Price = prices[i];

                fooditems[i].DoubleClick += FoodItem_DoubleClick;
                fooditems[i].WasClicked += Fooditem_WasClicked;
                fooditems[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                foodlayout.Controls.Add(fooditems[i]);
            }
            closeConnection();
        }

        public void filter(object sender)
        {
            string b = (sender as Button).Name;
            string food_category = b.Substring(0, b.LastIndexOf("_"));
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            //SELECT FROM DATABASE
            string qry = "SELECT * FROM tbl_menu WHERE food_category = '" + food_category + "' and food_type LIKE '%" + food_type + "%'";
            string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_category = '" + food_category + "' and food_type LIKE '%" + food_type + "%'";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            openConnection();
            int len = Convert.ToInt32(myCommand2.ExecuteScalar());
            SQLiteDataReader result = myCommand.ExecuteReader();
            string[] foods = new string[len];
            string[] img = new string[len];
            string[] prices = new string[len];
            int i = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    img[i] = result["food_image"].ToString();
                    foods[i] = result["food_name"].ToString();
                    prices[i] = "P" + result["food_price"].ToString() + ".00";
                    i++;
                }
            }
            FoodItem[] fooditems = new FoodItem[len];
            foodlayout.Controls.Clear();
            for (i = 0; i < fooditems.Length; i++)
            {
                object o = Resources.ResourceManager.GetObject(img[i]);
                fooditems[i] = new FoodItem();
                fooditems[i].Pic = (Image)o;
                fooditems[i].Fname = foods[i];
                fooditems[i].Price = prices[i];

                fooditems[i].DoubleClick += FoodItem_DoubleClick;
                fooditems[i].WasClicked += Fooditem_WasClicked;
                fooditems[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                foodlayout.Controls.Add(fooditems[i]);
            }
            closeConnection();
        }

        public void filter2(object sender)
        {
            food_type = (sender as Button).Name;
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            //SELECT FROM DATABASE
            string qry = "SELECT * FROM tbl_menu WHERE food_type = '" + food_type + "'";
            string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_type = '" + food_type + "'";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            openConnection();
            int len = Convert.ToInt32(myCommand2.ExecuteScalar());
            SQLiteDataReader result = myCommand.ExecuteReader();
            string[] foods = new string[len];
            string[] img = new string[len];
            string[] prices = new string[len];
            int i = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    img[i] = result["food_image"].ToString();
                    foods[i] = result["food_name"].ToString();
                    prices[i] = "P" + result["food_price"].ToString() + ".00";
                    i++;
                }
            }
            FoodItem[] fooditems = new FoodItem[len];
            foodlayout.Controls.Clear();
            for (i = 0; i < fooditems.Length; i++)
            {
                object o = Resources.ResourceManager.GetObject(img[i]);
                fooditems[i] = new FoodItem();
                fooditems[i].Pic = (Image)o;
                fooditems[i].Fname = foods[i];
                fooditems[i].Price = prices[i];

                fooditems[i].DoubleClick += FoodItem_DoubleClick;
                fooditems[i].WasClicked += Fooditem_WasClicked;
                fooditems[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                foodlayout.Controls.Add(fooditems[i]);
            }
            closeConnection();
        }
        //END OF FOOD FILTER

        //ORDER LIST
        public int total = 0;

        void FoodItem_DoubleClick(object sender, EventArgs e)
        {
            ingmeat = "";
            ingveggie = "";
            ingsauce = "";
            xingmeat = "";
            xingveggie = "";
            xingsauce = "";
            foreach (Control c in foodlayout.Controls)
            {
                if (c is FoodItem)
                {
                    if (c == selected2)
                    {
                        using (Preupgrade_Dialog p = new Preupgrade_Dialog())
                        {
                            p.inp = 1.ToString();
                            p.Owner = frm;
                            p.StartPosition = FormStartPosition.CenterParent;

                            string fn = ((FoodItem)c).Fname;
                            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                            //SELECT FROM DATABASE
                            string query = "SELECT * FROM tbl_menu WHERE food_name = '" + fn + "'";
                            SQLiteCommand myCmd = new SQLiteCommand(query, myConnection);

                            openConnection();
                            SQLiteDataReader result = myCmd.ExecuteReader();
                            string f = "";
                            string ims = "";
                            string ps = "";
                            if (result.HasRows)
                            {
                                while (result.Read())
                                {
                                    ims = result["food_image"].ToString();
                                    f = result["food_name"].ToString();
                                    ps = "P" + result["food_price"].ToString() + ".00";
                                }
                            }
                            closeConnection();

                            FoodItemEx fooditemex = new FoodItemEx();
                            object o = Resources.ResourceManager.GetObject(ims);
                            fooditemex = new FoodItemEx();
                            fooditemex.Pic = (Image)o;
                            fooditemex.Fname = f;
                            fooditemex.Price = ps;

                            p.currentfood.Controls.Add(fooditemex);

                            string plat = "";

                            if (Regex.Matches(((FoodItem)c).Fname, "Pita").Count == 1 || Regex.Matches(((FoodItem)c).Fname, "Wrap").Count == 1)
                            {
                                fetchings("Pita", (FoodItem)c, p);
                            }
                            else if (Regex.Matches(((FoodItem)c).Fname, "Rice").Count == 1 || Regex.Matches(((FoodItem)c).Fname, "Bowl").Count == 1)
                            {
                                fetchings("Rice", (FoodItem)c, p);
                            }
                            else if (Regex.Matches(((FoodItem)c).Fname, "Platter").Count == 1)
                            {
                                fetchings("Platter", (FoodItem)c, p);
                                plat = "Platter";
                            }
                            else if (Regex.Matches(((FoodItem)c).Fname, "Steak").Count == 1)
                            {
                                fetchings("Steak", (FoodItem)c, p);
                            }

                            //OPEN DIALOG
                            DialogResult dialog = p.ShowDialog();
                            if (dialog == DialogResult.OK)
                            {
                                string[] extmeat = xingmeat.Split(',');
                                string[] extveggie = xingveggie.Split(',');
                                string[] extsauce = xingsauce.Split(',');
                                getext(extmeat, extveggie, extsauce, plat);
                                string orderextention = oext;
                                string n = p.uname;

                                if (n != null && orderextention != "")
                                {
                                    //REPLACE
                                    myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                                    string qry = "SELECT * FROM tbl_upgrades WHERE up_name = '" + n + "'";
                                    SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);

                                    openConnection();
                                    SQLiteDataReader r = myCommand.ExecuteReader();
                                    string itemname = "";
                                    string unitprice = "";
                                    int itemsubtotal = 0;
                                    if (r.HasRows)
                                    {
                                        while (r.Read())
                                        {
                                            itemname = r["up_name"].ToString();
                                            unitprice = r["up_price"].ToString();
                                            itemsubtotal += Convert.ToInt32(r["up_price"]);
                                        }
                                    }
                                    if (orderextention != "")
                                        itemname = itemname + " " + orderextention;

                                    if (OrderList.Controls.Count > 0)
                                    {
                                        int cnt = 0;
                                        foreach (Control c2 in OrderList.Controls)
                                        {
                                            if (c2 is OrderItem)
                                            {
                                                if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                {
                                                    //cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                    cnt++;
                                                    int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                    int up = Convert.ToInt32(unitprice) * Convert.ToInt32(p.inp);
                                                    itemqty += Convert.ToInt32(p.inp);
                                                    int sub2 = itemqty * itemsubtotal;
                                                    ((OrderItem)c2).Qty = itemqty.ToString();
                                                    ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                    total += up;
                                                    item_total.Text = "P" + total.ToString() + ".00";
                                                }
                                            }
                                        }
                                        if (cnt == 0)
                                        {
                                            int itemqty = 0;
                                            itemqty += Convert.ToInt32(p.inp);
                                            OrderItem orderitems = new OrderItem();
                                            orderitems.Qty = itemqty.ToString();
                                            orderitems.Oname = itemname;
                                            orderitems.Unitprice = "P" + unitprice + ".00";
                                            itemsubtotal *= itemqty;
                                            orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                            total += itemsubtotal;
                                            item_total.Text = "P" + total.ToString() + ".00";

                                            orderitems.WasClicked += OrderItem_WasClicked;
                                            OrderList.Controls.Add(orderitems);
                                        }
                                    }
                                    else
                                    {
                                        int itemqty = 0;
                                        itemqty += Convert.ToInt32(p.inp);
                                        OrderItem orderitems = new OrderItem();
                                        orderitems.Qty = itemqty.ToString();
                                        orderitems.Oname = itemname;
                                        orderitems.Unitprice = "P" + unitprice + ".00";
                                        itemsubtotal *= itemqty;
                                        orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                        item_total.Visible = true;
                                        total = itemsubtotal;
                                        item_total.Text = "P" + total.ToString() + ".00";

                                        orderitems.WasClicked += OrderItem_WasClicked;
                                        OrderList.Controls.Add(orderitems);
                                    }

                                    closeConnection();
                                    btn_confirm.Enabled = true;
                                    btn_discounts.Enabled = true;
                                    btn_cancel.Enabled = true;
                                }
                                else if (orderextention != "")
                                {
                                    //REPLACE
                                    myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                                    string qry = "SELECT * FROM tbl_menu WHERE food_name = '" + f + "'";
                                    SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);

                                    openConnection();
                                    SQLiteDataReader r = myCommand.ExecuteReader();
                                    string itemname = "";
                                    string unitprice = "";
                                    int itemsubtotal = 0;
                                    if (r.HasRows)
                                    {
                                        while (r.Read())
                                        {
                                            itemname = r["food_name"].ToString();
                                            unitprice = r["food_price"].ToString();
                                            itemsubtotal += Convert.ToInt32(r["food_price"]);
                                        }
                                    }

                                    itemname = itemname + " " + orderextention;

                                    if (OrderList.Controls.Count > 0)
                                    {
                                        int cnt = 0;
                                        foreach (Control c2 in OrderList.Controls)
                                        {
                                            if (c2 is OrderItem)
                                            {
                                                if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                {
                                                    //cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                    cnt++;
                                                    int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                    int up = Convert.ToInt32(unitprice) * Convert.ToInt32(p.inp);
                                                    itemqty += Convert.ToInt32(p.inp);
                                                    int sub2 = itemqty * itemsubtotal;
                                                    ((OrderItem)c2).Qty = itemqty.ToString();
                                                    ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                    total += up;
                                                    item_total.Text = "P" + total.ToString() + ".00";
                                                }
                                            }
                                        }
                                        if (cnt == 0)
                                        {
                                            int itemqty = 0;
                                            itemqty += Convert.ToInt32(p.inp);
                                            OrderItem orderitems = new OrderItem();
                                            orderitems.Qty = itemqty.ToString();
                                            orderitems.Oname = itemname;
                                            orderitems.Unitprice = "P" + unitprice + ".00";
                                            itemsubtotal *= itemqty;
                                            orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                            total += itemsubtotal;
                                            item_total.Text = "P" + total.ToString() + ".00";

                                            orderitems.WasClicked += OrderItem_WasClicked;
                                            OrderList.Controls.Add(orderitems);
                                        }
                                    }
                                    else
                                    {
                                        int itemqty = 0;
                                        itemqty += Convert.ToInt32(p.inp);
                                        OrderItem orderitems = new OrderItem();
                                        orderitems.Qty = itemqty.ToString();
                                        orderitems.Oname = itemname;
                                        orderitems.Unitprice = "P" + unitprice + ".00";
                                        itemsubtotal *= itemqty;
                                        orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                        item_total.Visible = true;
                                        total = itemsubtotal;
                                        item_total.Text = "P" + total.ToString() + ".00";

                                        orderitems.WasClicked += OrderItem_WasClicked;
                                        OrderList.Controls.Add(orderitems);
                                    }

                                    closeConnection();
                                    btn_confirm.Enabled = true;
                                    btn_discounts.Enabled = true;
                                    btn_cancel.Enabled = true;
                                }
                                else if (n != null)
                                {
                                    //REPLACE
                                    myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                                    string qry = "SELECT * FROM tbl_upgrades WHERE up_name = '" + n + "'";
                                    SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);

                                    openConnection();
                                    SQLiteDataReader r = myCommand.ExecuteReader();
                                    string itemname = "";
                                    string unitprice = "";
                                    int itemsubtotal = 0;
                                    if (r.HasRows)
                                    {
                                        while (r.Read())
                                        {
                                            itemname = r["up_name"].ToString();
                                            unitprice = r["up_price"].ToString();
                                            itemsubtotal += Convert.ToInt32(r["up_price"]);
                                        }
                                    }

                                    if (OrderList.Controls.Count > 0)
                                    {
                                        int cnt = 0;
                                        foreach (Control c2 in OrderList.Controls)
                                        {
                                            if (c2 is OrderItem)
                                            {
                                                if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                {
                                                    //cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                    cnt++;
                                                    int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                    int up = Convert.ToInt32(unitprice) * Convert.ToInt32(p.inp);
                                                    itemqty += Convert.ToInt32(p.inp);
                                                    int sub2 = itemqty * itemsubtotal;
                                                    ((OrderItem)c2).Qty = itemqty.ToString();
                                                    ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                    total += up;
                                                    item_total.Text = "P" + total.ToString() + ".00";
                                                }
                                            }
                                        }
                                        if (cnt == 0)
                                        {
                                            int itemqty = 0;
                                            itemqty += Convert.ToInt32(p.inp);
                                            OrderItem orderitems = new OrderItem();
                                            orderitems.Qty = itemqty.ToString();
                                            orderitems.Oname = itemname;
                                            orderitems.Unitprice = "P" + unitprice + ".00";
                                            itemsubtotal *= itemqty;
                                            orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                            total += itemsubtotal;
                                            item_total.Text = "P" + total.ToString() + ".00";

                                            orderitems.WasClicked += OrderItem_WasClicked;
                                            OrderList.Controls.Add(orderitems);
                                        }
                                    }
                                    else
                                    {
                                        int itemqty = 0;
                                        itemqty += Convert.ToInt32(p.inp);
                                        OrderItem orderitems = new OrderItem();
                                        orderitems.Qty = itemqty.ToString();
                                        orderitems.Oname = itemname;
                                        orderitems.Unitprice = "P" + unitprice + ".00";
                                        itemsubtotal *= itemqty;
                                        orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                        item_total.Visible = true;
                                        total = itemsubtotal;
                                        item_total.Text = "P" + total.ToString() + ".00";

                                        orderitems.WasClicked += OrderItem_WasClicked;
                                        OrderList.Controls.Add(orderitems);
                                    }

                                    closeConnection();
                                    btn_confirm.Enabled = true;
                                    btn_discounts.Enabled = true;
                                    btn_cancel.Enabled = true;
                                }
                                else
                                {
                                    myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                                    string qry = "SELECT * FROM tbl_menu WHERE food_name = '" + f + "'";
                                    SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);

                                    openConnection();
                                    SQLiteDataReader r = myCommand.ExecuteReader();
                                    string itemname = "";
                                    string unitprice = "";
                                    int itemsubtotal = 0;
                                    if (r.HasRows)
                                    {
                                        while (r.Read())
                                        {
                                            itemname = r["food_name"].ToString();
                                            unitprice = r["food_price"].ToString();
                                            itemsubtotal += Convert.ToInt32(r["food_price"]);
                                        }
                                    }

                                    if (OrderList.Controls.Count > 0)
                                    {
                                        int cnt = 0;
                                        foreach (Control c2 in OrderList.Controls)
                                        {
                                            if (c2 is OrderItem)
                                            {
                                                if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                {
                                                    //cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                    cnt++;
                                                    int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                    int up = Convert.ToInt32(unitprice) * Convert.ToInt32(p.inp);
                                                    itemqty += Convert.ToInt32(p.inp);
                                                    int sub2 = itemqty * itemsubtotal;
                                                    ((OrderItem)c2).Qty = itemqty.ToString();
                                                    ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                    total += up;
                                                    item_total.Text = "P" + total.ToString() + ".00";
                                                }
                                            }
                                        }
                                        if (cnt == 0)
                                        {
                                            int itemqty = 0;
                                            itemqty += Convert.ToInt32(p.inp);
                                            OrderItem orderitems = new OrderItem();
                                            orderitems.Qty = itemqty.ToString();
                                            orderitems.Oname = itemname;
                                            orderitems.Unitprice = "P" + unitprice + ".00";
                                            itemsubtotal *= itemqty;
                                            orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                            total += itemsubtotal;
                                            item_total.Text = "P" + total.ToString() + ".00";

                                            orderitems.WasClicked += OrderItem_WasClicked;
                                            OrderList.Controls.Add(orderitems);
                                        }
                                    }
                                    else
                                    {
                                        int itemqty = 0;
                                        itemqty += Convert.ToInt32(p.inp);
                                        OrderItem orderitems = new OrderItem();
                                        orderitems.Qty = itemqty.ToString();
                                        orderitems.Oname = itemname;
                                        orderitems.Unitprice = "P" + unitprice + ".00";
                                        itemsubtotal *= itemqty;
                                        orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                        item_total.Visible = true;
                                        total = itemsubtotal;
                                        item_total.Text = "P" + total.ToString() + ".00";

                                        orderitems.WasClicked += OrderItem_WasClicked;
                                        OrderList.Controls.Add(orderitems);
                                    }

                                    closeConnection();
                                    btn_confirm.Enabled = true;
                                    btn_discounts.Enabled = true;
                                    btn_cancel.Enabled = true;
                                }
                            }
                            else if(dialog == DialogResult.Yes)
                            {
                                List<string> qty = new List<string>();
                                List<string> ns = new List<string>();
                                List<string> fns = new List<string>();
                                string n1 = p.uname1;
                                string n2 = p.uname2;
                                string n3 = p.uname3;
                                string n4 = p.uname4;
                                string n5 = p.uname5;
                                string q1 = p.inp1;
                                string q2 = p.inp2;
                                string q3 = p.inp3;
                                string q4 = p.inp4;
                                string q5 = p.inp5;
                                string oe1 = p.oext1;
                                string oe2 = p.oext2;
                                string oe3 = p.oext3;
                                string oe4 = p.oext4;
                                string oe5 = p.oext5;
                                if (q1 == null)
                                {
                                    n1 = "";
                                    q1 = "";
                                }
                                else
                                {
                                    qty.Add(q1);
                                }
                                if (q2 == null)
                                {
                                    n2 = "";
                                    q2 = "";
                                }
                                else
                                {
                                    qty.Add(q2);
                                }
                                if (q3 == null)
                                {
                                    n3 = "";
                                    q3 = "";
                                }
                                else
                                {
                                    qty.Add(q3);
                                }
                                if (q4 == null)
                                {
                                    n4 = "";
                                    q4 = "";
                                }
                                else
                                {
                                    qty.Add(q4);
                                }
                                if (q5 == null)
                                {
                                    n5 = "";
                                    q5 = "";
                                }
                                else
                                {
                                    qty.Add(q5);
                                }
                                if (n1 == null && q1 != null)
                                {
                                    n1 = f;
                                }
                                if (n2 == null && q1 != null)
                                {
                                    n2 = f;
                                }
                                if (n3 == null && q1 != null)
                                {
                                    n3 = f;
                                }
                                if (n4 == null && q1 != null)
                                {
                                    n4 = f;
                                }
                                if (n5 == null && q1 != null)
                                {
                                    n5 = f;
                                }

                                if (n1 != "")
                                {
                                    fns.Add(n1);
                                    if (oe1 != "")
                                    {
                                        n1 += " " + oe1;
                                    }
                                    ns.Add(n1);
                                }
                                if (n2 != "")
                                {
                                    fns.Add(n2);
                                    if (oe2 != "")
                                    {
                                        n2 += " " + oe2;
                                    }
                                    ns.Add(n2);
                                }
                                if (n3 != "")
                                {
                                    fns.Add(n3);
                                    if (oe3 != "")
                                    {
                                        n3 += " " + oe3;
                                    }
                                    ns.Add(n3);
                                }
                                if (n4 != "")
                                {
                                    fns.Add(n4);
                                    if (oe4 != "")
                                    {
                                        n4 += " " + oe4;
                                    }
                                    ns.Add(n4);
                                }
                                if (n5 != "")
                                {
                                    fns.Add(n5);
                                    if (oe5 != "")
                                    {
                                        n5 += " " + oe5;
                                    }
                                    ns.Add(n5);
                                }
                                fns.ToArray();
                                ns.ToArray();
                                qty.ToArray();
                                //string toDisplay = string.Join(Environment.NewLine, ns);
                                //string toDisplay2 = string.Join(Environment.NewLine, qty);
                                //MessageBox.Show(toDisplay);
                                int j = 0;
                                for (int i = 0; i < ns.Count; i++)
                                {
                                    myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                                    string qry = "SELECT * FROM tbl_menu WHERE food_name = '" + ns[i] + "'";
                                    string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_name = '" + ns[i] + "'";
                                    SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
                                    SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);
                                    string query1 = "SELECT * FROM tbl_upgrades WHERE up_name = '" + ns[i] + "'";
                                    string query2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_name = '" + ns[i] + "'";
                                    SQLiteCommand Cmd = new SQLiteCommand(query1, myConnection);
                                    SQLiteCommand Cmd2 = new SQLiteCommand(query2, myConnection);
                                    openConnection();
                                    int check = Convert.ToInt32(myCommand2.ExecuteScalar());
                                    int check2 = Convert.ToInt32(Cmd2.ExecuteScalar());
                                    if(check != 0)
                                    {
                                        SQLiteDataReader r = myCommand.ExecuteReader();
                                        string itemname = ns[i];
                                        string unitprice = "";
                                        int itemsubtotal = 0;
                                        if (r.HasRows)
                                        {
                                            while (r.Read())
                                            {
                                                unitprice = r["food_price"].ToString();
                                                itemsubtotal += Convert.ToInt32(r["food_price"]);
                                            }
                                        }

                                        if (OrderList.Controls.Count > 0)
                                        {
                                            int cnt = 0;
                                            foreach (Control c2 in OrderList.Controls)
                                            {
                                                if (c2 is OrderItem)
                                                {
                                                    if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                    {
                                                        //cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                        cnt++;
                                                        int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                        int up = Convert.ToInt32(unitprice) * Convert.ToInt32(qty[j]);
                                                        itemqty += Convert.ToInt32(qty[j]);
                                                        int sub2 = itemqty * itemsubtotal;
                                                        ((OrderItem)c2).Qty = itemqty.ToString();
                                                        ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                        total += up;
                                                        item_total.Text = "P" + total.ToString() + ".00";
                                                    }
                                                }
                                            }
                                            if (cnt == 0)
                                            {
                                                int itemqty = 0;
                                                itemqty += Convert.ToInt32(qty[j]);
                                                OrderItem orderitems = new OrderItem();
                                                orderitems.Qty = itemqty.ToString();
                                                orderitems.Oname = itemname;
                                                orderitems.Unitprice = "P" + unitprice + ".00";
                                                itemsubtotal *= itemqty;
                                                orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                total += itemsubtotal;
                                                item_total.Text = "P" + total.ToString() + ".00";

                                                orderitems.WasClicked += OrderItem_WasClicked;
                                                OrderList.Controls.Add(orderitems);
                                            }
                                        }
                                        else
                                        {
                                            int itemqty = 0;
                                            itemqty += Convert.ToInt32(qty[j]);
                                            OrderItem orderitems = new OrderItem();
                                            orderitems.Qty = itemqty.ToString();
                                            orderitems.Oname = itemname;
                                            orderitems.Unitprice = "P" + unitprice + ".00";
                                            itemsubtotal *= itemqty;
                                            orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                            item_total.Visible = true;
                                            total = itemsubtotal;
                                            item_total.Text = "P" + total.ToString() + ".00";

                                            orderitems.WasClicked += OrderItem_WasClicked;
                                            OrderList.Controls.Add(orderitems);
                                        }

                                        closeConnection();
                                        btn_confirm.Enabled = true;
                                        btn_discounts.Enabled = true;
                                        btn_cancel.Enabled = true;
                                    }
                                    else if (check2 != 0)
                                    {
                                        SQLiteDataReader r = Cmd.ExecuteReader();
                                        string itemname = ns[i];
                                        string unitprice = "";
                                        int itemsubtotal = 0;
                                        if (r.HasRows)
                                        {
                                            while (r.Read())
                                            {
                                                unitprice = r["up_price"].ToString();
                                                itemsubtotal += Convert.ToInt32(r["up_price"]);
                                            }
                                        }

                                        if (OrderList.Controls.Count > 0)
                                        {
                                            int cnt = 0;
                                            foreach (Control c2 in OrderList.Controls)
                                            {
                                                if (c2 is OrderItem)
                                                {
                                                    if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                    {
                                                        //cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                        cnt++;
                                                        int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                        int up = Convert.ToInt32(unitprice) * Convert.ToInt32(qty[j]);
                                                        itemqty += Convert.ToInt32(qty[j]);
                                                        int sub2 = itemqty * itemsubtotal;
                                                        ((OrderItem)c2).Qty = itemqty.ToString();
                                                        ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                        total += up;
                                                        item_total.Text = "P" + total.ToString() + ".00";
                                                    }
                                                }
                                            }
                                            if (cnt == 0)
                                            {
                                                int itemqty = 0;
                                                itemqty += Convert.ToInt32(qty[j]);
                                                OrderItem orderitems = new OrderItem();
                                                orderitems.Qty = itemqty.ToString();
                                                orderitems.Oname = itemname;
                                                orderitems.Unitprice = "P" + unitprice + ".00";
                                                itemsubtotal *= itemqty;
                                                orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                total += itemsubtotal;
                                                item_total.Text = "P" + total.ToString() + ".00";

                                                orderitems.WasClicked += OrderItem_WasClicked;
                                                OrderList.Controls.Add(orderitems);
                                            }
                                        }
                                        else
                                        {
                                            int itemqty = 0;
                                            itemqty += Convert.ToInt32(qty[j]);
                                            OrderItem orderitems = new OrderItem();
                                            orderitems.Qty = itemqty.ToString();
                                            orderitems.Oname = itemname;
                                            orderitems.Unitprice = "P" + unitprice + ".00";
                                            itemsubtotal *= itemqty;
                                            orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                            item_total.Visible = true;
                                            total = itemsubtotal;
                                            item_total.Text = "P" + total.ToString() + ".00";

                                            orderitems.WasClicked += OrderItem_WasClicked;
                                            OrderList.Controls.Add(orderitems);
                                        }

                                        closeConnection();
                                        btn_confirm.Enabled = true;
                                        btn_discounts.Enabled = true;
                                        btn_cancel.Enabled = true;
                                    }
                                    closeConnection();
                                    j++;
                                }
                            }
                        }
                    }
                }
            }
        }
        //END OF ORDER LIST

        //SQL CONNECTION
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

        //ORDERLIST BUTTONS
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            OrderList.Controls.Clear();
            foodlayout.Controls.Clear();
            total = 0;
            item_total.Visible = false;
            btn_confirm.Enabled = false;
            btn_discounts.Enabled = false;
            btn_cancel.Enabled = false;
            btn_remove.Enabled = false;
            btn_editqty.Enabled = false;
            btn_split.Enabled = false;
            btn_upgrade.Enabled = false;
        }

        void OrderItem_WasClicked(object sender, EventArgs e)
        {
            btn_remove.Enabled = true;
            btn_editqty.Enabled = true;
            btn_split.Enabled = true;
            btn_upgrade.Enabled = true;
            // Set IsSelected for all UCs in the FlowLayoutPanel to false. 
            foreach (Control c in OrderList.Controls)
            {
                if (c is OrderItem)
                {
                    ((OrderItem)c).IsSelected = false;
                }
            }
            selected = sender;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            foreach (Control item in OrderList.Controls.OfType<Control>())
            {
                if (item == selected)
                {
                    OrderList.Controls.Remove(item);
                    item.Dispose();
                    int len = ((OrderItem)item).Subtotal.Length;
                    len -= 4;
                    string sub = ((OrderItem)item).Subtotal.Substring(1, len);
                    total -= Convert.ToInt32(sub);
                    item_total.Text = "P" + total.ToString() + ".00";
                }
            }
            if (OrderList.Controls.Count == 0)
            {
                total = 0;
                item_total.Visible = false;
                btn_confirm.Enabled = false;
                btn_discounts.Enabled = false;
                btn_cancel.Enabled = false;
                btn_remove.Enabled = false;
                btn_editqty.Enabled = false;
                btn_split.Enabled = false;
                btn_upgrade.Enabled = false;
            }
        }

        Qty_Dialog qty_dialog = new Qty_Dialog();
        Login frm;
        private void btn_editqty_Click(object sender, EventArgs e)
        {
            foreach (Control c in OrderList.Controls.OfType<Control>())
            {
                if (c is OrderItem)
                {
                    if (c == selected)
                    {
                        using (Qty_Dialog q = new Qty_Dialog())
                        {
                            q.inp = ((OrderItem)c).Qty;
                            q.Owner = frm;
                            q.StartPosition = FormStartPosition.CenterParent;
                            if (q.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                if (Convert.ToInt32(q.inp) > Convert.ToInt32(((OrderItem)c).Qty))
                                {
                                    int nqty = Convert.ToInt32(q.inp);
                                    int len = ((OrderItem)c).Unitprice.Length;
                                    len -= 4;
                                    int sub = Convert.ToInt32(((OrderItem)c).Unitprice.Substring(1, len));
                                    int len2 = ((OrderItem)c).Subtotal.Length;
                                    len2 -= 4;
                                    int ssub = Convert.ToInt32(((OrderItem)c).Subtotal.Substring(1, len2));
                                    total -= ssub;
                                    int nsub = nqty * sub;
                                    ((OrderItem)c).Subtotal = "P" + nsub.ToString() + ".00";
                                    total += nsub;
                                    item_total.Text = "P" + total.ToString() + ".00";
                                }
                                else if (Convert.ToInt32(q.inp) < Convert.ToInt32(((OrderItem)c).Qty))
                                {
                                    int nqty = Convert.ToInt32(q.inp);
                                    int cqty = Convert.ToInt32(((OrderItem)c).Qty);
                                    int diff = cqty - nqty;
                                    int len = ((OrderItem)c).Unitprice.Length;
                                    len -= 4;
                                    int sub = Convert.ToInt32(((OrderItem)c).Unitprice.Substring(1, len));
                                    int res = sub * diff;
                                    int len2 = ((OrderItem)c).Subtotal.Length;
                                    len2 -= 4;
                                    int csub = Convert.ToInt32(((OrderItem)c).Subtotal.Substring(1, len2));
                                    int nsub = csub - res;
                                    total -= res;
                                    ((OrderItem)c).Subtotal = "P" + nsub.ToString() + ".00";
                                    item_total.Text = "P" + total.ToString() + ".00";
                                }

                                ((OrderItem)c).Qty = q.inp;
                            }
                        }
                    }
                }
            }
        }

        public void fetchfood(string food_type, OrderItem c, Upgrade_Dialog u)
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            //SELECT FROM DATABASE
            string q = "SELECT * FROM tbl_menu WHERE food_name = '" + ((OrderItem)c).Oname + "'";
            SQLiteCommand Cmd = new SQLiteCommand(q, myConnection);
            string q2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_name = '" + ((OrderItem)c).Oname + "'";
            SQLiteCommand Cmd2 = new SQLiteCommand(q2, myConnection);

            openConnection();
            int l = Convert.ToInt32(Cmd2.ExecuteScalar());
            if(l != 0)
            {
                SQLiteDataReader res = Cmd.ExecuteReader();

                string s = "";
                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        s = res["sub"].ToString();
                    }
                }

                string qry = "SELECT * FROM tbl_menu WHERE food_type = '" + food_type + "' AND sub = '" + s + "' AND food_name <> '" + ((OrderItem)c).Oname + "'";
                string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_type = '" + food_type + "' AND sub = '" + s + "' AND food_name <> '" + ((OrderItem)c).Oname + "'";
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
                        img[i] = result2["food_image"].ToString();
                        foods[i] = result2["food_name"].ToString();
                        prices[i] = "P" + result2["food_price"].ToString() + ".00";
                        i++;
                    }
                }
                FoodItem2[] fooditems2 = new FoodItem2[len];
                for (i = 0; i < fooditems2.Length; i++)
                {
                    object o2 = Resources.ResourceManager.GetObject(img[i]);
                    fooditems2[i] = new FoodItem2();
                    fooditems2[i].Pic = (Image)o2;
                    fooditems2[i].Fname = foods[i];
                    fooditems2[i].Price = prices[i];

                    fooditems2[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    fooditems2[i].WasClicked += u.Fooditem2_WasClicked;
                    u.foodpanel.Controls.Add(fooditems2[i]);
                }

                //FROM TBL_UPGRADES
                qry = "SELECT * FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND up_sub = '" + ((OrderItem)c).Oname + "'";
                qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND up_sub = '" + ((OrderItem)c).Oname + "'";
                myCommand = new SQLiteCommand(qry, myConnection);
                myCommand2 = new SQLiteCommand(qry2, myConnection);

                len = Convert.ToInt32(myCommand2.ExecuteScalar());
                result2 = myCommand.ExecuteReader();
                foods = new string[len];
                img = new string[len];
                prices = new string[len];
                i = 0;
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

                fooditems2 = new FoodItem2[len];
                for (i = 0; i < fooditems2.Length; i++)
                {
                    object o2 = Resources.ResourceManager.GetObject(img[i]);
                    fooditems2[i] = new FoodItem2();
                    fooditems2[i].Pic = (Image)o2;
                    fooditems2[i].Fname = foods[i];
                    fooditems2[i].Price = prices[i];

                    fooditems2[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    fooditems2[i].WasClicked += u.Fooditem2_WasClicked;
                    u.foodpanel.Controls.Add(fooditems2[i]);
                }
            }
            else
            {
                q = "SELECT * FROM tbl_upgrades WHERE up_name = '" + ((OrderItem)c).Oname + "'";
                Cmd = new SQLiteCommand(q, myConnection);

                SQLiteDataReader res = Cmd.ExecuteReader();

                string s = "";
                string ns = "";
                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        s = res["up_sub"].ToString();
                        ns = res["main_sub"].ToString();
                    }
                }
                //MessageBox.Show(s);
                if(Regex.Matches(ns, "special").Count == 1)
                {
                    string qry = "SELECT * FROM tbl_upgrades WHERE up_sub = '" + s + "' AND up_name <> '" + ((OrderItem)c).Oname + "'";
                    string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_sub = '" + s + "'AND up_name <> '" + ((OrderItem)c).Oname + "'";
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
                    FoodItem2[] fooditems2 = new FoodItem2[len];
                    for (i = 0; i < fooditems2.Length; i++)
                    {
                        object o2 = Resources.ResourceManager.GetObject(img[i]);
                        fooditems2[i] = new FoodItem2();
                        fooditems2[i].Pic = (Image)o2;
                        fooditems2[i].Fname = foods[i];
                        fooditems2[i].Price = prices[i];

                        fooditems2[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        fooditems2[i].WasClicked += u.Fooditem2_WasClicked;
                        u.foodpanel.Controls.Add(fooditems2[i]);
                    }
                }
                else
                {
                    string qry = "SELECT * FROM tbl_menu WHERE food_name = '" + s + "'";
                    string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_name = '" + s + "'";
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
                            img[i] = result2["food_image"].ToString();
                            foods[i] = result2["food_name"].ToString();
                            prices[i] = "P" + result2["food_price"].ToString() + ".00";
                            i++;
                        }
                    }
                    FoodItem2[] fooditems2 = new FoodItem2[len];
                    for (i = 0; i < fooditems2.Length; i++)
                    {
                        object o2 = Resources.ResourceManager.GetObject(img[i]);
                        fooditems2[i] = new FoodItem2();
                        fooditems2[i].Pic = (Image)o2;
                        fooditems2[i].Fname = foods[i];
                        fooditems2[i].Price = prices[i];

                        fooditems2[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        fooditems2[i].WasClicked += u.Fooditem2_WasClicked;
                        u.foodpanel.Controls.Add(fooditems2[i]);
                    }

                    //FROM TBL_UPGRADES
                    q = "SELECT * FROM tbl_upgrades WHERE up_name = '" + ((OrderItem)c).Oname + "'";
                    Cmd = new SQLiteCommand(q, myConnection);
                    res = Cmd.ExecuteReader();
                    string ms = "";
                    if (res.HasRows)
                    {
                        while (res.Read())
                        {
                            ms = res["main_sub"].ToString();
                        }
                    }

                    qry = "SELECT * FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND main_sub = '" + ms + "' AND up_name <> '" + ((OrderItem)c).Oname + "'";
                    qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND main_sub = '" + ms + "' AND up_name <> '" + ((OrderItem)c).Oname + "'";
                    myCommand = new SQLiteCommand(qry, myConnection);
                    myCommand2 = new SQLiteCommand(qry2, myConnection);

                    len = Convert.ToInt32(myCommand2.ExecuteScalar());
                    result2 = myCommand.ExecuteReader();
                    foods = new string[len];
                    img = new string[len];
                    prices = new string[len];
                    i = 0;
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
                    fooditems2 = new FoodItem2[len];
                    for (i = 0; i < fooditems2.Length; i++)
                    {
                        object o2 = Resources.ResourceManager.GetObject(img[i]);
                        fooditems2[i] = new FoodItem2();
                        fooditems2[i].Pic = (Image)o2;
                        fooditems2[i].Fname = foods[i];
                        fooditems2[i].Price = prices[i];

                        fooditems2[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        fooditems2[i].WasClicked += u.Fooditem2_WasClicked;
                        u.foodpanel.Controls.Add(fooditems2[i]);
                    }
                }
            }
            closeConnection();
        }

        private void btn_upgrade_Click(object sender, EventArgs e)
        {
            foreach (Control c in OrderList.Controls.OfType<Control>())
            {
                if (c is OrderItem)
                {
                    if (c == selected)
                    {
                        using (Upgrade_Dialog u = new Upgrade_Dialog())
                        {
                            u.inp = 1.ToString();
                            u.Owner = frm;
                            u.StartPosition = FormStartPosition.CenterParent;

                            string on = ((OrderItem)c).Oname;
                            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                            //SELECT FROM DATABASE
                            string query = "SELECT * FROM tbl_menu WHERE food_name = '" + on + "'";
                            string query2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_name = '" + on + "'";
                            SQLiteCommand myCmd = new SQLiteCommand(query, myConnection);
                            SQLiteCommand myCmd2 = new SQLiteCommand(query2, myConnection);

                            openConnection();
                            int l = Convert.ToInt32(myCmd2.ExecuteScalar());
                            if(l != 0)
                            {
                                SQLiteDataReader result = myCmd.ExecuteReader();
                                string f = "";
                                string ims = "";
                                string ps = "";
                                if (result.HasRows)
                                {
                                    while (result.Read())
                                    {
                                        ims = result["food_image"].ToString();
                                        f = result["food_name"].ToString();
                                        ps = "P" + result["food_price"].ToString() + ".00";
                                    }
                                }
                                closeConnection();

                                FoodItemEx fooditemex = new FoodItemEx();
                                object o = Resources.ResourceManager.GetObject(ims);
                                fooditemex = new FoodItemEx();
                                fooditemex.Pic = (Image)o;
                                fooditemex.Fname = f;
                                fooditemex.Price = ps;

                                u.currentfood.Controls.Add(fooditemex);

                                if (Regex.Matches(((OrderItem)c).Oname, "Pita").Count == 1 || Regex.Matches(((OrderItem)c).Oname, "Wrap").Count == 1)
                                {
                                    fetchfood("Pita", (OrderItem)c, u);
                                }
                                else if (Regex.Matches(((OrderItem)c).Oname, "Rice").Count == 1)
                                {
                                    fetchfood("Rice", (OrderItem)c, u);
                                }
                                else if (Regex.Matches(((OrderItem)c).Oname, "Platter").Count == 1)
                                {
                                    fetchfood("Platter", (OrderItem)c, u);
                                }
                                else if (Regex.Matches(((OrderItem)c).Oname, "Steak").Count == 1)
                                {
                                    fetchfood("Steak", (OrderItem)c, u);
                                }

                                //OPEN DIALOG
                                if (u.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    string n = u.uname;
                                    if (n != null)
                                    {
                                        //REMOVE TO REPLACE
                                        OrderList.Controls.Remove(c);
                                        c.Dispose();
                                        int len = ((OrderItem)c).Subtotal.Length;
                                        len -= 4;
                                        string subt = ((OrderItem)c).Subtotal.Substring(1, len);
                                        total -= Convert.ToInt32(subt);

                                        //REPLACE
                                        myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                                        string qry = "SELECT * FROM tbl_menu WHERE food_name = '" + n + "'";
                                        string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_name = '" + n + "'";
                                        SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
                                        myCmd2 = new SQLiteCommand(qry2, myConnection);

                                        openConnection();
                                        SQLiteDataReader r = myCommand.ExecuteReader();
                                        int chk = Convert.ToInt32(myCmd2.ExecuteScalar());
                                        if (chk != 0)
                                        {
                                            string itemname = "";
                                            string unitprice = "";
                                            int itemsubtotal = 0;
                                            if (r.HasRows)
                                            {
                                                while (r.Read())
                                                {
                                                    itemname = r["food_name"].ToString();
                                                    unitprice = r["food_price"].ToString();
                                                    itemsubtotal += Convert.ToInt32(r["food_price"]);
                                                }
                                            }

                                            if (OrderList.Controls.Count > 0)
                                            {
                                                int cnt = 0;
                                                foreach (Control c2 in OrderList.Controls)
                                                {
                                                    if (c2 is OrderItem)
                                                    {
                                                        if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                        {
                                                            cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                            int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                            int up = Convert.ToInt32(unitprice) * Convert.ToInt32(u.inp);
                                                            itemqty += Convert.ToInt32(u.inp);
                                                            int sub2 = itemqty * itemsubtotal;
                                                            ((OrderItem)c2).Qty = itemqty.ToString();
                                                            ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                            total += up;
                                                            item_total.Text = "P" + total.ToString() + ".00";
                                                        }
                                                    }
                                                }
                                                if (cnt == 0)
                                                {
                                                    int itemqty = 0;
                                                    itemqty += Convert.ToInt32(u.inp);
                                                    OrderItem orderitems = new OrderItem();
                                                    orderitems.Qty = itemqty.ToString();
                                                    orderitems.Oname = itemname;
                                                    orderitems.Unitprice = "P" + unitprice + ".00";
                                                    itemsubtotal *= itemqty;
                                                    orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                    total += itemsubtotal;
                                                    item_total.Text = "P" + total.ToString() + ".00";

                                                    orderitems.WasClicked += OrderItem_WasClicked;
                                                    OrderList.Controls.Add(orderitems);
                                                }
                                            }
                                            else
                                            {
                                                int itemqty = 0;
                                                itemqty += Convert.ToInt32(u.inp);
                                                OrderItem orderitems = new OrderItem();
                                                orderitems.Qty = itemqty.ToString();
                                                orderitems.Oname = itemname;
                                                orderitems.Unitprice = "P" + unitprice + ".00";
                                                itemsubtotal *= itemqty;
                                                orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                item_total.Visible = true;
                                                total = itemsubtotal;
                                                item_total.Text = "P" + total.ToString() + ".00";

                                                orderitems.WasClicked += OrderItem_WasClicked;
                                                OrderList.Controls.Add(orderitems);
                                            }

                                            closeConnection();
                                        }
                                        else
                                        {
                                            //SELECT FROM DATABASE
                                            query = "SELECT * FROM tbl_upgrades WHERE up_name = '" + n + "'";
                                            myCmd = new SQLiteCommand(query, myConnection);

                                            openConnection();
                                            r = myCmd.ExecuteReader();
                                            string itemname = "";
                                            string unitprice = "";
                                            int itemsubtotal = 0;
                                            if (r.HasRows)
                                            {
                                                while (r.Read())
                                                {
                                                    itemname = r["up_name"].ToString();
                                                    unitprice = r["up_price"].ToString();
                                                    itemsubtotal += Convert.ToInt32(r["up_price"]);
                                                }
                                            }

                                            if (OrderList.Controls.Count > 0)
                                            {
                                                int cnt = 0;
                                                foreach (Control c2 in OrderList.Controls)
                                                {
                                                    if (c2 is OrderItem)
                                                    {
                                                        if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                        {
                                                            cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                            int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                            int up = Convert.ToInt32(unitprice) * Convert.ToInt32(u.inp);
                                                            itemqty += Convert.ToInt32(u.inp);
                                                            int sub2 = itemqty * itemsubtotal;
                                                            ((OrderItem)c2).Qty = itemqty.ToString();
                                                            ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                            total += up;
                                                            item_total.Text = "P" + total.ToString() + ".00";
                                                        }
                                                    }
                                                }
                                                if (cnt == 0)
                                                {
                                                    int itemqty = 0;
                                                    itemqty += Convert.ToInt32(u.inp);
                                                    OrderItem orderitems = new OrderItem();
                                                    orderitems.Qty = itemqty.ToString();
                                                    orderitems.Oname = itemname;
                                                    orderitems.Unitprice = "P" + unitprice + ".00";
                                                    itemsubtotal *= itemqty;
                                                    orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                    total += itemsubtotal;
                                                    item_total.Text = "P" + total.ToString() + ".00";

                                                    orderitems.WasClicked += OrderItem_WasClicked;
                                                    OrderList.Controls.Add(orderitems);
                                                }
                                            }
                                            else
                                            {
                                                int itemqty = 0;
                                                itemqty += Convert.ToInt32(u.inp);
                                                OrderItem orderitems = new OrderItem();
                                                orderitems.Qty = itemqty.ToString();
                                                orderitems.Oname = itemname;
                                                orderitems.Unitprice = "P" + unitprice + ".00";
                                                itemsubtotal *= itemqty;
                                                orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                item_total.Visible = true;
                                                total = itemsubtotal;
                                                item_total.Text = "P" + total.ToString() + ".00";

                                                orderitems.WasClicked += OrderItem_WasClicked;
                                                OrderList.Controls.Add(orderitems);
                                            }
                                            closeConnection();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                query = "SELECT * FROM tbl_upgrades WHERE up_name = '" + on + "'";
                                myCmd = new SQLiteCommand(query, myConnection);

                                openConnection();
                                SQLiteDataReader result = myCmd.ExecuteReader();
                                string f = "";
                                string ims = "";
                                string ps = "";
                                if (result.HasRows)
                                {
                                    while (result.Read())
                                    {
                                        ims = result["up_image"].ToString();
                                        f = result["up_name"].ToString();
                                        ps = "P" + result["up_price"].ToString() + ".00";
                                    }
                                }
                                closeConnection();

                                FoodItemEx fooditemex = new FoodItemEx();
                                object o = Resources.ResourceManager.GetObject(ims);
                                fooditemex = new FoodItemEx();
                                fooditemex.Pic = (Image)o;
                                fooditemex.Fname = f;
                                fooditemex.Price = ps;

                                u.currentfood.Controls.Add(fooditemex);

                                if (Regex.Matches(((OrderItem)c).Oname, "Pita").Count == 1)
                                {
                                    fetchfood("Pita", (OrderItem)c, u);
                                }
                                else if (Regex.Matches(((OrderItem)c).Oname, "Rice").Count == 1)
                                {
                                    fetchfood("Rice", (OrderItem)c, u);
                                }
                                else if (Regex.Matches(((OrderItem)c).Oname, "Platter").Count == 1)
                                {
                                    fetchfood("Platter", (OrderItem)c, u);
                                }
                                else if (Regex.Matches(((OrderItem)c).Oname, "Steak").Count == 1)
                                {
                                    fetchfood("Steak", (OrderItem)c, u);
                                }

                                //OPEN DIALOG
                                if (u.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    string n = u.uname;
                                    if (n != null)
                                    {
                                        //REMOVE TO REPLACE
                                        OrderList.Controls.Remove(c);
                                        c.Dispose();
                                        int len = ((OrderItem)c).Subtotal.Length;
                                        len -= 4;
                                        string subt = ((OrderItem)c).Subtotal.Substring(1, len);
                                        total -= Convert.ToInt32(subt);

                                        //REPLACE
                                        myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                                        string qry = "SELECT * FROM tbl_menu WHERE food_name = '" + n + "'";
                                        string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_name = '" + n + "'";
                                        SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
                                        myCmd2 = new SQLiteCommand(qry2, myConnection);

                                        openConnection();
                                        SQLiteDataReader r = myCommand.ExecuteReader();
                                        int chk = Convert.ToInt32(myCmd2.ExecuteScalar());
                                        if (chk != 0)
                                        {
                                            string itemname = "";
                                            string unitprice = "";
                                            int itemsubtotal = 0;
                                            if (r.HasRows)
                                            {
                                                while (r.Read())
                                                {
                                                    itemname = r["food_name"].ToString();
                                                    unitprice = r["food_price"].ToString();
                                                    itemsubtotal += Convert.ToInt32(r["food_price"]);
                                                }
                                            }

                                            if (OrderList.Controls.Count > 0)
                                            {
                                                int cnt = 0;
                                                foreach (Control c2 in OrderList.Controls)
                                                {
                                                    if (c2 is OrderItem)
                                                    {
                                                        if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                        {
                                                            cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                            int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                            int up = Convert.ToInt32(unitprice) * Convert.ToInt32(u.inp);
                                                            itemqty += Convert.ToInt32(u.inp);
                                                            int sub2 = itemqty * itemsubtotal;
                                                            ((OrderItem)c2).Qty = itemqty.ToString();
                                                            ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                            total += up;
                                                            item_total.Text = "P" + total.ToString() + ".00";
                                                        }
                                                    }
                                                }
                                                if (cnt == 0)
                                                {
                                                    int itemqty = 0;
                                                    itemqty += Convert.ToInt32(u.inp);
                                                    OrderItem orderitems = new OrderItem();
                                                    orderitems.Qty = itemqty.ToString();
                                                    orderitems.Oname = itemname;
                                                    orderitems.Unitprice = "P" + unitprice + ".00";
                                                    itemsubtotal *= itemqty;
                                                    orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                    total += itemsubtotal;
                                                    item_total.Text = "P" + total.ToString() + ".00";

                                                    orderitems.WasClicked += OrderItem_WasClicked;
                                                    OrderList.Controls.Add(orderitems);
                                                }
                                            }
                                            else
                                            {
                                                int itemqty = 0;
                                                itemqty += Convert.ToInt32(u.inp);
                                                OrderItem orderitems = new OrderItem();
                                                orderitems.Qty = itemqty.ToString();
                                                orderitems.Oname = itemname;
                                                orderitems.Unitprice = "P" + unitprice + ".00";
                                                itemsubtotal *= itemqty;
                                                orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                item_total.Visible = true;
                                                total = itemsubtotal;
                                                item_total.Text = "P" + total.ToString() + ".00";

                                                orderitems.WasClicked += OrderItem_WasClicked;
                                                OrderList.Controls.Add(orderitems);
                                            }

                                            closeConnection();
                                        }
                                        else
                                        {
                                            //SELECT FROM DATABASE
                                            query = "SELECT * FROM tbl_upgrades WHERE up_name = '" + n + "'";
                                            myCmd = new SQLiteCommand(query, myConnection);

                                            openConnection();
                                            r = myCmd.ExecuteReader();
                                            string itemname = "";
                                            string unitprice = "";
                                            int itemsubtotal = 0;
                                            if (r.HasRows)
                                            {
                                                while (r.Read())
                                                {
                                                    itemname = r["up_name"].ToString();
                                                    unitprice = r["up_price"].ToString();
                                                    itemsubtotal += Convert.ToInt32(r["up_price"]);
                                                }
                                            }

                                            if (OrderList.Controls.Count > 0)
                                            {
                                                int cnt = 0;
                                                foreach (Control c2 in OrderList.Controls)
                                                {
                                                    if (c2 is OrderItem)
                                                    {
                                                        if (String.Compare(((OrderItem)c2).Oname, itemname) == 0)
                                                        {
                                                            cnt = Regex.Matches(((OrderItem)c2).Oname, itemname).Count;
                                                            int itemqty = Convert.ToInt32(((OrderItem)c2).Qty);
                                                            int up = Convert.ToInt32(unitprice) * Convert.ToInt32(u.inp);
                                                            itemqty += Convert.ToInt32(u.inp);
                                                            int sub2 = itemqty * itemsubtotal;
                                                            ((OrderItem)c2).Qty = itemqty.ToString();
                                                            ((OrderItem)c2).Subtotal = "P" + sub2.ToString() + ".00";
                                                            total += up;
                                                            item_total.Text = "P" + total.ToString() + ".00";
                                                        }
                                                    }
                                                }
                                                if (cnt == 0)
                                                {
                                                    int itemqty = 0;
                                                    itemqty += Convert.ToInt32(u.inp);
                                                    OrderItem orderitems = new OrderItem();
                                                    orderitems.Qty = itemqty.ToString();
                                                    orderitems.Oname = itemname;
                                                    orderitems.Unitprice = "P" + unitprice + ".00";
                                                    itemsubtotal *= itemqty;
                                                    orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                    total += itemsubtotal;
                                                    item_total.Text = "P" + total.ToString() + ".00";

                                                    orderitems.WasClicked += OrderItem_WasClicked;
                                                    OrderList.Controls.Add(orderitems);
                                                }
                                            }
                                            else
                                            {
                                                int itemqty = 0;
                                                itemqty += Convert.ToInt32(u.inp);
                                                OrderItem orderitems = new OrderItem();
                                                orderitems.Qty = itemqty.ToString();
                                                orderitems.Oname = itemname;
                                                orderitems.Unitprice = "P" + unitprice + ".00";
                                                itemsubtotal *= itemqty;
                                                orderitems.Subtotal = "P" + itemsubtotal.ToString() + ".00";
                                                item_total.Visible = true;
                                                total = itemsubtotal;
                                                item_total.Text = "P" + total.ToString() + ".00";

                                                orderitems.WasClicked += OrderItem_WasClicked;
                                                OrderList.Controls.Add(orderitems);
                                            }
                                            closeConnection();
                                        }
                                    }
                                }
                                closeConnection();
                            }
                        }
                    }
                }
            }
        }

        CheckBox[] box = new CheckBox[20];
        CheckBox[] box2 = new CheckBox[20];
        CheckBox[] box3 = new CheckBox[20];
        public void fetchings(string food_type, FoodItem c, Preupgrade_Dialog p)
        {
            p.Fname = ((FoodItem)c).Fname;

            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            //SELECT FROM DATABASE
            string q = "SELECT * FROM tbl_menu WHERE food_name = '" + ((FoodItem)c).Fname + "'";
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

            string qry = "SELECT * FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND up_sub = '" + ((FoodItem)c).Fname + "'";
            string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_type = '" + food_type + "' AND up_sub = '" + ((FoodItem)c).Fname + "'";
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
            FoodItem2[] fooditems2 = new FoodItem2[len];
            for (i = 0; i < fooditems2.Length; i++)
            {
                object o2 = Resources.ResourceManager.GetObject(img[i]);
                fooditems2[i] = new FoodItem2();
                fooditems2[i].Pic = (Image)o2;
                fooditems2[i].Fname = foods[i];
                fooditems2[i].Price = prices[i];

                fooditems2[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                fooditems2[i].WasClicked += p.Fooditem2_WasClicked;
                p.foodpanel.Controls.Add(fooditems2[i]);
            }

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
                box[i] = new CheckBox();
                box[i].Tag = i.ToString();
                box[i].Checked = true;
                box[i].Text = meat[i];
                box[i].AutoSize = false;
                box[i].Width = 220;
                box[i].Height = 27;
                box[i].Font = new Font(box[i].Font.FontFamily, 13);
                box[i].CheckedChanged += new EventHandler(box_CheckedChanged);
                p.meatlayout.Controls.Add(box[i]);
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
                box2[i] = new CheckBox();
                box2[i].Tag = i.ToString();
                box2[i].Checked = true;
                box2[i].Text = veggie[i];
                box2[i].AutoSize = false;
                box2[i].Width = 220;
                box2[i].Height = 27;
                box2[i].Font = new Font(box2[i].Font.FontFamily, 13);
                box2[i].CheckedChanged += new EventHandler(box2_CheckedChanged);
                p.veggielayout.Controls.Add(box2[i]);
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
                box3[i] = new CheckBox();
                box3[i].Tag = i.ToString();
                box3[i].Checked = true;
                box3[i].Text = sauce[i];
                box3[i].AutoSize = false;
                box3[i].Width = 220;
                box3[i].Height = 27;
                box3[i].Font = new Font(box3[i].Font.FontFamily, 13);
                box3[i].CheckedChanged += new EventHandler(box3_CheckedChanged);
                p.saucelayout.Controls.Add(box3[i]);
            }

            closeConnection();
        }
        
        public void getext(string[] extmeat, string[] extveggie, string[] extsauce, string plat)
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
                else if (extmeat[i] == "Hotdog")
                    em = em + "(no hotdog) ";
                else if (extmeat[i] == "Beef Steak")
                    em = em + "(no steak) ";
                else if (extmeat[i] == "Chicken Steak")
                    em = em + "(no steak) ";
            }
            if(plat == "Platter")
            {
                if (em == "(no kebab) (no beef) " || em == "(no beef) (no chicken) " || em == "(no kebab) (no chicken) ")
                {
                    em = "(vegetarian) ";
                }
            }
            else
            {
                if(em == "(no beef) " || em == "(no chicken) " || em == "(no kebab) " || em == "(no steak) ")
                {
                    em = "(vegetarian) ";
                }
            }

            //string toDisplay2 = string.Join(Environment.NewLine, extveggie);
            //MessageBox.Show(toDisplay2.ToString());
            for(i = 0; i<extveggie.Length; i++)
            {
                if (extveggie[i]=="Mini Pita")
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
            oext = e;
        }
        
        private void box_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box.Length];
            Array.Copy(box, b, box.Length);
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
            ingmeat = toDisplay;
            xingmeat = toDisplay2;
            //MessageBox.Show(toDisplay);
        }
        
        private void box2_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box2.Length];
            Array.Copy(box2, b, box2.Length);
            b = b.Where(c => c != null).ToArray();
            for (int i = 0; i<b.Length; i++)
            {
                if(b[i].Checked == true)
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
            ingveggie = toDisplay;
            xingveggie = toDisplay2;
            //MessageBox.Show(toDisplay);
        }
        
        private void box3_CheckedChanged(object sender, EventArgs e)
        {
            string[] s = new string[50];
            string[] s2 = new string[50];
            CheckBox[] b = new CheckBox[box3.Length];
            Array.Copy(box3, b, box3.Length);
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
            ingsauce = toDisplay;
            xingsauce = toDisplay2;
            //MessageBox.Show(toDisplay);
        }

        void Fooditem_WasClicked(object sender, EventArgs e)
        {
            // Set IsSelected for all UCs in the FlowLayoutPanel to false.
            foreach (Control c in foodlayout.Controls)
            {
                if (c is FoodItem)
                {
                    ((FoodItem)c).IsSelected = false;
                }
            }
            selected2 = sender;
        }
        
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            using (Confirm_Dialog con = new Confirm_Dialog())
            {
                con.Owner = frm;
                con.StartPosition = FormStartPosition.CenterParent;
                con.tot = item_total.Text;
                if (con.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if(con.cust_cash.Text != "" && Convert.ToInt32(con.cust_cash.Text) >= total)
                    {
                        //CHANGE
                        int cash = Convert.ToInt32(con.cust_cash.Text);
                        int change = cash - total;
                        Change_Dialog ch = new Change_Dialog();
                        ch.lbl_change.Text = "P" + change.ToString() + ".00";
                        ch.Owner = frm;
                        ch.StartPosition = FormStartPosition.CenterParent;
                        ch.ShowDialog();

                        //ORDERLIST RECORD
                        int len = OrderList.Controls.Count;
                        string[] name = new string[999];
                        string[] qty = new string[len];
                        string[] subtotal = new string[len];
                        int i = 0;
                        foreach (Control c in OrderList.Controls)
                        {
                            if (c is OrderItem)
                            {
                                if(Convert.ToInt32(((OrderItem)c).Qty) >1)
                                {
                                    for (int q=0; q< Convert.ToInt32(((OrderItem)c).Qty); q++)
                                    {
                                        name[i] = ((OrderItem)c).Oname;
                                        i++;
                                    }
                                }
                                else
                                {
                                    name[i] = ((OrderItem)c).Oname;
                                    i++;
                                    //qty[i] = ((OrderItem)c).Qty;
                                    //subtotal[i] = ((OrderItem)c).Subtotal;
                                }
                            }
                        }
                        name = name.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        //string toDisplay = string.Join(Environment.NewLine, name);
                        //MessageBox.Show(toDisplay);

                        //RECORD TIME AND TOTAL CASH
                        string time = DateTime.Now.ToString("h:mm tt");
                        DateTime now = DateTime.Today;
                        string d = now.ToString("dd/MM/yyyy");

                        string qry_time = "INSERT INTO tbl_timetrans ('time', 'date') " +
                                    "VALUES (@time, @date)";
                        SQLiteCommand cmd_time = new SQLiteCommand(qry_time, myConnection);
                        openConnection();
                        cmd_time.Parameters.AddWithValue("@time", time);
                        cmd_time.Parameters.AddWithValue("@date", d);
                        var res_time = cmd_time.ExecuteNonQuery();

                        //UPDATE INVENTORY
                        foreach (string n in name)
                        {
                            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
                            string qry = "SELECT * FROM tbl_menu WHERE food_name = '" + n + "'";
                            string qry2 = "SELECT COUNT(*) FROM tbl_menu WHERE food_name = '" + n + "'";
                            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
                            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);
                            
                            openConnection();
                            SQLiteCommand sqlComm = new SQLiteCommand("begin", myConnection);
                            sqlComm.ExecuteNonQuery();
                            SQLiteDataReader result = myCommand.ExecuteReader();
                            int check = Convert.ToInt32(myCommand2.ExecuteScalar());
                            if(check != 0)
                            {
                                string ing = "";
                                string mat = "";
                                if (result.HasRows)
                                {
                                    while (result.Read())
                                    {
                                        ing = result["food_ingredients"].ToString();
                                        mat = result["food_materials"].ToString();
                                    }
                                }
                                string[] ings = ing.Split(',');
                                foreach (string s in ings)
                                {
                                    string qry3 = "UPDATE tbl_ingredients SET in_stock = in_stock -1 WHERE in_name = '" + s + "'";
                                    SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                                    myCommand3.ExecuteNonQuery();
                                }
                                string[] mats = mat.Split(',');
                                foreach (string s in mats)
                                {
                                    string qry3 = "UPDATE tbl_materials SET mat_stock = mat_stock -1 WHERE mat_name = '" + s + "'";
                                    SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                                    myCommand3.ExecuteNonQuery();
                                }

                                //RECORD TRANSACTION
                                DateTime today = DateTime.Today;
                                string date = today.ToString("dd/MM/yyyy");
                                string qry_date = "SELECT COUNT(*) FROM tbl_transactions WHERE date = '" + date + "'";
                                SQLiteCommand cmd_date = new SQLiteCommand(qry_date, myConnection);
                                int check_date = Convert.ToInt32(cmd_date.ExecuteScalar());

                                if (check_date == 0)
                                {
                                    string qry_trans = "INSERT INTO tbl_transactions ('date', 'reported', 'total_sales', 'bpd', 'cpd', 'kw', 'hw', 'bpdwd', 'cpdwd', 'kwwd', 'hwwd', 'bpdwfnd', 'cpdwfnd', 'kwwfnd', 'hwwfnd', 'bdor', 'cdor', 'kor', 'hr', 'bdorwd', 'cdorwd', 'korwd', 'hrwd', 'bds', 'cds', 'bdswd', 'cdswd', 'bcp', 'bkp', 'ckp', 'bcpwd', 'bkpwd', 'ckpwd', 'pitaout', 'kebabout', 'hotdogout', 'mealboxout', 'beefout', 'chickenout', 'bsteakout', 'csteakout', 'platterboxout', 'minipitaout', 'friesbagsout', 'minicupsout', 'conesout', 'cupsout', 'cheeseout', 'gsauceout', 'csauceout', 'hsauceout', 'lemonadeout', 'nesteaout', 'waterout', 'sodaout', 'turksfriesout', 'extrariceout') " +
                                    "VALUES (@date, @reported, @total_sales, @bpd, @cpd, @kw, @hw, @bpdwd, @cpdwd, @kwwd, @hwwd, @bpdwfnd, @cpdwfnd, @kwwfnd, @hwwfnd, @bdor, @cdor, @kor, @hr, @bdorwd, @cdorwd, @korwd, @hrwd, @bds, @cds, @bdswd, @cdswd, @bcp, @bkp, @ckp, @bcpwd, @bkpwd, @ckpwd, @pitaout, @kebabout, @hotdogout, @mealboxout, @beefout, @chickenout, @bsteakout, @csteakout, @platterboxout, @minipitaout, @friesbagsout, @minicupsout, @conesout, @cupsout, @cheeseout, @gsauceout, @csauceout, @hsauceout, @lemonadeout, @nesteaout, @waterout, @sodaout, @turksfriesout, @extrariceout)";
                                    SQLiteCommand cmd_trans = new SQLiteCommand(qry_trans, myConnection);
                                    //openConnection();
                                    cmd_trans.Parameters.AddWithValue("@date", date);
                                    cmd_trans.Parameters.AddWithValue("@reported", "");
                                    cmd_trans.Parameters.AddWithValue("@total_sales", "0");
                                    cmd_trans.Parameters.AddWithValue("@bpd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cpd", 0);
                                    cmd_trans.Parameters.AddWithValue("@kw", 0);
                                    cmd_trans.Parameters.AddWithValue("@hw", 0);
                                    cmd_trans.Parameters.AddWithValue("@bpdwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cpdwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@kwwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@hwwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bpdwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cpdwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@kwwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@hwwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bdor", 0);
                                    cmd_trans.Parameters.AddWithValue("@cdor", 0);
                                    cmd_trans.Parameters.AddWithValue("@kor", 0);
                                    cmd_trans.Parameters.AddWithValue("@hr", 0);
                                    cmd_trans.Parameters.AddWithValue("@bdorwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cdorwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@korwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@hrwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bds", 0);
                                    cmd_trans.Parameters.AddWithValue("@cds", 0);
                                    cmd_trans.Parameters.AddWithValue("@bdswd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cdswd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bcp", 0);
                                    cmd_trans.Parameters.AddWithValue("@bkp", 0);
                                    cmd_trans.Parameters.AddWithValue("@ckp", 0);
                                    cmd_trans.Parameters.AddWithValue("@bcpwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bkpwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@ckpwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@pitaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@kebabout", 0);
                                    cmd_trans.Parameters.AddWithValue("@hotdogout", 0);
                                    cmd_trans.Parameters.AddWithValue("@mealboxout", 0);
                                    cmd_trans.Parameters.AddWithValue("@beefout", 0);
                                    cmd_trans.Parameters.AddWithValue("@chickenout", 0);
                                    cmd_trans.Parameters.AddWithValue("@bsteakout", 0);
                                    cmd_trans.Parameters.AddWithValue("@csteakout", 0);
                                    cmd_trans.Parameters.AddWithValue("@platterboxout", 0);
                                    cmd_trans.Parameters.AddWithValue("@minipitaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@friesbagsout", 0);
                                    cmd_trans.Parameters.AddWithValue("@minicupsout", 0);
                                    cmd_trans.Parameters.AddWithValue("@conesout", 0);
                                    cmd_trans.Parameters.AddWithValue("@cupsout", 0);
                                    cmd_trans.Parameters.AddWithValue("@cheeseout", 0);
                                    cmd_trans.Parameters.AddWithValue("@gsauceout", 0);
                                    cmd_trans.Parameters.AddWithValue("@csauceout", 0);
                                    cmd_trans.Parameters.AddWithValue("@hsauceout", 0);
                                    cmd_trans.Parameters.AddWithValue("@lemonadeout", 0);
                                    cmd_trans.Parameters.AddWithValue("@nesteaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@waterout", 0);
                                    cmd_trans.Parameters.AddWithValue("@sodaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@turksfriesout", 0);
                                    cmd_trans.Parameters.AddWithValue("@extrariceout", 0);
                                    var res_trans = cmd_trans.ExecuteNonQuery();
                                    //closeConnection();

                                    string qry_pack = "UPDATE tbl_prepack SET prebeef = 0, prechicken = 0, prekebab = 0, prehotdog = 0";
                                    SQLiteCommand cmd_pack = new SQLiteCommand(qry_pack, myConnection);
                                    cmd_pack.ExecuteNonQuery();

                                    if (n == "Beef Pita Doner")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }

                                    else if (n == "Chicken Pita Doner w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Doner on Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bdor = bdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Doner on Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cdor = cdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab on Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kor = kor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hr = hr +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Doner on Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bdorwd = bdorwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Doner on Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cdorwd = cdorwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab on Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET korwd = korwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hrwd = hrwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Doner Steak")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bds = bds +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Chicken Doner Steak")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cds = cds +1, csteakout = csteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Beef Doner Steak w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bdswd = bdswd +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Chicken Doner Steak w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cdswd = cdswd +1, csteakout = csteakout +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Beef and Chicken Platter")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bcp = bcp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prechicken = prechicken +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Beef Platter")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bkp = bkp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Chicken Platter")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET ckp = ckp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef and Chicken Platter w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bcpwd = bcpwd +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prechicken = prechicken +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Beef Platter w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bkpwd = bkpwd +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Chicken Platter w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET ckpwd = ckpwd +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Nestea Iced Tea")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cupsout = cupsout +1, nesteaout = nesteaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Nestea Lemonade")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cupsout = cupsout +1, lemonadeout = lemonadeout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Coke")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET sodaout = sodaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Sprite")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET sodaout = sodaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Royal")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET sodaout = sodaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Turks Fries")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Cheese Sauce")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET csauceout = csauceout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Garlic Sauce Sauce")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET gsauceout = gsauceout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Hot Sauce")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hsauceout = hsauceout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Cheddar Cheese")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Water")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET waterout = waterout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    if (n == "Beef Pita Doner")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }

                                    else if (n == "Chicken Pita Doner w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Doner on Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bdor = bdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Doner on Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cdor = cdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab on Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kor = kor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Rice")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hr = hr +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Doner on Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bdorwd = bdorwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Doner on Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cdorwd = cdorwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1.25";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab on Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET korwd = korwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog on Rice w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hrwd = hrwd +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +2 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Doner Steak")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bds = bds +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Chicken Doner Steak")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cds = cds +1, csteakout = csteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Beef Doner Steak w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bdswd = bdswd +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Chicken Doner Steak w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cdswd = cdswd +1, csteakout = csteakout +1, mealboxout = mealboxout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Beef and Chicken Platter")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bcp = bcp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prechicken = prechicken +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Beef Platter")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bkp = bkp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Chicken Platter")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET ckp = ckp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef and Chicken Platter w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bcpwd = bcpwd +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prechicken = prechicken +2";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Beef Platter w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bkpwd = bkpwd +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab and Chicken Platter w/ Drink")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET ckpwd = ckpwd +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                        cmd_rec3.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +2, prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        double pb2 = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                                pb2 = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                        if (pb2 >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Nestea Iced Tea")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cupsout = cupsout +1, nesteaout = nesteaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Nestea Lemonade")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cupsout = cupsout +1, lemonadeout = lemonadeout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Coke")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET sodaout = sodaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Sprite")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET sodaout = sodaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Royal")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET sodaout = sodaout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Turks Fries")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Cheese Sauce")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET csauceout = csauceout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Garlic Sauce Sauce")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET gsauceout = gsauceout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Hot Sauce")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hsauceout = hsauceout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Cheddar Cheese")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                    else if (n == "Water")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET waterout = waterout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                string qry3 = "SELECT * FROM tbl_upgrades WHERE up_name = '" + n + "'";
                                SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);

                                openConnection();
                                SQLiteDataReader result2 = myCommand3.ExecuteReader();
                                string ing = "";
                                if (result2.HasRows)
                                {
                                    while (result2.Read())
                                    {
                                        ing = result2["up_ingredients"].ToString();
                                    }
                                }
                                string[] ings = ing.Split(',');
                                foreach (string s in ings)
                                {
                                    string qry4 = "UPDATE tbl_ingredients SET in_stock = in_stock -1 WHERE in_name = '" + s + "'";
                                    SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                                    myCommand4.ExecuteNonQuery();
                                }

                                //RECORD TRANSACTION
                                DateTime today = DateTime.Today;
                                string date = today.ToString("dd/MM/yyyy");
                                string qry_date = "SELECT COUNT(*) FROM tbl_transactions WHERE date = '" + date + "'";
                                SQLiteCommand cmd_date = new SQLiteCommand(qry_date, myConnection);
                                int check_date = Convert.ToInt32(cmd_date.ExecuteScalar());

                                if (check_date == 0)
                                {
                                    string qry_trans = "INSERT INTO tbl_transactions ('date', 'reported', 'total_sales', 'bpd', 'cpd', 'kw', 'hw', 'bpdwd', 'cpdwd', 'kwwd', 'hwwd', 'bpdwfnd', 'cpdwfnd', 'kwwfnd', 'hwwfnd', 'bdor', 'cdor', 'kor', 'hr', 'bdorwd', 'cdorwd', 'korwd', 'hrwd', 'bds', 'cds', 'bdswd', 'cdswd', 'bcp', 'bkp', 'ckp', 'bcpwd', 'bkpwd', 'ckpwd', 'pitaout', 'kebabout', 'hotdogout', 'mealboxout', 'beefout', 'chickenout', 'bsteakout', 'csteakout', 'platterboxout', 'minipitaout', 'friesbagsout', 'minicupsout', 'conesout', 'cupsout', 'cheeseout', 'gsauceout', 'csauceout', 'hsauceout', 'lemonadeout', 'nesteaout', 'waterout', 'sodaout', 'turksfriesout', 'extrariceout') " +
                                    "VALUES (@date, @reported, @total_sales, @bpd, @cpd, @kw, @hw, @bpdwd, @cpdwd, @kwwd, @hwwd, @bpdwfnd, @cpdwfnd, @kwwfnd, @hwwfnd, @bdor, @cdor, @kor, @hr, @bdorwd, @cdorwd, @korwd, @hrwd, @bds, @cds, @bdswd, @cdswd, @bcp, @bkp, @ckp, @bcpwd, @bkpwd, @ckpwd, @pitaout, @kebabout, @hotdogout, @mealboxout, @beefout, @chickenout, @bsteakout, @csteakout, @platterboxout, @minipitaout, @friesbagsout, @minicupsout, @conesout, @cupsout, @cheeseout, @gsauceout, @csauceout, @hsauceout, @lemonadeout, @nesteaout, @waterout, @sodaout, @turksfriesout, @extrariceout)";
                                    SQLiteCommand cmd_trans = new SQLiteCommand(qry_trans, myConnection);
                                    //openConnection();
                                    cmd_trans.Parameters.AddWithValue("@date", date);
                                    cmd_trans.Parameters.AddWithValue("@reported", "");
                                    cmd_trans.Parameters.AddWithValue("@total_sales", "0");
                                    cmd_trans.Parameters.AddWithValue("@bpd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cpd", 0);
                                    cmd_trans.Parameters.AddWithValue("@kw", 0);
                                    cmd_trans.Parameters.AddWithValue("@hw", 0);
                                    cmd_trans.Parameters.AddWithValue("@bpdwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cpdwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@kwwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@hwwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bpdwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cpdwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@kwwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@hwwfnd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bdor", 0);
                                    cmd_trans.Parameters.AddWithValue("@cdor", 0);
                                    cmd_trans.Parameters.AddWithValue("@kor", 0);
                                    cmd_trans.Parameters.AddWithValue("@hr", 0);
                                    cmd_trans.Parameters.AddWithValue("@bdorwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cdorwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@korwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@hrwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bds", 0);
                                    cmd_trans.Parameters.AddWithValue("@cds", 0);
                                    cmd_trans.Parameters.AddWithValue("@bdswd", 0);
                                    cmd_trans.Parameters.AddWithValue("@cdswd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bcp", 0);
                                    cmd_trans.Parameters.AddWithValue("@bkp", 0);
                                    cmd_trans.Parameters.AddWithValue("@ckp", 0);
                                    cmd_trans.Parameters.AddWithValue("@bcpwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@bkpwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@ckpwd", 0);
                                    cmd_trans.Parameters.AddWithValue("@pitaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@kebabout", 0);
                                    cmd_trans.Parameters.AddWithValue("@hotdogout", 0);
                                    cmd_trans.Parameters.AddWithValue("@mealboxout", 0);
                                    cmd_trans.Parameters.AddWithValue("@beefout", 0);
                                    cmd_trans.Parameters.AddWithValue("@chickenout", 0);
                                    cmd_trans.Parameters.AddWithValue("@bsteakout", 0);
                                    cmd_trans.Parameters.AddWithValue("@csteakout", 0);
                                    cmd_trans.Parameters.AddWithValue("@platterboxout", 0);
                                    cmd_trans.Parameters.AddWithValue("@minipitaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@friesbagsout", 0);
                                    cmd_trans.Parameters.AddWithValue("@minicupsout", 0);
                                    cmd_trans.Parameters.AddWithValue("@conesout", 0);
                                    cmd_trans.Parameters.AddWithValue("@cupsout", 0);
                                    cmd_trans.Parameters.AddWithValue("@cheeseout", 0);
                                    cmd_trans.Parameters.AddWithValue("@gsauceout", 0);
                                    cmd_trans.Parameters.AddWithValue("@csauceout", 0);
                                    cmd_trans.Parameters.AddWithValue("@hsauceout", 0);
                                    cmd_trans.Parameters.AddWithValue("@lemonadeout", 0);
                                    cmd_trans.Parameters.AddWithValue("@nesteaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@waterout", 0);
                                    cmd_trans.Parameters.AddWithValue("@sodaout", 0);
                                    cmd_trans.Parameters.AddWithValue("@turksfriesout", 0);
                                    cmd_trans.Parameters.AddWithValue("@extrariceout", 0);
                                    var res_trans = cmd_trans.ExecuteNonQuery();
                                    //closeConnection();

                                    string qry_pack = "UPDATE tbl_prepack SET prebeef = 0, prechicken = 0, prekebab = 0, prehotdog = 0";
                                    SQLiteCommand cmd_pack = new SQLiteCommand(qry_pack, myConnection);
                                    cmd_pack.ExecuteNonQuery();

                                    if (n == "Beef Pita Doner (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotodog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }

                                    else if (n == "Chicken Pita Doner w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    if (n == "Beef Pita Doner (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }

                                    else if (n == "Chicken Pita Doner w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n != "Beef Pita Doner (wc)" && n != "Beef Pita Doner (s)" && n != "Beef Pita Doner (s) (wc)" && Regex.Matches(n, "Beef Pita Doner").Count == 1)
                                    {
                                        if (n == "Beef Pita Doner (vegetarian) " || n == "Beef Pita Doner (wc) (vegetarian) " || n == "Beef Pita Doner (s) (vegetarian) " || n == "Beef Pita Doner (s) (wc) (vegetarian) ")
                                        {
                                            if(n == "Beef Pita Doner (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if(n == "Beef Pita Doner (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if(n == "Beef Pita Doner (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if(n == "Beef Pita Doner (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (n != "Chicken Pita Doner (wc)" && n != "Chicken Pita Doner (s)" && n != "Chicken Pita Doner (s) (wc)" && Regex.Matches(n, "Chicken Pita Doner").Count == 1)
                                    {
                                        if (n == "Chicken Pita Doner (vegetarian) " || n == "Chicken Pita Doner (wc) (vegetarian) " || n == "Chicken Pita Doner (s) (vegetarian) " || n == "Chicken Pita Doner (s) (wc) (vegetarian) ")
                                        {
                                            if (n == "Chicken Pita Doner (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Chicken Pita Doner (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Chicken Pita Doner (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Chicken Pita Doner (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prechicken"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (n != "Kebab Wrap (wc)" && n != "Kebab Wrap (s)" && n != "Kebab Wrap (s) (wc)" && Regex.Matches(n, "Kebab Wrap").Count == 1)
                                    {
                                        if (n == "Kebab Wrap (vegetarian) " || n == "Kebab Wrap (wc) (vegetarian) " || n == "Kebab Wrap (s) (vegetarian) " || n == "Kebab Wrap (s) (wc) (vegetarian) ")
                                        {
                                            if (n == "Kebab Wrap (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Kebab Wrap (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Kebab Wrap (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Kebab Wrap (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (n != "Hotdog Wrap (wc)" && n != "Hotdog Wrap (s)" && n != "Hotdog Wrap (s) (wc)" && Regex.Matches(n, "Hotdog Wrap").Count == 1)
                                    {
                                        if (n == "Hotdog Wrap (vegetarian) " || n == "Hotdog Wrap (wc) (vegetarian) " || n == "Hotdog Wrap (s) (vegetarian) " || n == "Hotdog Wrap (s) (wc) (vegetarian) ")
                                        {
                                            if (n == "Hotdog Wrap (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Hotdog Wrap (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Hotdog Wrap (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Hotdog Wrap (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prehotdog"]);
                                                }
                                            }
                                            if (pb >= 12)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Beef Doner on Rice").Count == 1)
                                    {
                                        if (n == "Beef Doner on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bdor = bdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bdor = bdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1.25";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Chicken Doner on Rice").Count == 1)
                                    {
                                        if (n == "Chicken Doner on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cdor = cdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cdor = cdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1.25";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prechicken"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Kebab on Rice").Count == 1)
                                    {
                                        if (n == "Kebab on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET kor = kor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET kor = kor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +2";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Hotdog on Rice").Count == 1)
                                    {
                                        if (n == "Hotdog on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET hr = hr +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET hr = hr +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +2";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prehotdog"]);
                                                }
                                            }
                                            if (pb >= 12)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Beef Doner Steak").Count == 1)
                                    {
                                        if (n == "Beef Doner Steak (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bds = bds +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bds = bds +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                    }
                                    else if (Regex.Matches(n, "Chicken Doner Steak").Count == 1)
                                    {
                                        if (n == "Beef Doner Steak (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cds = cds +1, csteakout = csteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cds = cds +1, csteakout = csteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                    }
                                    else if (Regex.Matches(n, "Beef and Chicken Platter").Count == 1)
                                    {
                                        if (n == "Beef and Chicken Platter (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bcp = bcp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bcp = bcp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                            cmd_rec3.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prechicken = prechicken +2";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            double pb2 = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                    pb2 = Convert.ToDouble(res_get["prechicken"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                            if (pb2 >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Kebab and Beef Platter").Count == 1)
                                    {
                                        if (n == "Kebab and Beef Platter (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bkp = bkp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bkp = bkp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                            cmd_rec3.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prekebab = prekebab +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            double pb2 = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                    pb2 = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                            if (pb2 >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Kebab and Chicken Platter").Count == 1)
                                    {
                                        if (n == "Kebab and Chicken Platter (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET ckp = ckp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET ckp = ckp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                            cmd_rec3.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +2, prekebab = prekebab +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            double pb2 = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prechicken"]);
                                                    pb2 = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                            if (pb2 >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (n == "Beef Pita Doner (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotodog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }

                                    else if (n == "Chicken Pita Doner w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    if (n == "Beef Pita Doner (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink (s)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwd = bpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Chicken Pita Doner w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwd = cpdwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenfout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwd = kwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwd = hwwd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Beef Pita Doner w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET bpdwfnd = bpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prebeef"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }

                                    else if (n == "Chicken Pita Doner w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET cpdwfnd = cpdwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prechicken"]);
                                            }
                                        }
                                        if (pb >= 20)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Kebab Wrap w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET kwwfnd = kwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prekebab"]);
                                            }
                                        }
                                        if (pb >= 10)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n == "Hotdog Wrap w/ Fries and Drink (s) (wc)")
                                    {
                                        string qry_rec = "UPDATE tbl_transactions SET hwwfnd = hwwfnd +1, pitaout = pitaout +1, conesout = conesout +1, cupsout = cupsout +1, friesbagsout = friesbagsout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                        SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                        cmd_rec.ExecuteNonQuery();

                                        //TEMPORARY
                                        string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                        SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                        cmd_rec2.ExecuteNonQuery();

                                        string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                        SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                        cmd_upd.ExecuteNonQuery();
                                        string qry_get = "SELECT * FROM tbl_prepack";
                                        SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                        double pb = 0;
                                        SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                        if (res_get.HasRows)
                                        {
                                            while (res_get.Read())
                                            {
                                                pb = Convert.ToDouble(res_get["prehotdog"]);
                                            }
                                        }
                                        if (pb >= 12)
                                        {
                                            string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                            cmd_upd2.ExecuteNonQuery();

                                            string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                            SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                            cmd_upd3.ExecuteNonQuery();
                                        }
                                    }
                                    else if (n != "Beef Pita Doner (wc)" && n != "Beef Pita Doner (s)" && n != "Beef Pita Doner (s) (wc)" && Regex.Matches(n, "Beef Pita Doner").Count == 1)
                                    {
                                        if (n == "Beef Pita Doner (vegetarian) " || n == "Beef Pita Doner (wc) (vegetarian) " || n == "Beef Pita Doner (s) (vegetarian) " || n == "Beef Pita Doner (s) (wc) (vegetarian) ")
                                        {
                                            if (n == "Beef Pita Doner (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Beef Pita Doner (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Beef Pita Doner (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Beef Pita Doner (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET bpd = bpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (n != "Chicken Pita Doner (wc)" && n != "Chicken Pita Doner (s)" && n != "Chicken Pita Doner (s) (wc)" && Regex.Matches(n, "Chicken Pita Doner").Count == 1)
                                    {
                                        if (n == "Chicken Pita Doner (vegetarian) " || n == "Chicken Pita Doner (wc) (vegetarian) " || n == "Chicken Pita Doner (s) (vegetarian) " || n == "Chicken Pita Doner (s) (wc) (vegetarian) ")
                                        {
                                            if (n == "Chicken Pita Doner (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Chicken Pita Doner (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Chicken Pita Doner (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Chicken Pita Doner (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET cpd = cpd +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prechicken"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (n != "Kebab Wrap (wc)" && n != "Kebab Wrap (s)" && n != "Kebab Wrap (s) (wc)" && Regex.Matches(n, "Kebab Wrap").Count == 1)
                                    {
                                        if (n == "Kebab Wrap (vegetarian) " || n == "Kebab Wrap (wc) (vegetarian) " || n == "Kebab Wrap (s) (vegetarian) " || n == "Kebab Wrap (s) (wc) (vegetarian) ")
                                        {
                                            if (n == "Kebab Wrap (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Kebab Wrap (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Kebab Wrap (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Kebab Wrap (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET kw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (n != "Hotdog Wrap (wc)" && n != "Hotdog Wrap (s)" && n != "Hotdog Wrap (s) (wc)" && Regex.Matches(n, "Hotdog Wrap").Count == 1)
                                    {
                                        if (n == "Hotdog Wrap (vegetarian) " || n == "Hotdog Wrap (wc) (vegetarian) " || n == "Hotdog Wrap (s) (vegetarian) " || n == "Hotdog Wrap (s) (wc) (vegetarian) ")
                                        {
                                            if (n == "Hotdog Wrap (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Hotdog Wrap (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Hotdog Wrap (s) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else if (n == "Hotdog Wrap (s) (wc) (vegetarian) ")
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = hw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                        }
                                        else
                                        {
                                            if (Regex.Matches(n, "(wc)").Count == 1)
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = kw +1, pitaout = pitaout +1, conesout = conesout +1, cheeseout = cheeseout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                string qry_rec = "UPDATE tbl_transactions SET hw = kw +1, pitaout = pitaout +1, conesout = conesout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                                cmd_rec.ExecuteNonQuery();
                                            }

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prehotdog"]);
                                                }
                                            }
                                            if (pb >= 12)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Beef Doner on Rice").Count == 1)
                                    {
                                        if (n == "Beef Doner on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bdor = bdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bdor = bdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +1.25";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Chicken Doner on Rice").Count == 1)
                                    {
                                        if (n == "Chicken Doner on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cdor = cdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cdor = cdor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +1.25";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prechicken"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Kebab on Rice").Count == 1)
                                    {
                                        if (n == "Kebab on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET kor = kor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET kor = kor +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prekebab = prekebab +2";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Hotdog on Rice").Count == 1)
                                    {
                                        if (n == "Hotdog on Rice (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET hr = hr +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET hr = hr +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Hotdog'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prehotdog = prehotdog +2";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prehotdog"]);
                                                }
                                            }
                                            if (pb >= 12)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET hotdogout = hotdogout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prehotdog = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Beef Doner Steak").Count == 1)
                                    {
                                        if (n == "Beef Doner Steak (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bds = bds +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bds = bds +1, bsteakout = bsteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                    }
                                    else if (Regex.Matches(n, "Chicken Doner Steak").Count == 1)
                                    {
                                        if (n == "Beef Doner Steak (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cds = cds +1, csteakout = csteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET cds = cds +1, csteakout = csteakout +1, mealboxout = mealboxout +1 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                    }
                                    else if (Regex.Matches(n, "Beef and Chicken Platter").Count == 1)
                                    {
                                        if (n == "Beef and Chicken Platter (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bcp = bcp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bcp = bcp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                            cmd_rec3.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prechicken = prechicken +2";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            double pb2 = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                    pb2 = Convert.ToDouble(res_get["prechicken"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                            if (pb2 >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Kebab and Beef Platter").Count == 1)
                                    {
                                        if (n == "Kebab and Beef Platter (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bkp = bkp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET bkp = bkp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Beef'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                            cmd_rec3.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prebeef = prebeef +2, prekebab = prekebab +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            double pb2 = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prebeef"]);
                                                    pb2 = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET beefout = beefout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prebeef = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                            if (pb2 >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    else if (Regex.Matches(n, "Kebab and Chicken Platter").Count == 1)
                                    {
                                        if (n == "Kebab and Chicken Platter (vegetarian) ")
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET ckp = ckp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string qry_rec = "UPDATE tbl_transactions SET ckp = ckp +1, platterboxout = platterboxout +1, minipitaout = minipitaout +2 WHERE date = '" + date + "'";
                                            SQLiteCommand cmd_rec = new SQLiteCommand(qry_rec, myConnection);
                                            cmd_rec.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec2 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Kebab'";
                                            SQLiteCommand cmd_rec2 = new SQLiteCommand(qry_rec2, myConnection);
                                            cmd_rec2.ExecuteNonQuery();

                                            //TEMPORARY
                                            string qry_rec3 = "UPDATE tbl_ingredients SET in_stock = in_stock +1 WHERE in_name = 'Chicken'";
                                            SQLiteCommand cmd_rec3 = new SQLiteCommand(qry_rec3, myConnection);
                                            cmd_rec3.ExecuteNonQuery();

                                            string qry_upd = "UPDATE tbl_prepack SET prechicken = prechicken +2, prekebab = prekebab +1";
                                            SQLiteCommand cmd_upd = new SQLiteCommand(qry_upd, myConnection);
                                            cmd_upd.ExecuteNonQuery();
                                            string qry_get = "SELECT * FROM tbl_prepack";
                                            SQLiteCommand cmd_get = new SQLiteCommand(qry_get, myConnection);
                                            double pb = 0;
                                            double pb2 = 0;
                                            SQLiteDataReader res_get = cmd_get.ExecuteReader();
                                            if (res_get.HasRows)
                                            {
                                                while (res_get.Read())
                                                {
                                                    pb = Convert.ToDouble(res_get["prechicken"]);
                                                    pb2 = Convert.ToDouble(res_get["prekebab"]);
                                                }
                                            }
                                            if (pb >= 20)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET chickenout = chickenout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prechicken = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                            if (pb2 >= 10)
                                            {
                                                string qry_upd2 = "UPDATE tbl_transactions SET kebabout = kebabout +1 WHERE date = '" + date + "'";
                                                SQLiteCommand cmd_upd2 = new SQLiteCommand(qry_upd2, myConnection);
                                                cmd_upd2.ExecuteNonQuery();

                                                string qry_upd3 = "UPDATE tbl_prepack SET prekebab = 0";
                                                SQLiteCommand cmd_upd3 = new SQLiteCommand(qry_upd3, myConnection);
                                                cmd_upd3.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }
                            }
                            sqlComm = new SQLiteCommand("end", myConnection);
                            sqlComm.ExecuteNonQuery();
                            closeConnection();
                        }
                        
                        //RESET
                        OrderList.Controls.Clear();
                        foodlayout.Controls.Clear();
                        total = 0;
                        item_total.Visible = false;
                        btn_confirm.Enabled = false;
                        btn_discounts.Enabled = false;
                        btn_cancel.Enabled = false;
                        btn_remove.Enabled = false;
                        btn_editqty.Enabled = false;
                        btn_split.Enabled = false;
                        btn_upgrade.Enabled = false;
                    }
                }
            }
        }
    }
}
