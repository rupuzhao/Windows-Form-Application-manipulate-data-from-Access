using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_9_BusDriverDB
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void busBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.busBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.busDriverDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busDriverDataSet.BusModel' table. You can move, or remove it, as needed.
            this.busModelTableAdapter.Fill(this.busDriverDataSet.BusModel);
            // TODO: This line of code loads data into the 'busDriverDataSet.Bus' table. You can move, or remove it, as needed.
            this.busTableAdapter.Fill(this.busDriverDataSet.Bus);

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            lstDetail.Items.Clear();

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BusDriver.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string query = "SELECT BusNo,Mileage,Model FROM Bus WHERE Model = @BusNo AND Mileage < @MileageBelow";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.Parameters.AddWithValue("@BusNo", modelComboBox.SelectedValue.ToString());
            command.Parameters.AddWithValue("@MileageBelow", tbMile.Text);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            string detail;

            while (reader.Read())
            {
                detail = "";
                detail += reader[0].ToString();
                detail += " - " + reader[1].ToString();
                detail += " - " + reader[2].ToString();
                lstDetail.Items.Add(detail);
            }

            reader.Close();
            connection.Close();

            //lstDetail.Items.Add(modelComboBox.SelectedValue.ToString());
        }

        private void modelLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
