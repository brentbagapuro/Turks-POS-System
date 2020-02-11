namespace Turks_POS_System
{
    partial class Confirm_Dialog
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
            this.lbl_bal = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lbl_cash = new System.Windows.Forms.Label();
            this.cust_cash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_bal
            // 
            this.lbl_bal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bal.Location = new System.Drawing.Point(-2, 30);
            this.lbl_bal.Name = "lbl_bal";
            this.lbl_bal.Size = new System.Drawing.Size(372, 59);
            this.lbl_bal.TabIndex = 0;
            this.lbl_bal.Text = "Total Balance:";
            this.lbl_bal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_total
            // 
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(1, 83);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(369, 73);
            this.lbl_total.TabIndex = 1;
            this.lbl_total.Text = "--total--";
            this.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_cash
            // 
            this.lbl_cash.AutoSize = true;
            this.lbl_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cash.Location = new System.Drawing.Point(123, 193);
            this.lbl_cash.Name = "lbl_cash";
            this.lbl_cash.Size = new System.Drawing.Size(129, 48);
            this.lbl_cash.TabIndex = 2;
            this.lbl_cash.Text = "Cash:";
            this.lbl_cash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cust_cash
            // 
            this.cust_cash.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cust_cash.Location = new System.Drawing.Point(84, 246);
            this.cust_cash.Name = "cust_cash";
            this.cust_cash.Size = new System.Drawing.Size(207, 64);
            this.cust_cash.TabIndex = 3;
            this.cust_cash.TextChanged += new System.EventHandler(this.cust_cash_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 58);
            this.label1.TabIndex = 4;
            this.label1.Text = "P";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = ".00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.Location = new System.Drawing.Point(145, 341);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(91, 57);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            // 
            // Confirm_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 498);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cust_cash);
            this.Controls.Add(this.lbl_cash);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.lbl_bal);
            this.Name = "Confirm_Dialog";
            this.Text = "Confirm_Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_bal;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lbl_cash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_OK;
        public System.Windows.Forms.TextBox cust_cash;
    }
}