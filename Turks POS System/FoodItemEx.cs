using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turks_POS_System
{
    public partial class FoodItemEx : UserControl
    {
        public FoodItemEx()
        {
            InitializeComponent();
        }

        private Image _pic;
        private string _name;
        private string _price;

        [Category("Food Items")]
        public Image Pic
        {
            get { return _pic; }
            set { _pic = value; foodimage.Image = value; }
        }

        [Category("Food Items")]
        public string Fname
        {
            get { return _name; }
            set { _name = value; foodname.Text = value; }
        }

        [Category("Food Items")]
        public string Price
        {
            get { return _price; }
            set { _price = value; foodprice.Text = value; }
        }
    }
}
