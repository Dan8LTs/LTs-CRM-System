using BL.Models;
using CrmBL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext LTsCrmDB;
        Cart cart;
        Customer customer;
        CashDesk cashDesk;
        
        public Main()
        {
            InitializeComponent();
            LTsCrmDB = new CrmContext();

            cart = new Cart(customer);
            cashDesk = new CashDesk(1, LTsCrmDB.Sellers.FirstOrDefault(), LTsCrmDB)
            {
                IsModel = false
            };        
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
            if (customerForm.ShowDialog() == DialogResult.OK)
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

        private void mOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelingForm();
            form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                listBox1.Invoke((Action)delegate
                {
                    listBox1.Items.AddRange(LTsCrmDB.Products.ToArray());
                    UpdateLists();
                });
            });
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem is Product product)
            {
                cart.Add(product);
                listBox2.Items.Add(product);
                UpdateLists();
            }
        }

        private void UpdateLists()
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(cart.GetAll().ToArray());
            label1.Text = "Total: " + cart.Price;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = new Login();
            loginForm.ShowDialog();
            if(loginForm.DialogResult == DialogResult.OK)
            {
                var tempCustomer = LTsCrmDB.Customers.FirstOrDefault(c => c.Name.Equals(loginForm.Customer.Name));
                if (tempCustomer != null)
                {
                    customer = tempCustomer;
                }
                else
                {
                    LTsCrmDB.Customers.Add(loginForm.Customer);
                    LTsCrmDB.SaveChanges();
                    customer = loginForm.Customer;
                }
                cart.Customer = customer;
            }
            if(customer != null)
            {
                linkLabel1.Text = $"Hello, {customer.Name}!";
            }
            else
            {
                linkLabel1.Text = $"Hello, guest!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(customer != null)
            {
                cashDesk.Enqueue(cart);
                var price = cashDesk.Dequeue();
                listBox2.Items.Clear();
                label1.Text = "Total: 0";
                cart = new Cart(customer);

                MessageBox.Show("Purchase completed successfully. Total: " + price, "Purchase completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("   Please, log in!   ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
