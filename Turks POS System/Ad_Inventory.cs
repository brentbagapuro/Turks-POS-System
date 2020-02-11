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
    public partial class Ad_Inventory : UserControl
    {
        public SQLiteConnection myConnection;

        public Ad_Inventory()
        {
            InitializeComponent();

            //dispTbl();
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

            //string toDisplay = string.Join(Environment.NewLine, itemname);
            //MessageBox.Show(toDisplay);

            tbl_inventory.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tbl_inventory.Visible = false;
            tbl_inventory.Controls.Clear();
            tbl_inventory.ColumnCount = 2;
            tbl_inventory.RowCount = row;
            TableLayoutRowStyleCollection styles = tbl_inventory.RowStyles;
            foreach (RowStyle style in styles)
            {
                // Set the row height to 20 pixels.
                style.SizeType = SizeType.Absolute;
                style.Height = 30;
            }
            tbl_inventory.RowStyles.Clear();
            tbl_inventory.AutoScroll = true;
            tbl_inventory.Controls.Add(new Label() { Text = "Item" }, 0, 0);
            tbl_inventory.Controls.Add(new Label() { Text = "Total Stock" }, 1, 0);
            for (int i = 1, j = 0; i < row + 1; i++, j++)
            {
                tbl_inventory.Controls.Add(new Label() { Text = itemname[j], AutoSize = true }, 0, i);
                tbl_inventory.Controls.Add(new Label() { Text = totalstock[j], AutoSize = true }, 1, i);
                //tbl_inventory.Controls.Add(new Label() { Text = "Test", AutoSize = true }, 0, i);
                //tbl_inventory.Controls.Add(new Label() { Text = "Test2", AutoSize = true }, 1, i);
            }
            tbl_inventory.Visible = true;

            closeConnection();
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
    }
}