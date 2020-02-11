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
using System.IO;

namespace Turks_POS_System
{
    public partial class Login : Form
    {
        public SQLiteConnection myConnection;

        public Login()
        {
            InitializeComponent();
            this.Text = "Turks POS System v1.0";
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");
            //SELECT FROM DATABASE
            string qry = "SELECT * FROM users WHERE username = '"+username.Text+"' and password = '"+password.Text+"'";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            openConnection();
            SQLiteDataReader result = myCommand.ExecuteReader();
            int u_type = 0;
            if (result.HasRows)
            {
                while (result.Read())
                {
                    u_type = Convert.ToInt32(result["u_type"]);
                }
            }

            switch (u_type)
            {
                case 1:
                    admin.Visible = true;
                    break;
                case 2:
                    employee.Visible = true;
                    break;
                default: MessageBox.Show("Incorrect username or password");
                    break;
            }
            closeConnection();

            /*
            //INSERT INTO DATABASE
            string u = "emp2";
            string p = "1234";
            string qry = "INSERT INTO users ('username', 'password') VALUES (@user, @pass)";
            SQLiteCommand myCommand = new SQLiteCommand(qry, myConnection);
            openConnection();
            myCommand.Parameters.AddWithValue("@user", u);
            myCommand.Parameters.AddWithValue("@pass", p);
            var result = myCommand.ExecuteNonQuery();
            MessageBox.Show("Insert successful");
            closeConnection();
            */
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
    }
}
