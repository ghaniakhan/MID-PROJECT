using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Windows.Forms;



namespace midproject2
{
    public partial class CloViewForm : Form
    {

        private readonly SqlConnection con;
        public CloViewForm()
        {
            InitializeComponent();
           // con = Configuration.getInstance().getConnection();
        }

        private void CloViewForm_Load(object sender, EventArgs e)
        {
            LoadCLOData();
        }

        public void LoadCLOData()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Clo]", con);
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
