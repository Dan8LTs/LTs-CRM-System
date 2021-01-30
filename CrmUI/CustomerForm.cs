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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer
            {
                Name = richTextBox1.Text,
                Age = Convert.ToInt32(richTextBox2.Text)
            };
            Close();
        }
    }
}
