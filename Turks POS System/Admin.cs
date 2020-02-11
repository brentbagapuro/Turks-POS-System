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

namespace Turks_POS_System
{
    public partial class Admin : UserControl
    {
        Timer timer1 = new Timer();
        public SQLiteConnection myConnection;

        public Admin()
        {
            InitializeComponent();
            ad_Sales.SendToBack();
            ad_Inventory.SendToBack();
            ad_Purchase_Orders.SendToBack();
            ad_Receiving.SendToBack();
            ad_maintenance.SendToBack();

            main_panel.Visible = true;
            Transaction_menu_panel.Visible = false;
            system_process_panel.Visible = false;

            //TIME
            sys_time.Text = DateTime.Now.ToString();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sys_time.Text = DateTime.Now.ToString();
        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            ad_Sales.BringToFront();
        }

        private void btn_purchase_orders_Click(object sender, EventArgs e)
        {
            ad_Purchase_Orders.BringToFront();
        }

        private void btn_main_Click(object sender, EventArgs e)
        {
            main_panel.Visible = true;
            ad_Main.BringToFront();
            Transaction_menu_panel.Visible = false;
            system_process_panel.Visible = false;
        }

        private void btn_main_transaction_Click(object sender, EventArgs e)
        {
            main_panel.Visible = true;
            Transaction_menu_panel.Visible = false;
            system_process_panel.Visible = false;
        }

        private void btn_main_system_Click(object sender, EventArgs e)
        {
            main_panel.Visible = true;
            Transaction_menu_panel.Visible = false;
            system_process_panel.Visible = false;
        }

        private void btn_transaction_Click(object sender, EventArgs e)
        {
            main_panel.Visible = false;
            Transaction_menu_panel.Visible = true;
            system_process_panel.Visible = false;
        }

        private void btn_system_process_Click(object sender, EventArgs e)
        {
            main_panel.Visible = false;
            Transaction_menu_panel.Visible = false;
            system_process_panel.Visible = true;
        }
        
        private void btn_inventory_Click(object sender, EventArgs e)
        {
            ad_Inventory.BringToFront();
        }

        private void btn_receiving_Click(object sender, EventArgs e)
        {
            ad_Receiving.BringToFront();
        }

        private void btn_reports_Click(object sender, EventArgs e)
        {
            reports.BringToFront();
        }

        private void btn_maintenance_Click(object sender, EventArgs e)
        {
            ad_maintenance.BringToFront();
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
