﻿namespace Turks_POS_System
{
    partial class FoodItemEx
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
            this.foodprice = new System.Windows.Forms.Label();
            this.foodname = new System.Windows.Forms.Label();
            this.foodimage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.foodimage)).BeginInit();
            this.SuspendLayout();
            // 
            // foodprice
            // 
            this.foodprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodprice.Location = new System.Drawing.Point(5, 205);
            this.foodprice.Name = "foodprice";
            this.foodprice.Size = new System.Drawing.Size(182, 58);
            this.foodprice.TabIndex = 9;
            this.foodprice.Text = "Food Price";
            this.foodprice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // foodname
            // 
            this.foodname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodname.Location = new System.Drawing.Point(2, 142);
            this.foodname.Name = "foodname";
            this.foodname.Size = new System.Drawing.Size(185, 63);
            this.foodname.TabIndex = 8;
            this.foodname.Text = "Food Name";
            this.foodname.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // foodimage
            // 
            this.foodimage.Location = new System.Drawing.Point(2, 1);
            this.foodimage.Name = "foodimage";
            this.foodimage.Size = new System.Drawing.Size(185, 132);
            this.foodimage.TabIndex = 7;
            this.foodimage.TabStop = false;
            // 
            // FoodItemEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.foodprice);
            this.Controls.Add(this.foodname);
            this.Controls.Add(this.foodimage);
            this.Name = "FoodItemEx";
            this.Size = new System.Drawing.Size(188, 265);
            ((System.ComponentModel.ISupportInitialize)(this.foodimage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label foodprice;
        public System.Windows.Forms.Label foodname;
        private System.Windows.Forms.PictureBox foodimage;
    }
}
