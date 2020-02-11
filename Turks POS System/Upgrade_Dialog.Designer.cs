namespace Turks_POS_System
{
    partial class Upgrade_Dialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.foodpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_add = new System.Windows.Forms.Button();
            this.qty_input = new System.Windows.Forms.TextBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.lbl_qty = new System.Windows.Forms.Label();
            this.currentfood = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_sub = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // foodpanel
            // 
            this.foodpanel.AutoScroll = true;
            this.foodpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.foodpanel.Location = new System.Drawing.Point(224, 8);
            this.foodpanel.Name = "foodpanel";
            this.foodpanel.Size = new System.Drawing.Size(607, 286);
            this.foodpanel.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(363, 320);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(64, 59);
            this.btn_add.TabIndex = 4;
            this.btn_add.Text = "+";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // qty_input
            // 
            this.qty_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qty_input.Location = new System.Drawing.Point(224, 320);
            this.qty_input.Name = "qty_input";
            this.qty_input.Size = new System.Drawing.Size(133, 121);
            this.qty_input.TabIndex = 3;
            this.qty_input.TextChanged += new System.EventHandler(this.qty_input_TextChanged);
            // 
            // btn_confirm
            // 
            this.btn_confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.Location = new System.Drawing.Point(615, 368);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(250, 73);
            this.btn_confirm.TabIndex = 6;
            this.btn_confirm.Text = "CONFIRM";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.Btn_confirm);
            // 
            // lbl_qty
            // 
            this.lbl_qty.AutoSize = true;
            this.lbl_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_qty.Location = new System.Drawing.Point(257, 297);
            this.lbl_qty.Name = "lbl_qty";
            this.lbl_qty.Size = new System.Drawing.Size(69, 17);
            this.lbl_qty.TabIndex = 7;
            this.lbl_qty.Text = "Quantity";
            // 
            // currentfood
            // 
            this.currentfood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentfood.Location = new System.Drawing.Point(12, 8);
            this.currentfood.Name = "currentfood";
            this.currentfood.Size = new System.Drawing.Size(188, 265);
            this.currentfood.TabIndex = 8;
            // 
            // btn_sub
            // 
            this.btn_sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sub.Location = new System.Drawing.Point(363, 382);
            this.btn_sub.Name = "btn_sub";
            this.btn_sub.Size = new System.Drawing.Size(64, 59);
            this.btn_sub.TabIndex = 9;
            this.btn_sub.Text = "-";
            this.btn_sub.UseVisualStyleBackColor = true;
            this.btn_sub.Click += new System.EventHandler(this.btn_sub_Click);
            // 
            // Upgrade_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.btn_sub);
            this.Controls.Add(this.currentfood);
            this.Controls.Add(this.lbl_qty);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.foodpanel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.qty_input);
            this.Name = "Upgrade_Dialog";
            this.Text = "Upgrade_Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_add;
        public System.Windows.Forms.TextBox qty_input;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Label lbl_qty;
        private System.Windows.Forms.Button btn_sub;
        public System.Windows.Forms.FlowLayoutPanel currentfood;
        public System.Windows.Forms.FlowLayoutPanel foodpanel;
    }
}