using CrmBL.Models;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }
        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            richTextBox1.Text = Customer.Name;
            numericUpDown1.Value = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var customer = Customer ?? new Customer();
            customer.Name = richTextBox1.Text;
            customer.Age = Convert.ToInt32(numericUpDown1.Value);
            Close();
        }
    }
}
