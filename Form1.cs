using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_9_BusDriverDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void busBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.busBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.busDriverDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busDriverDataSet.Driver' table. You can move, or remove it, as needed.
            this.driverTableAdapter.Fill(this.busDriverDataSet.Driver);
            // TODO: This line of code loads data into the 'busDriverDataSet.Bus' table. You can move, or remove it, as needed.
            //this.busTableAdapter.Fill(this.busDriverDataSet.Bus);

        }

        private void find_this_busToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.busTableAdapter.Find_this_bus(this.busDriverDataSet.Bus, busNoToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void mileageTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
