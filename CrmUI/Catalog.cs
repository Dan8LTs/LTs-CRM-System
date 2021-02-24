using System;
using System.Data.Entity;
using System.Windows.Forms;
using CrmBL.Models;
using BL.Models;

namespace CrmUI
{
    public partial class Catalog<T> : Form
        where T : class
    {
        CrmContext LTsCrmDB;
        DbSet<T> set;
        public Catalog(DbSet<T> set, CrmContext LTsCrmDB)
        {
            InitializeComponent();
            this.LTsCrmDB = LTsCrmDB;
            this.set = set;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                var productForm = new ProductForm();
                if (productForm.ShowDialog() == DialogResult.OK)
                {
                    LTsCrmDB.Products.Add(productForm.Product);
                    LTsCrmDB.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customerForm = new CustomerForm();
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    LTsCrmDB.Customers.Add(customerForm.Customer);
                    LTsCrmDB.SaveChanges();
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var sellerForm = new SellerForm();
                if (sellerForm.ShowDialog() == DialogResult.OK)
                {
                    LTsCrmDB.Sellers.Add(sellerForm.Seller);
                    LTsCrmDB.SaveChanges();
                }
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;
            if(typeof(T) == typeof(Product))
            {
                Product product = set.Find(id) as Product;
                if(product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        LTsCrmDB.SaveChanges();
                        dataGridView1.Refresh();
                    }
                }
            }
            else if(typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        LTsCrmDB.SaveChanges();
                        dataGridView1.Refresh();
                    }
                }
            }
            else if(typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {
                    var form = new SellerForm(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        LTsCrmDB.SaveChanges();
                        dataGridView1.Refresh();
                    }
                }
            }
        }
    }
}
