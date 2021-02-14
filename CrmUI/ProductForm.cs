﻿using CrmBL.Models;
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            var product = Product ?? new Product();
            product.Name = richTextBox1.Text;
            product.Price = Convert.ToDecimal(numericUpDown1.Value);
            product.Count = Convert.ToUInt32(numericUpDown2.Value);
            Close();
        }
    }
}