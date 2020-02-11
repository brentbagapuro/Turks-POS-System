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
using System.Text.RegularExpressions;

namespace Turks_POS_System
{
    public partial class Ad_Maintenance : UserControl
    {
        public SQLiteConnection myConnection;

        public Ad_Maintenance()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ////input food item details
            //string uptype = "Rice";
            //string main_sub = "Beef Doner Bowl (special)";
            //string up_image = "Beef_Doner_Bowl";
            //string up_price = "50";
            //string up_mat = "Rice Bowl";

            //myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            ////edit sql statement to copy ingredient exclusions that match current food item
            //string qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Beef_Doner_on_Rice'";
            //string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Beef_Doner_on_Rice'";
            ////string qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            ////string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            //SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            //SQLiteCommand myCommand2 = new SQLiteCommand(qry2, myConnection);

            //openConnection();
            //int len = Convert.ToInt32(myCommand2.ExecuteScalar());
            //SQLiteDataReader result = myCommand.ExecuteReader();
            //string ing = "";
            //string name = "";
            //string[] names = new string[len];
            //string[] ings = new string[len];
            //int i = 0;
            //if (result.HasRows)
            //{
            //    while (result.Read())
            //    {
            //        name = result["up_name"].ToString();
            //        //replace below with current food item
            //        names[i] = "Beef Doner Bowl " + name.Substring(name.IndexOf("("));

            //        ing = result["up_ingredients"].ToString();
            //        //string[] ingss = ing.Split(',');
            //        //for (int c = 0; c < ingss.Length; c++)
            //        //{
            //        //    //replace below with food item ingredient if necessary
            //        //    if (ingss[c] == "Pita")
            //        //    {
            //        //        ing = ing.Replace("Pita", "Small Pita");
            //        //    }
            //        //}
            //        ings[i] = ing;

            //        string qry_ins = "INSERT INTO tbl_upgrades ('up_name', 'up_type', 'up_price', 'up_image', 'up_sub', 'up_ingredients', 'main_sub', 'up_mat') " +
            //                        "VALUES (@up_name, @up_type, @up_price, @up_image, @up_sub, @up_ingredients, @main_sub, @up_mat)";
            //        SQLiteCommand cmd_ins = new SQLiteCommand(qry_ins, myConnection);
            //        openConnection();
            //        cmd_ins.Parameters.AddWithValue("@up_name", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_type", uptype);
            //        cmd_ins.Parameters.AddWithValue("@up_price", up_price);
            //        cmd_ins.Parameters.AddWithValue("@up_image", up_image);
            //        cmd_ins.Parameters.AddWithValue("@up_sub", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_ingredients", ings[i]);
            //        cmd_ins.Parameters.AddWithValue("@main_sub", main_sub);
            //        cmd_ins.Parameters.AddWithValue("@up_mat", up_mat);
            //        var res_ins = cmd_ins.ExecuteNonQuery();

            //        i++;
            //    }
            //}
            //closeConnection();

            //uptype = "Rice";
            //main_sub = "Beef Doner Bowl (special)";
            //up_image = "Beef_Doner_Bowl_with_Drink";
            //up_price = "70";
            //up_mat = "Rice Bowl,Cups";

            //myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            ////edit sql statement to copy ingredient exclusions that match current food item
            //qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Beef_Doner_on_Rice_with_Drink'";
            //qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Beef_Doner_on_Rice_with_Drink'";
            ////string qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            ////string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            //myCommand = new SQLiteCommand(qry, myConnection);
            //myCommand2 = new SQLiteCommand(qry2, myConnection);

            //openConnection();
            //len = Convert.ToInt32(myCommand2.ExecuteScalar());
            //result = myCommand.ExecuteReader();
            //ing = "";
            //name = "";
            //names = new string[len];
            //ings = new string[len];
            //i = 0;
            //if (result.HasRows)
            //{
            //    while (result.Read())
            //    {
            //        name = result["up_name"].ToString();
            //        //replace below with current food item
            //        names[i] = "Beef Doner Bowl w/ Drink " + name.Substring(name.IndexOf("("));

            //        ing = result["up_ingredients"].ToString();
            //        //string[] ingss = ing.Split(',');
            //        //for (int c = 0; c < ingss.Length; c++)
            //        //{
            //        //    //replace below with food item ingredient if necessary
            //        //    if (ingss[c] == "Pita")
            //        //    {
            //        //        ing = ing.Replace("Pita", "Small Pita");
            //        //    }
            //        //}
            //        ings[i] = ing;

            //        string qry_ins = "INSERT INTO tbl_upgrades ('up_name', 'up_type', 'up_price', 'up_image', 'up_sub', 'up_ingredients', 'main_sub', 'up_mat') " +
            //                        "VALUES (@up_name, @up_type, @up_price, @up_image, @up_sub, @up_ingredients, @main_sub, @up_mat)";
            //        SQLiteCommand cmd_ins = new SQLiteCommand(qry_ins, myConnection);
            //        openConnection();
            //        cmd_ins.Parameters.AddWithValue("@up_name", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_type", uptype);
            //        cmd_ins.Parameters.AddWithValue("@up_price", up_price);
            //        cmd_ins.Parameters.AddWithValue("@up_image", up_image);
            //        cmd_ins.Parameters.AddWithValue("@up_sub", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_ingredients", ings[i]);
            //        cmd_ins.Parameters.AddWithValue("@main_sub", main_sub);
            //        cmd_ins.Parameters.AddWithValue("@up_mat", up_mat);
            //        var res_ins = cmd_ins.ExecuteNonQuery();

            //        i++;
            //    }
            //}
            //closeConnection();

            //uptype = "Rice";
            //main_sub = "Chicken Doner Bowl (special)";
            //up_image = "Chicken_Doner_Bowl";
            //up_price = "50";
            //up_mat = "Rice Bowl";

