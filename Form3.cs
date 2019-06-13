using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_9_BusDriverDB
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void busBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.busBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.busDriverDataSet);

        }

        private void busBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.busBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.busDriverDataSet);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'busDriverDataSet.BusModel' table. You can move, or remove it, as needed.
            this.busModelTableAdapter.Fill(this.busDriverDataSet.BusModel);
            // TODO: This line of code loads data into the 'busDriverDataSet.Bus' table. You can move, or remove it, as needed.
            this.busTableAdapter.Fill(this.busDriverDataSet.Bus);

        }

        private void btBus_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BusDriver.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string query = "SELECT COUNT(*), MAX(Mileage), MIN(Mileage) FROM Bus";

            OleDbCommand command = new OleDbCommand(query, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                lbTotalBus.Text = reader[0].ToString();
                lbHighMile.Text = reader[1].ToString();
                lbLowMile.Text = reader[2].ToString();
            }

            reader.Close();
            connection.Close();
        }

        private void btDriver_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BusDriver.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string query1 = "SELECT COUNT(*), AVG(Age)" + "FROM Driver";
            string query2 = "SELECT COUNT(*)" + "FROM Driver WHERE BusNo is null";

            OleDbCommand command1 = new OleDbCommand(query1, connection);
            OleDbCommand command2 = new OleDbCommand(query2, connection);

            connection.Open();
            OleDbDataReader reader1 = command1.ExecuteReader();
            OleDbDataReader reader2 = command2.ExecuteReader();

            while (reader1.Read())
            {
                lbTotalDriver.Text = reader1[0].ToString();
                lbAvgAge.Text = reader1[1].ToString();
            }
            while (reader2.Read())
            {
                lbNoBus.Text = reader2[0].ToString();
            }

            reader1.Close();
            reader2.Close();
            connection.Close();
        }
    }
}
