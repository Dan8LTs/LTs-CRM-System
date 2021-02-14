using CrmBL.Models;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }

        public SellerForm(Seller seller) : this()
        {
            Seller = seller;
            richTextBox1.Text = Seller.Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var seller = Seller ?? new Seller();
            seller.Name = richTextBox1.Text;
            Close();
        }
    }
}
