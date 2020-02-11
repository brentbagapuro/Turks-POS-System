using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Turks_POS_System.Properties;
using System.Text.RegularExpressions;

namespace Turks_POS_System
{
    public partial class Ad_Receiving : UserControl
    {
        public SQLiteConnection myConnection;

        public Ad_Receiving()
        {
            InitializeComponent();

            //dispTbl();
        }

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

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dispTbl();
        }
        
        public void dispTbl()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            string qry = "SELECT * FROM tbl_ingredients ORDER BY category_id";
            string qry2 = "SELECT COUNT(*) FROM tbl_ingredients";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            openConnection();
            int row = Convert.ToInt32(myCommand2.ExecuteScalar());
            SQLiteDataReader result = myCommand.ExecuteReader();
            string[] itemname = new string[row];
            string[] totalstock = new string[row];
            int cnt = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    itemname[cnt] = result["in_name"].ToString();
                    totalstock[cnt] = result["in_stock"].ToString();
                    cnt++;
                }
            }

            tbl_inventory.Visible = false;
            tbl_inventory.Controls.Clear();
            tbl_inventory.ColumnCount = 3;
            tbl_inventory.RowCount = row;
            TableLayoutRowStyleCollection styles = tbl_inventory.RowStyles;
            foreach (RowStyle style in styles)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = 30;
            }
            tbl_inventory.RowStyles.Clear();
            tbl_inventory.AutoScroll = true;
            tbl_inventory.Controls.Add(new Label() { Text = "Item" }, 0, 0);
            tbl_inventory.Controls.Add(new Label() { Text = "Total Stock" }, 1, 0);
            for (int i = 1, j = 0; i < row + 1; i++, j++)
            {
                tbl_inventory.Controls.Add(new Label() { Name = itemname[j], Text = itemname[j], AutoSize = true }, 0, i);
                tbl_inventory.Controls.Add(new Label() { Name = "lbl_" + itemname[j], Text = totalstock[j], AutoSize = true }, 1, i);
                tbl_inventory.Controls.Add(new TextBox() { Name = "txt_" + itemname[j] }, 2, i);
            }
            tbl_inventory.Visible = true;

            string qry3 = "SELECT * FROM tbl_materials";
            string qry4 = "SELECT COUNT(*) FROM tbl_materials";
            SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
            SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
            openConnection();
            int row2 = Convert.ToInt32(myCommand4.ExecuteScalar());
            SQLiteDataReader result2 = myCommand3.ExecuteReader();
            string[] itemname2 = new string[row2];
            string[] totalstock2 = new string[row2];
            int cnt2 = 0;
            if (result2.HasRows)
            {
                while (result2.Read())
                {
                    itemname2[cnt2] = result2["mat_name"].ToString();
                    totalstock2[cnt2] = result2["mat_stock"].ToString();
                    cnt2++;
                }
            }

            tbl_materials.Visible = false;
            tbl_materials.Controls.Clear();
            tbl_materials.ColumnCount = 3;
            tbl_materials.RowCount = row2;
            TableLayoutRowStyleCollection styles2 = tbl_materials.RowStyles;
            foreach (RowStyle style in styles2)
            {
                style.SizeType = SizeType.Absolute;
                style.Height = 30;
            }
            tbl_materials.RowStyles.Clear();
            tbl_materials.AutoScroll = true;
            tbl_materials.Controls.Add(new Label() { Text = "Item" }, 0, 0);
            tbl_materials.Controls.Add(new Label() { Text = "Total Stock" }, 1, 0);
            for (int i = 1, j = 0; i < row2 + 1; i++, j++)
            {
                tbl_materials.Controls.Add(new Label() { Name = itemname2[j], Text = itemname2[j], AutoSize = true }, 0, i);
                tbl_materials.Controls.Add(new Label() { Name = "lbl_" + itemname2[j], Text = totalstock2[j], AutoSize = true }, 1, i);
                tbl_materials.Controls.Add(new TextBox() { Name = "txt_" + itemname2[j] }, 2, i);
            }
            tbl_materials.Visible = true;

            closeConnection();
        }

        private void btn_restock_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("dd/MM/yyyy");
            string yesterday = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");

            string qry_date = "SELECT COUNT(*) FROM tbl_insandlos WHERE date = '" + date + "'";
            SQLiteCommand cmd_date = new SQLiteCommand(qry_date, myConnection);
            openConnection();
            int check_date = Convert.ToInt32(cmd_date.ExecuteScalar());

            if (check_date == 0)
            {
                SQLiteCommand sqlComm = new SQLiteCommand("begin", myConnection);
                sqlComm.ExecuteNonQuery();
                string qry_trans = "INSERT INTO tbl_insandlos ('date', 'pitapastlo', 'pitapresentin', 'pitapresentlo', 'ricepastlo', 'ricepresentin', 'ricepresentlo', 'kebabpastlo', 'kebabpresentin', 'kebabpresentlo', 'mealboxpastlo', 'mealboxpresentin', 'mealboxpresentlo', 'beefpastlo', 'beefpresentin', 'beefpresentlo', 'chickenpastlo', 'chickenpresentin', 'chickenpresentlo', 'bsteakpastlo', 'bsteakpresentin', 'bsteakpresentlo', 'csteakpastlo', 'csteakpresentin', 'csteakpresentlo', 'cheesepastlo', 'cheesepresentin', 'cheesepresentlo', 'friesbagspastlo', 'friesbagspresentin', 'friesbagspresentlo', 'minicupspastlo', 'minicupspresentin', 'minicupspresentlo', 'conespastlo', 'conespresentin', 'conespresentlo', 'cupspastlo', 'cupspresentin', 'cupspresentlo', 'waterpastlo', 'waterpresentin', 'waterpresentlo', 'sodapastlo', 'sodapresentin', 'sodapresentlo', 'platterboxpastlo', 'platterboxpresentin', 'platterboxpresentlo', 'minipitapastlo', 'minipitapresentin', 'minipitapresentlo', 'hotdogpastlo', 'hotdogpresentin', 'hotdogpresentlo') " +
                                    "VALUES (@date, @pitapastlo, @pitapresentin, @pitapresentlo, @ricepastlo, @ricepresentin, @ricepresentlo, @kebabpastlo, @kebabpresentin, @kebabpresentlo, @mealboxpastlo, @mealboxpresentin, @mealboxpresentlo, @beefpastlo, @beefpresentin, @beefpresentlo, @chickenpastlo, @chickenpresentin, @chickenpresentlo, @bsteakpastlo, @bsteakpresentin, @bsteakpresentlo, @csteakpastlo, @csteakpresentin, @csteakpresentlo, @cheesepastlo, @cheesepresentin, @cheesepresentlo, @friesbagspastlo, @friesbagspresentin, @friesbagspresentlo, @minicupspastlo, @minicupspresentin, @minicupspresentlo, @conespastlo, @conespresentin, @conespresentlo, @cupspastlo, @cupspresentin, @cupspresentlo, @waterpastlo, @waterpresentin, @waterpresentlo, @sodapastlo, @sodapresentin, @sodapresentlo, @platterboxpastlo, @platterboxpresentin, @platterboxpresentlo, @minipitapastlo, @minipitapresentin, @minipitapresentlo, @hotdogpastlo, @hotdogpresentin, @hotdogpresentlo)";
                SQLiteCommand cmd_trans = new SQLiteCommand(qry_trans, myConnection);

                cmd_trans.Parameters.AddWithValue("@date", date);
                cmd_trans.Parameters.AddWithValue("@pitapastlo", 0);
                cmd_trans.Parameters.AddWithValue("@pitapresentin", 0);
                cmd_trans.Parameters.AddWithValue("@pitapresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@ricepastlo", 0);
                cmd_trans.Parameters.AddWithValue("@ricepresentin", 0);
                cmd_trans.Parameters.AddWithValue("@ricepresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@kebabpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@kebabpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@kebabpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@mealboxpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@mealboxpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@mealboxpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@beefpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@beefpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@beefpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@chickenpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@chickenpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@chickenpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@bsteakpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@bsteakpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@bsteakpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@csteakpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@csteakpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@csteakpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@cheesepastlo", 0);
                cmd_trans.Parameters.AddWithValue("@cheesepresentin", 0);
                cmd_trans.Parameters.AddWithValue("@cheesepresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@friesbagspastlo", 0);
                cmd_trans.Parameters.AddWithValue("@friesbagspresentin", 0);
                cmd_trans.Parameters.AddWithValue("@friesbagspresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@minicupspastlo", 0);
                cmd_trans.Parameters.AddWithValue("@minicupspresentin", 0);
                cmd_trans.Parameters.AddWithValue("@minicupspresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@conespastlo", 0);
                cmd_trans.Parameters.AddWithValue("@conespresentin", 0);
                cmd_trans.Parameters.AddWithValue("@conespresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@cupspastlo", 0);
                cmd_trans.Parameters.AddWithValue("@cupspresentin", 0);
                cmd_trans.Parameters.AddWithValue("@cupspresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@waterpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@waterpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@waterpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@sodapastlo", 0);
                cmd_trans.Parameters.AddWithValue("@sodapresentin", 0);
                cmd_trans.Parameters.AddWithValue("@sodapresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@platterboxpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@platterboxpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@platterboxpresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@minipitapastlo", 0);
                cmd_trans.Parameters.AddWithValue("@minipitapresentin", 0);
                cmd_trans.Parameters.AddWithValue("@minipitapresentlo", 0);
                cmd_trans.Parameters.AddWithValue("@hotdogpastlo", 0);
                cmd_trans.Parameters.AddWithValue("@hotdogpresentin", 0);
                cmd_trans.Parameters.AddWithValue("@hotdogpresentlo", 0);
                var res_trans = cmd_trans.ExecuteNonQuery();
                sqlComm = new SQLiteCommand("end", myConnection);
                sqlComm.ExecuteNonQuery();
            }

            string qry = "SELECT * FROM tbl_ingredients ORDER BY category_id";
            string qry2 = "SELECT COUNT(*) FROM tbl_ingredients";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            openConnection();
            int row = Convert.ToInt32(myCommand2.ExecuteScalar());
            SQLiteDataReader result = myCommand.ExecuteReader();
            string[] itemname = new string[row];
            string[] totalstock = new string[row];
            int cnt = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    itemname[cnt] = result["in_name"].ToString();
                    cnt++;
                }
            }

            foreach (string s in itemname)
            {
                TextBox t = (tbl_inventory.Controls.Find("txt_" + s, true).First() as TextBox);
                if(t.Text != "")
                {
                    Label c = (tbl_inventory.Controls.Find("lbl_" + s, true).First() as Label);
                    var current = Convert.ToInt32(c.Text);
                    var add = Convert.ToInt32(t.Text);
                    c.Text = (current + add).ToString();
                    t.Text = "";

                    Label d = (tbl_inventory.Controls.Find(s, true).First() as Label);

                    SQLiteCommand sqlComm = new SQLiteCommand("begin", myConnection);
                    sqlComm.ExecuteNonQuery();
                    string qry3 = "UPDATE tbl_ingredients SET in_stock = in_stock + '" + add + "' WHERE in_name = '" + d.Name + "'";
                    SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                    myCommand3.ExecuteNonQuery();
                    sqlComm = new SQLiteCommand("end", myConnection);
                    sqlComm.ExecuteNonQuery();

                    SQLiteCommand sqlComm2 = new SQLiteCommand("begin", myConnection);
                    sqlComm2.ExecuteNonQuery();
                    if (s == "Pita")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET pitapresentin = pitapresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Mini Pita")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET minipitapresentin = minipitapresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Rice")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET ricepresentin = ricepresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Kebab")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET kebabpresentin = kebabpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if(s == "Beef")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET beefpresentin = beefpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Chicken")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET chickenpresentin = chickenpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Hotdog")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET hotdogpresentin = hotdogpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Beef Steak")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET bsteakpresentin = bsteakpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Chicken Steak")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET csteakpresentin = csteakpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Cheddar Cheese")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET cheesepresentin = cheesepresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Water")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET waterpresentin = waterpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Coke" || s == "Sprite" || s == "Royal")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET sodapresentin = sodapresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    sqlComm2 = new SQLiteCommand("end", myConnection);
                    sqlComm2.ExecuteNonQuery();
                }
            }
            closeConnection();

            string qry_mat = "SELECT * FROM tbl_materials";
            string qry_mat2 = "SELECT COUNT(*) FROM tbl_materials";
            SQLiteCommand myCommand_mat = new SQLiteCommand(qry_mat, myConnection);
            SQLiteCommand myCommand_mat2 = new SQLiteCommand(qry_mat2, myConnection);

            openConnection();
            int row2 = Convert.ToInt32(myCommand_mat2.ExecuteScalar());
            SQLiteDataReader result2 = myCommand_mat.ExecuteReader();
            string[] itemname2 = new string[row2];
            string[] totalstock2 = new string[row2];
            int cnt2 = 0;
            if (result2.HasRows)
            {
                while (result2.Read())
                {
                    itemname2[cnt2] = result2["mat_name"].ToString();
                    cnt2++;
                }
            }

            foreach (string s in itemname2)
            {
                TextBox t = (tbl_materials.Controls.Find("txt_" + s, true).First() as TextBox);
                if (t.Text != "")
                {
                    Label c = (tbl_materials.Controls.Find("lbl_" + s, true).First() as Label);
                    var current = Convert.ToInt32(c.Text);
                    var add = Convert.ToInt32(t.Text);
                    c.Text = (current + add).ToString();
                    t.Text = "";

                    Label d = (tbl_materials.Controls.Find(s, true).First() as Label);

                    SQLiteCommand sqlComm = new SQLiteCommand("begin", myConnection);
                    sqlComm.ExecuteNonQuery();
                    string qry3 = "UPDATE tbl_materials SET mat_stock = mat_stock + '" + add + "' WHERE mat_name = '" + d.Name + "'";
                    SQLiteCommand myCommand3 = new SQLiteCommand(qry3, myConnection);
                    myCommand3.ExecuteNonQuery();
                    sqlComm = new SQLiteCommand("end", myConnection);
                    sqlComm.ExecuteNonQuery();

                    SQLiteCommand sqlComm2 = new SQLiteCommand("begin", myConnection);
                    sqlComm2.ExecuteNonQuery();
                    if (s == "Cones")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET conespresentin = conespresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Meal Box")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET mealboxpresentin = mealboxpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Platter Box")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET platterboxpresentin = platterboxpresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Fries Bags")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET friesbagspresentin = friesbagspresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Cups")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET cupspresentin = cupspresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    else if (s == "Mini Cups")
                    {
                        string qry4 = "UPDATE tbl_insandlos SET minicupspresentin = minicupspresentin + " + add + " WHERE date = '" + date + "'";
                        SQLiteCommand myCommand4 = new SQLiteCommand(qry4, myConnection);
                        myCommand4.ExecuteNonQuery();
                    }
                    sqlComm2 = new SQLiteCommand("end", myConnection);
                    sqlComm2.ExecuteNonQuery();
                }
            }
            closeConnection();
        }
    }
}
