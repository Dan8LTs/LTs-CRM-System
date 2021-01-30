using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form
        where T : class
    {
        public Catalog(DbSet<T> LTsCrmDB)
        {
            InitializeComponent();
            dataGridView1.DataSource = LTsCrmDB.Local.ToBindingList();
        }
        private void Catalog_Load(object sender, EventArgs e)
        {

        }
    }
}
