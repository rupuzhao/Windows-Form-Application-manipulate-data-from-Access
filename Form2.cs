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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void busBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.busBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.busDriverDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busDriverDataSet.BusModel' table. You can move, or remove it, as needed.
            this.busModelTableAdapter.Fill(this.busDriverDataSet.BusModel);
            // TODO: This line of code loads data into the 'busDriverDataSet.Bus' table. You can move, or remove it, as needed.
            this.busTableAdapter.Fill(this.busDriverDataSet.Bus);

        }
    }
}
