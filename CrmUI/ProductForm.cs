using CrmBL.Models;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }
        public ProductForm(Product product) : this()
        {
            Product = product;
            richTextBox1.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Product = Product ?? new Product();
            Product.Name = richTextBox1.Text;
            Product.Price = Convert.ToDecimal(numericUpDown1.Value);
            Product.Count = Convert.ToInt32(numericUpDown2.Value);
            Close();
        }
    }
}
