namespace Turks_POS_System
{
    partial class Split_Dialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_confirm_split = new System.Windows.Forms.Button();
            this.lbl_qty = new System.Windows.Forms.Label();
            this.currentfood2 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Quantity";
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(12, 480);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(136, 73);
            this.btn_back.TabIndex = 19;
            this.btn_back.Text = "<<";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_confirm_split
            // 
            this.btn_confirm_split.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_confirm_split.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm_split.Location = new System.Drawing.Point(1016, 480);
            this.btn_confirm_split.Name = "btn_confirm_split";
            this.btn_confirm_split.Size = new System.Drawing.Size(136, 73);
            this.btn_confirm_split.TabIndex = 18;
            this.btn_confirm_split.Text = "ADD";
            this.btn_confirm_split.UseVisualStyleBackColor = true;
            // 
            // lbl_qty
            // 
            this.lbl_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_qty.Location = new System.Drawing.Point(12, 322);
            this.lbl_qty.Name = "lbl_qty";
            this.lbl_qty.Size = new System.Drawing.Size(188, 121);
            this.lbl_qty.TabIndex = 17;
            this.lbl_qty.Text = "-qty-";
            this.lbl_qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentfood2
            // 
            this.currentfood2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentfood2.Location = new System.Drawing.Point(12, 10);
            this.currentfood2.Name = "currentfood2";
            this.currentfood2.Size = new System.Drawing.Size(188, 265);
            this.currentfood2.TabIndex = 16;
            // 
            // Split_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 563);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_confirm_split);
            this.Controls.Add(this.lbl_qty);
            this.Controls.Add(this.currentfood2);
            this.Name = "Split_Dialog";
            this.Text = "Split_Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_confirm_split;
        public System.Windows.Forms.Label lbl_qty;
        public System.Windows.Forms.FlowLayoutPanel currentfood2;
    }
}