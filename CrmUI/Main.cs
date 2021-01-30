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
            var catalogProduct = new Catalog<Product>(LTsCrmDB.Products);
            catalogProduct.Show();
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(LTsCrmDB.Customers);
            catalogCustomer.Show();
        }

        private void Seller_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(LTsCrmDB.Sellers);
            catalogSeller.Show();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(LTsCrmDB.Checks);
            catalogCheck.Show();
        }

        private void CustomerAdd_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                LTsCrmDB.Customers.Add(form.Customer);
                LTsCrmDB.SaveChanges();
            }
        }
    }
}
