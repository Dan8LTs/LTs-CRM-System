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

        private void Button1_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new Customer();
            Customer.Name = richTextBox1.Text;
            Customer.Age = Convert.ToInt32(numericUpDown1.Value);
            Close();
        }
    }
}