            //myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            ////edit sql statement to copy ingredient exclusions that match current food item
            //qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Chicken_Doner_on_Rice'";
            //qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Chicken_Doner_on_Rice'";
            ////string qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            ////string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            //myCommand = new SQLiteCommand(qry, myConnection);
            //myCommand2 = new SQLiteCommand(qry2, myConnection);

            //openConnection();
            //len = Convert.ToInt32(myCommand2.ExecuteScalar());
            //result = myCommand.ExecuteReader();
            //ing = "";
            //name = "";
            //names = new string[len];
            //ings = new string[len];
            //i = 0;
            //if (result.HasRows)
            //{
            //    while (result.Read())
            //    {
            //        name = result["up_name"].ToString();
            //        //replace below with current food item
            //        names[i] = "Chicken Doner Bowl " + name.Substring(name.IndexOf("("));

            //        ing = result["up_ingredients"].ToString();
            //        //string[] ingss = ing.Split(',');
            //        //for (int c = 0; c < ingss.Length; c++)
            //        //{
            //        //    //replace below with food item ingredient if necessary
            //        //    if (ingss[c] == "Pita")
            //        //    {
            //        //        ing = ing.Replace("Pita", "Small Pita");
            //        //    }
            //        //}
            //        ings[i] = ing;

            //        string qry_ins = "INSERT INTO tbl_upgrades ('up_name', 'up_type', 'up_price', 'up_image', 'up_sub', 'up_ingredients', 'main_sub', 'up_mat') " +
            //                        "VALUES (@up_name, @up_type, @up_price, @up_image, @up_sub, @up_ingredients, @main_sub, @up_mat)";
            //        SQLiteCommand cmd_ins = new SQLiteCommand(qry_ins, myConnection);
            //        openConnection();
            //        cmd_ins.Parameters.AddWithValue("@up_name", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_type", uptype);
            //        cmd_ins.Parameters.AddWithValue("@up_price", up_price);
            //        cmd_ins.Parameters.AddWithValue("@up_image", up_image);
            //        cmd_ins.Parameters.AddWithValue("@up_sub", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_ingredients", ings[i]);
            //        cmd_ins.Parameters.AddWithValue("@main_sub", main_sub);
            //        cmd_ins.Parameters.AddWithValue("@up_mat", up_mat);
            //        var res_ins = cmd_ins.ExecuteNonQuery();

            //        i++;
            //    }
            //}
            //closeConnection();

            //uptype = "Rice";
            //main_sub = "Chicken Doner Bowl (special)";
            //up_image = "Chicken_Doner_Bowl_with_Drink";
            //up_price = "70";
            //up_mat = "Rice Bowl,Cups";

            //myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            ////edit sql statement to copy ingredient exclusions that match current food item
            //qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Chicken_Doner_on_Rice_with_Drink'";
            //qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Chicken_Doner_on_Rice_with_Drink'";
            ////string qry = "SELECT * FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            ////string qry2 = "SELECT COUNT(*) FROM tbl_upgrades WHERE up_image = 'Hot_Sauce_with_Cheese' AND main_sub = 'Beef Pita Doner (s) (wc) (special)' AND up_price = '125'";
            //myCommand = new SQLiteCommand(qry, myConnection);
            //myCommand2 = new SQLiteCommand(qry2, myConnection);

            //openConnection();
            //len = Convert.ToInt32(myCommand2.ExecuteScalar());
            //result = myCommand.ExecuteReader();
            //ing = "";
            //name = "";
            //names = new string[len];
            //ings = new string[len];
            //i = 0;
            //if (result.HasRows)
            //{
            //    while (result.Read())
            //    {
            //        name = result["up_name"].ToString();
            //        //replace below with current food item
            //        names[i] = "Chicken Doner Bowl w/ Drink " + name.Substring(name.IndexOf("("));

            //        ing = result["up_ingredients"].ToString();
            //        //string[] ingss = ing.Split(',');
            //        //for (int c = 0; c < ingss.Length; c++)
            //        //{
            //        //    //replace below with food item ingredient if necessary
            //        //    if (ingss[c] == "Pita")
            //        //    {
            //        //        ing = ing.Replace("Pita", "Small Pita");
            //        //    }
            //        //}
            //        ings[i] = ing;

            //        string qry_ins = "INSERT INTO tbl_upgrades ('up_name', 'up_type', 'up_price', 'up_image', 'up_sub', 'up_ingredients', 'main_sub', 'up_mat') " +
            //                        "VALUES (@up_name, @up_type, @up_price, @up_image, @up_sub, @up_ingredients, @main_sub, @up_mat)";
            //        SQLiteCommand cmd_ins = new SQLiteCommand(qry_ins, myConnection);
            //        openConnection();
            //        cmd_ins.Parameters.AddWithValue("@up_name", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_type", uptype);
            //        cmd_ins.Parameters.AddWithValue("@up_price", up_price);
            //        cmd_ins.Parameters.AddWithValue("@up_image", up_image);
            //        cmd_ins.Parameters.AddWithValue("@up_sub", names[i]);
            //        cmd_ins.Parameters.AddWithValue("@up_ingredients", ings[i]);
            //        cmd_ins.Parameters.AddWithValue("@main_sub", main_sub);
            //        cmd_ins.Parameters.AddWithValue("@up_mat", up_mat);
            //        var res_ins = cmd_ins.ExecuteNonQuery();

            //        i++;
            //    }
            //}
            //closeConnection();

            //string toDisplay = string.Join(Environment.NewLine, names);
            //string toDisplay2 = string.Join(Environment.NewLine, ings);
            //MessageBox.Show(toDisplay.ToString());
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
    }
}
