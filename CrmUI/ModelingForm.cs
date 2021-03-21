using BL.Models;
using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class ModelingForm : Form
    {
        ShopComputerModel model = new ShopComputerModel();
        public ModelingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cashDesks = new List<CashDeskView>();
            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var desk = new CashDeskView(model.CashDesks[i], i, 10, 26 * i);
                cashDesks.Add(desk);
                Controls.Add(desk.CashDeskName);
                Controls.Add(desk.Price);
                Controls.Add(desk.QueueLenght);
                Controls.Add(desk.LeaveCustomersCount);
            }
            model.Start();
        }

        private void ModelingForm_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = model.CustomerSpeed;
            numericUpDown2.Value = model.CashDeskSpeed;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeed = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = (int)numericUpDown2.Value;
        }

        private void ModelingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            model.Stop();
        }

        private void ModelingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }
    }
}
