using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace StudentRecords
{
    public partial class StudentPage : Form
    {
        Database_Connection db = new Database_Connection();

        public StudentPage()
        {
            InitializeComponent();
            LoadStudentRecords();
        }

        private void LoadStudentRecords()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT studentId, CONCAT(firstName, ' ', lastName) AS FullName FROM StudentRecordTB";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["studentId"].HeaderText = "Student ID";
                dataGridView1.Columns["FullName"].HeaderText = "Full Name";

                // Check if the "VIEW" button column already exists
                if (dataGridView1.Columns["Action"] == null)
                {
                    DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
                    viewButtonColumn.Name = "Action"; // Give it a name to reference later
                    viewButtonColumn.HeaderText = "Action";
                    viewButtonColumn.Text = "VIEW";
                    viewButtonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(viewButtonColumn);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Prevent clicking header errors

            // Ensure the clicked column is the "VIEW" button column
            if (e.ColumnIndex == dataGridView1.Columns["Action"]?.Index)
            {
                object studentIdValue = dataGridView1.Rows[e.RowIndex].Cells["studentId"].Value;

                if (studentIdValue != null && int.TryParse(studentIdValue.ToString(), out int studentId))
                {
                    StudentPage_Individual studentPageIndividual = new StudentPage_Individual(studentId);
                    studentPageIndividual.Show();
                }
                else
                {
                    MessageBox.Show("Invalid student ID.");
                }
            }
        }
    }
}