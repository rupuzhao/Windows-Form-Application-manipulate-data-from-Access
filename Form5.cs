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
    public partial class Form5 : Form
    {
        int countCandidate = 0;
        List<Candidate> candidateList = new List<Candidate>();

        public Form5()
        {
            InitializeComponent();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            lst1.Items.Clear();
            countCandidate = 0;

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BusDriver.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string query = "SELECT DriverID,Name,Age FROM Candidate WHERE Age <= @MaxAge";

            OleDbCommand command = new OleDbCommand(query, connection);

            command.Parameters.AddWithValue("@MaxAge", Convert.ToInt32(tbAge.Text));

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            string detail;

            while (reader.Read())
            {
                countCandidate++;
                detail = "";
                detail += reader[0].ToString() + "\t";
                detail += reader[1].ToString() + "\t";
                detail += "age: " + reader[2].ToString();
                lst1.Items.Add(detail);
                candidateList.Add(new Candidate(reader[0].ToString(), reader[1].ToString(), reader[2].ToString()));
            }

            reader.Close();
            connection.Close();

            bt1.Enabled = false;
            bt2.Enabled = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            bt2.Enabled = false;
            bt3.Enabled = false;
        }

        private void lst1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bt2_Click(object sender, EventArgs e)
        {
            foreach (var c in candidateList)
            {
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BusDriver.accdb";
                OleDbConnection connection = new OleDbConnection(connectionString);

                string query = "INSERT INTO Driver(DriverID,Name,Age) VALUES(@id,@name,@age);";

                OleDbCommand command = new OleDbCommand(query, connection);

                command.Parameters.AddWithValue("@id", c.DriverID);
                command.Parameters.AddWithValue("@name", c.Name);
                command.Parameters.AddWithValue("@age", c.Age);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                connection.Close();
            }

            string connectionString2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BusDriver.accdb";
            OleDbConnection connection2 = new OleDbConnection(connectionString2);

            string query2 = "SELECT DriverID,Name,Age,BusNo FROM Driver";

            OleDbCommand command2 = new OleDbCommand(query2, connection2);

            connection2.Open();
            OleDbDataReader reader2 = command2.ExecuteReader();

            string detail;

            while (reader2.Read())
            {
                detail = "";
                detail += reader2[0].ToString() + "\t";
                detail += reader2[1].ToString() + "\tage:";
                detail += reader2[2].ToString() + "\tbus:";
                detail += reader2[3].ToString();
                lst2.Items.Add(detail);
            }

            reader2.Close();
            connection2.Close();

            bt2.Enabled = false;
            bt3.Enabled = true;
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            string busNo = "";
            foreach (var c in candidateList)
            {
                int age = Convert.ToInt32(c.Age);
                if (age <= 40) { busNo = "A01"; }
                else { busNo = "C55"; }

                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|BusDriver.accdb";
                OleDbConnection connection = new OleDbConnection(connectionString);

                string query1 = "UPDATE Driver SET BusNo=@bus WHERE DriverID=@CandidateID;";
                string query2 = "SELECT DriverID,Name,Age,BusNo FROM Driver WHERE DriverID=@CandidateID;";

                OleDbCommand command1 = new OleDbCommand(query1, connection);
                OleDbCommand command2 = new OleDbCommand(query2, connection);

                command1.Parameters.AddWithValue("@bus", busNo);
                command1.Parameters.AddWithValue("@CandidateID", c.DriverID);
                command2.Parameters.AddWithValue("@CandidateID", c.DriverID);

                connection.Open();
                OleDbDataReader reader = command1.ExecuteReader();
                OleDbDataReader reader2 = command2.ExecuteReader();

                string detail;
                while (reader2.Read())
                {
                    detail = "";
                    detail += reader2[0].ToString() + "\t";
                    detail += reader2[1].ToString() + "\tage:";
                    detail += reader2[2].ToString() + "\tbus:";
                    detail += reader2[3].ToString();
                    lst3.Items.Add(detail);
                }
                connection.Close();
            }

            bt1.Enabled = false;
            bt2.Enabled = false;
            bt3.Enabled = false;
        }
    }
}
