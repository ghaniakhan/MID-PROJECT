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
    public partial class AssessmentComponentView : Form
    {
        private readonly SqlConnection con;
        public AssessmentComponentView()
        {
            InitializeComponent();
        }

        private void AssessmentView_Load(object sender, EventArgs e)
        {
            LoadAssessmentComponentData();

        }


        public void LoadAssessmentComponentData()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[AssessmentComponent]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
