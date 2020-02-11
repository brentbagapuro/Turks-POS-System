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
    public partial class Split_Dialog : Form
    {
        public Split_Dialog()
        {
            InitializeComponent();
            this.Text = "Split Food Item";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            Preupgrade_Dialog p = new Preupgrade_Dialog();
            p.ShowDialog();
        }
    }
}
