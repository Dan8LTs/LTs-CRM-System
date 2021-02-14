using BL.Models;
using CrmBL.Models;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext LTsCrmDB;
        public Main()
        {
            InitializeComponent();
            LTsCrmDB = new CrmContext();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(LTsCrmDB.Products, LTsCrmDB);
            catalogProduct.Show();
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(LTsCrmDB.Customers, LTsCrmDB);
            catalogCustomer.Show();
        }

        private void Seller_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(LTsCrmDB.Sellers, LTsCrmDB);
            catalogSeller.Show();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(LTsCrmDB.Checks, LTsCrmDB);
            catalogCheck.Show();
        }

        private void CustomerAdd_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm();
            if(customerForm.ShowDialog() == DialogResult.OK)
            {
                LTsCrmDB.Customers.Add(customerForm.Customer);
                LTsCrmDB.SaveChanges();
            }
        }

        private void SellerAdd_Click(object sender, EventArgs e)
        {
            var sellerForm = new SellerForm();
            if (sellerForm.ShowDialog() == DialogResult.OK)
            {
                LTsCrmDB.Sellers.Add(sellerForm.Seller);
                LTsCrmDB.SaveChanges();
            }
        }

        private void ProductAdd_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                LTsCrmDB.Products.Add(productForm.Product);
                LTsCrmDB.SaveChanges();
            }
        }
    }
}
