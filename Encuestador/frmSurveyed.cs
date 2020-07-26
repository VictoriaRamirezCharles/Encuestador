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
    public partial class frmSurveyed : Form
    {
        public string surveyed;
        public int surveyId;
        public string username;
        private readonly IService<Surveyed> _service;
        private SqlConnection _connection;
        private int _id;
        public frmSurveyed()
        {
            InitializeComponent();
            _id = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _service = new SurveyedService(_connection);
        }

        private void frmSurveyed_Load(object sender, EventArgs e)
        {
            lblName.Text = surveyed;
            LoadData();
        }
        private void LoadData()
        {
            dgvQuestions.DataSource = _service.GetAll(surveyId.ToString());
            dgvQuestions.ClearSelection();

        }
        public void Add()
        {
            Surveyed surveyeds = new Surveyed(surveyed, _id, username, txtAnswer.Text);
            if (String.IsNullOrEmpty(txtAnswer.Text))
            {
                MessageBox.Show("No puede enviar una respuesta vacia.");
            }
            else
            {
                _service.Add(surveyeds);
                MessageBox.Show("Pregunta Guardada Correctamente");
                LoadData();
                clearData();
            }
         
        }
        private void clearData()
        {
            txtAnswer.Clear();
        
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            frmSurvey survey = new frmSurvey();
            survey.username = username;
            this.Hide();
            survey.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Debe Seleccionar la pregunta a responder"); 
            }
            else
            {
                Add();
            }
            
        }

        private void dgvQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                _id = Convert.ToInt32(dgvQuestions.Rows[index].Cells[0].Value.ToString());
   
            }
        }
    }
}
