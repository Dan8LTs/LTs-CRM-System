
namespace CrmUI
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Product = new System.Windows.Forms.ToolStripMenuItem();
            this.Customer = new System.Windows.Forms.ToolStripMenuItem();
            this.Seller = new System.Windows.Forms.ToolStripMenuItem();
            this.Check = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(468, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Product,
            this.Customer,
            this.Seller,
            this.Check});
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.entitiesToolStripMenuItem.Text = "Entities";
            // 
            // Product
            // 
            this.Product.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProductAdd});
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(180, 22);
            this.Product.Text = "Product";
            this.Product.Click += new System.EventHandler(this.Product_Click);
            // 
            // Customer
            // 
            this.Customer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustomerAdd});
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(180, 22);
            this.Customer.Text = "Customer";
            this.Customer.Click += new System.EventHandler(this.Customer_Click);
            // 
            // Seller
            // 
            this.Seller.Name = "Seller";
            this.Seller.Size = new System.Drawing.Size(180, 22);
            this.Seller.Text = "Seller";
            this.Seller.Click += new System.EventHandler(this.Seller_Click);
            // 
            // Check
            // 
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(180, 22);
            this.Check.Text = "Check";
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // ProductAdd
            // 
            this.ProductAdd.Name = "ProductAdd";
            this.ProductAdd.Size = new System.Drawing.Size(180, 22);
            this.ProductAdd.Text = "Add";
            // 
            // CustomerAdd
            // 
            this.CustomerAdd.Name = "CustomerAdd";
            this.CustomerAdd.Size = new System.Drawing.Size(180, 22);
            this.CustomerAdd.Text = "Add";
            this.CustomerAdd.Click += new System.EventHandler(this.CustomerAdd_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 403);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Product;
        private System.Windows.Forms.ToolStripMenuItem Customer;
        private System.Windows.Forms.ToolStripMenuItem Seller;
        private System.Windows.Forms.ToolStripMenuItem Check;
        private System.Windows.Forms.ToolStripMenuItem ProductAdd;
        private System.Windows.Forms.ToolStripMenuItem CustomerAdd;
    }
}