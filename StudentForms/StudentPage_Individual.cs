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

namespace StudentRecords
{
    public partial class StudentPage_Individual : Form
    {
        private int studentId;
        Database_Connection db = new Database_Connection();

        public StudentPage_Individual(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            CreateFormControls();
            LoadStudentDetails(studentId);
        }

        private void CreateFormControls()
        {
            // Labels and Textboxes for each field
            string[] labels = { "Student ID", "Full Name", "Address", "Birthdate", "Age", "Contact No.", "Email", "Guardian", "Hobbies", "Nickname" };
            string[] textBoxNames = { "txtStudentId", "txtFullName", "txtAddress", "txtBirthdate", "txtAge", "txtContactNo", "txtEmail", "txtGuardian", "txtHobbies", "txtNickname" };

            // Positioning for controls
            int yPos = 10;
            int labelWidth = 100;
            int textBoxWidth = 250;

            for (int i = 0; i < labels.Length; i++)
            {
                // Create Label
                Label lbl = new Label();
                lbl.Text = labels[i];
                lbl.Location = new System.Drawing.Point(10, yPos);
                lbl.Width = labelWidth;
                this.Controls.Add(lbl);

                // Create TextBox
                TextBox txt = new TextBox();
                txt.Name = textBoxNames[i];
                txt.ReadOnly = true; // Set TextBox as ReadOnly
                txt.Location = new System.Drawing.Point(120, yPos);
                txt.Width = textBoxWidth;
                this.Controls.Add(txt);

                // Increase y position for next control
                yPos += 40;
            }
        }

        private void LoadStudentDetails(int studentId)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM StudentRecordTB WHERE studentId = @studentId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentId", studentId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Set values in the Textboxes
                    this.Controls["txtStudentId"].Text = reader["studentId"].ToString();
                    this.Controls["txtFullName"].Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                    this.Controls["txtAddress"].Text = reader["houseNo"].ToString() + " " + reader["brgyName"].ToString() + ", " + reader["municipality"].ToString() + ", " + reader["province"].ToString();
                    this.Controls["txtBirthdate"].Text = reader["birthdate"].ToString();
                    this.Controls["txtAge"].Text = reader["age"].ToString();
                    this.Controls["txtContactNo"].Text = reader["studContactNo"].ToString();
                    this.Controls["txtEmail"].Text = reader["emailAddress"].ToString();
                    this.Controls["txtGuardian"].Text = reader["guardianFirstName"].ToString() + " " + reader["guardianLastName"].ToString();
                    this.Controls["txtHobbies"].Text = reader["hobbies"].ToString();
                    this.Controls["txtNickname"].Text = reader["nickname"].ToString();
                }
                reader.Close();
            }
        }
    }
}