using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace midproject4
{
    public partial class AssessmentComponent : Form
    {
        private AssessmentComponentView assessmentComponentView;
        public AssessmentComponent()
        {
            InitializeComponent();
            assessmentComponentView = new AssessmentComponentView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var con = Configuration.getInstance().getConnection();


            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[AssessmentComponent] ([Name], [RubricId], [TotalMarks],[DateCreated],[DateUpdated],[AssessmentId]) VALUES (@Name, @RubricId, @TotalMarks,@DateCreated,@DateUpdated,@AssessmentId)", con);



            cmd.Parameters.AddWithValue("@Name", textBox1.Text);

            if (int.TryParse(textBox2.Text, out int RubricId))
            {
                cmd.Parameters.AddWithValue("@RubricId", RubricId);
            }
            else
            {

                MessageBox.Show("Invalid ID format in RubricId. Please enter a valid integer.");
                return;
            }


            if (int.TryParse(textBox3.Text, out int totalMarks))
            {
                cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);
            }
            else
            {

                MessageBox.Show("Invalid format in TotalMarks. Please enter a valid integer.");
                return;
            }


            DateTime dateCreated;
            string[] dateFormats = { "MM/dd/yyyy", "M-d-yyyy", "M/dd/yyyy", "MM/d/yyyy", "M/d/yyyy", "dd-MM-yyyy" };

            if (DateTime.TryParseExact(textBox4.Text, dateFormats, null, System.Globalization.DateTimeStyles.None, out dateCreated))
            {
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
            }
            else
            {
                MessageBox.Show("Invalid date format in DateCreated");
                return;
            }



            DateTime dateUpdated;
            string[] dateFormatsUpdated = { "MM/dd/yyyy", "M-d-yyyy", "M/dd/yyyy", "MM/d/yyyy", "M/d/yyyy", "dd-MM-yyyy" };

            if (DateTime.TryParseExact(textBox5.Text, dateFormatsUpdated, null, System.Globalization.DateTimeStyles.None, out dateUpdated))
            {
                cmd.Parameters.AddWithValue("@DateUpdated", dateUpdated);
            }
            else
            {
                MessageBox.Show("Invalid date format in DateUpdated");
                return;
            }




            if (int.TryParse(textBox8.Text, out int AssessmentId))
            {
                cmd.Parameters.AddWithValue("@AssessmentId", AssessmentId);
            }
            else
            {

                MessageBox.Show("Invalid ID format in AssessmentId. Please enter a valid integer.");
                return;
            }

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Successfully Inserted an AssessmentComponent");
                assessmentComponentView.LoadAssessmentComponentData();
            }
            else
            {
                MessageBox.Show("Insertion failed.");
            }
            assessmentComponentView.LoadAssessmentComponentData();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE  [dbo].[AssessmentComponent]  SET  Name = @Name, RubricId = @RubricId,  TotalMarks= @TotalMarks,DateCreated = @DateCreated, DateUpdated = @DateUpdated,AssessmentId= @AssessmentId WHERE Id = @Id", con);

            if (!int.TryParse(textBox7.Text, out int assessmentId))
            {
                MessageBox.Show("Invalid Assessment ID. Please enter a valid integer.");
                return;
            }

            cmd.Parameters.AddWithValue("@Id", assessmentId);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);

            if (int.TryParse(textBox2.Text, out int RubricId))
            {
                cmd.Parameters.AddWithValue("@RubricId", RubricId);
            }
            else
            {

                MessageBox.Show("Invalid ID format in RubricId. Please enter a valid integer.");
                return;
            }


            if (int.TryParse(textBox3.Text, out int totalMarks))
            {
                cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);
            }
            else
            {

                MessageBox.Show("Invalid format in TotalMarks. Please enter a valid integer.");
                return;
            }


            DateTime dateCreated;
            string[] dateFormats = { "MM/dd/yyyy", "M-d-yyyy", "M/dd/yyyy", "MM/d/yyyy", "M/d/yyyy", "dd-MM-yyyy" };

            if (DateTime.TryParseExact(textBox4.Text, dateFormats, null, System.Globalization.DateTimeStyles.None, out dateCreated))
            {
                cmd.Parameters.AddWithValue("@DateCreated", dateCreated);
            }
            else
            {
                MessageBox.Show("Invalid date format in DateCreated");
                return;
            }



            DateTime dateUpdated;
            string[] dateFormatsUpdated = { "MM/dd/yyyy", "M-d-yyyy", "M/dd/yyyy", "MM/d/yyyy", "M/d/yyyy", "dd-MM-yyyy" };

            if (DateTime.TryParseExact(textBox5.Text, dateFormatsUpdated, null, System.Globalization.DateTimeStyles.None, out dateUpdated))
            {
                cmd.Parameters.AddWithValue("@DateUpdated", dateUpdated);
            }
            else
            {
                MessageBox.Show("Invalid date format in DateUpdated");
                return;
            }




            if (int.TryParse(textBox8.Text, out int AssessmentId))
            {
                cmd.Parameters.AddWithValue("@AssessmentId", AssessmentId);
            }
            else
            {

                MessageBox.Show("Invalid ID format in AssessmentComponentId. Please enter a valid integer.");
                return;
            }

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Successfully Updated an AssessmentComponent");
                assessmentComponentView.LoadAssessmentComponentData();
            }
            else
            {
                MessageBox.Show("Updation failed.");
            }
            assessmentComponentView.LoadAssessmentComponentData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            assessmentComponentView.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[AssessmentComponent] WHERE Id = @Id", con);
            if (!int.TryParse(textBox7.Text, out int assessmentId))
            {
                MessageBox.Show("Invalid Assessment Component ID. Please enter a valid integer.");
                return;
            }

            cmd.Parameters.AddWithValue("@Id", assessmentId);



            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Successfully Deleted an AssessmentComponent");
                assessmentComponentView.LoadAssessmentComponentData();
            }
            else
            {
                MessageBox.Show("AssessmentComponent not found or deletion failed.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Please enter a valid Assessment Component Id for search.");
                return;
            }

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[AssessmentComponent] WHERE Id = @Id ", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox7.Text));


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    textBox1.Text = reader["Name"].ToString();
                    textBox2.Text = reader["RubricId"].ToString();
                    textBox3.Text = reader["TotalMarks"].ToString();
                    textBox4.Text = reader["DateCreated"].ToString();
                    textBox5.Text = reader["DateUpdated"].ToString();
                    textBox8.Text = reader["AssessmentId"].ToString();
                    



                    MessageBox.Show("AssessmentComponent found.");
                }
                else
                {
                    MessageBox.Show("AssessmentComponent not found.");
                }
            }


        }
    }
}
