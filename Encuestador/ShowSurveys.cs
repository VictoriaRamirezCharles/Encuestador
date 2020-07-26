using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestador
{
    public partial class ShowSurveys : Form
    {
        private readonly IService<Surveyed> _service;
        private SqlConnection _connection;
        public int surveyId;
        public int _id;
        public string name;
        public ShowSurveys()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _service = new SurveyedService(_connection);
        }

        private void ShowSurveys_Load(object sender, EventArgs e)
        {
         
        }

        private void LoadData()
        {
            dgvPeople.DataSource = _service.GetAllNames(surveyId.ToString());
            dgvPeople.ClearSelection();

        }

        private void btnShowResults_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvPeople_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;

                Name = dgvPeople.Rows[index].Cells[0].Value.ToString();
                dgvAnswers.DataSource = _service.GetAllAnwers(Name);
                dgvAnswers.ClearSelection();
            }
        
        }

     

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

       
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Hide();
            login.Show();
        }
    }
}
