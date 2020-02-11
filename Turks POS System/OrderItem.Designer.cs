namespace Turks_POS_System
{
    partial class OrderItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.item_qty = new System.Windows.Forms.Label();
            this.item_name = new System.Windows.Forms.Label();
            this.item_subtotal = new System.Windows.Forms.Label();
            this.item_unitprice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // item_qty
            // 
            this.item_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_qty.Location = new System.Drawing.Point(0, 0);
            this.item_qty.Name = "item_qty";
            this.item_qty.Size = new System.Drawing.Size(40, 62);
            this.item_qty.TabIndex = 0;
            this.item_qty.Text = "Qty";
            this.item_qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // item_name
            // 
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.Location = new System.Drawing.Point(41, 0);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(275, 62);
            this.item_name.TabIndex = 1;
            this.item_name.Text = "Item name";
            this.item_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // item_subtotal
            // 
            this.item_subtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_subtotal.Location = new System.Drawing.Point(400, 0);
            this.item_subtotal.Name = "item_subtotal";
            this.item_subtotal.Size = new System.Drawing.Size(84, 62);
            this.item_subtotal.TabIndex = 2;
            this.item_subtotal.Text = "Subtotal";
            this.item_subtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // item_unitprice
            // 
            this.item_unitprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_unitprice.Location = new System.Drawing.Point(316, 0);
            this.item_unitprice.Name = "item_unitprice";
            this.item_unitprice.Size = new System.Drawing.Size(85, 62);
            this.item_unitprice.TabIndex = 3;
            this.item_unitprice.Text = "Unit Price";
            this.item_unitprice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.item_unitprice);
            this.Controls.Add(this.item_subtotal);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_qty);
            this.Name = "OrderItem";
            this.Size = new System.Drawing.Size(484, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label item_qty;
        private System.Windows.Forms.Label item_name;
        private System.Windows.Forms.Label item_subtotal;
        private System.Windows.Forms.Label item_unitprice;
    }
}
