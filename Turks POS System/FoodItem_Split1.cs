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
    public partial class FoodItem_Split1 : UserControl
    {
        public FoodItem_Split1()
        {
            InitializeComponent();
            this.Load += FoodItem_Split1_Load;
        }

        public event EventHandler<EventArgs> WasClicked;

        private void FoodItem_Split1_Load(object sender, EventArgs e)
        {

            this.MouseClick += Control_MouseClick;
            foreach (Control control in Controls)
            {
                control.MouseClick += Control_MouseClick;
            }
        }

        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            var wasClicked = WasClicked;
            if (wasClicked != null)
            {
                WasClicked(this, EventArgs.Empty);
            }
            IsSelected = true;
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                this.BackColor = IsSelected ? SystemColors.GradientInactiveCaption : SystemColors.Control;
            }
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
