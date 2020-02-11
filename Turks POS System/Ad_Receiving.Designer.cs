namespace Turks_POS_System
{
    partial class Ad_Receiving
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbl_inventory = new System.Windows.Forms.TableLayoutPanel();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_restock = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbl_materials = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 67);
            this.label1.TabIndex = 6;
            this.label1.Text = "Receiving";
            // 
            // tbl_inventory
            // 
            this.tbl_inventory.AutoScroll = true;
            this.tbl_inventory.AutoSize = true;
            this.tbl_inventory.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbl_inventory.ColumnCount = 2;
            this.tbl_inventory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_inventory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_inventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbl_inventory.Location = new System.Drawing.Point(4, 3);
            this.tbl_inventory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.tbl_inventory.Name = "tbl_inventory";
            this.tbl_inventory.RowCount = 2;
            this.tbl_inventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_inventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_inventory.Size = new System.Drawing.Size(520, 131);
            this.tbl_inventory.TabIndex = 7;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(309, 13);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 44);
            this.btn_refresh.TabIndex = 8;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_restock
            // 
            this.btn_restock.Location = new System.Drawing.Point(390, 13);
            this.btn_restock.Name = "btn_restock";
            this.btn_restock.Size = new System.Drawing.Size(160, 44);
            this.btn_restock.TabIndex = 9;
            this.btn_restock.Text = "Restock Inventory";
            this.btn_restock.UseVisualStyleBackColor = true;
            this.btn_restock.Click += new System.EventHandler(this.btn_restock_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tbl_inventory);
            this.panel1.Location = new System.Drawing.Point(17, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 675);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbl_materials);
            this.panel2.Location = new System.Drawing.Point(576, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 675);
            this.panel2.TabIndex = 11;
            // 
            // tbl_materials
            // 
            this.tbl_materials.AutoScroll = true;
            this.tbl_materials.AutoSize = true;
            this.tbl_materials.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tbl_materials.ColumnCount = 2;
            this.tbl_materials.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_materials.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_materials.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbl_materials.Location = new System.Drawing.Point(3, 3);
            this.tbl_materials.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.tbl_materials.Name = "tbl_materials";
            this.tbl_materials.RowCount = 2;
            this.tbl_materials.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_materials.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbl_materials.Size = new System.Drawing.Size(520, 131);
            this.tbl_materials.TabIndex = 8;
            // 
            // Ad_Receiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_restock);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.label1);
            this.Name = "Ad_Receiving";
            this.Size = new System.Drawing.Size(1114, 783);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TableLayoutPanel tbl_inventory;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_restock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TableLayoutPanel tbl_materials;
    }
}
