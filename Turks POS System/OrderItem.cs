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
    public partial class OrderItem : UserControl
    {
        public OrderItem()
        {
            InitializeComponent();
            this.Load += OrderItem_Load;
        }

        public event EventHandler<EventArgs> WasClicked;

        private void OrderItem_Load(object sender, EventArgs e)
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
                this.BackColor = IsSelected ? SystemColors.GradientInactiveCaption : Color.White;
            }
        }

        private string _qty;
        private string _name;
        private string _uprice;
        private string _subtotal;

        [Category("Order Items")]
        public string Qty
        {
            get { return _qty; }
            set { _qty = value; item_qty.Text = value; }
        }

        [Category("Order Items")]
        public string Oname
        {
            get { return _name; }
            set { _name = value; item_name.Text = value; }
        }

        [Category("Order Items")]
        public string Unitprice
        {
            get { return _uprice; }
            set { _uprice = value; item_unitprice.Text = value; }
        }

        [Category("Order Items")]
        public string Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; item_subtotal.Text = value; }
        }
    }
}
