using BusinessLayer;
using DataAccessLayer;
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
    public partial class frmCreateSurvey : Form
    {
        public string username;

        private readonly IService<Survey> _service;
        public frmCreateSurvey()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(connectionString);

            _service = new SurveyService(_connection);
        }

        private void frmCreateSurvey_Load(object sender, EventArgs e)
        {
     
          this.Text = $"Crear Encuesta --- Usuario {username}";
        }

        private void Add()
        {
            Survey survey = new Survey(txtName.Text, Convert.ToInt32(txtQuantity.Text), username);
            _service.Add(survey);
            frmQuestions frmQuestions = new frmQuestions();
            frmQuestions.SurveyId = _service.GetId(survey);
            frmQuestions.Quantity = Convert.ToInt32(txtQuantity.Text);
            this.Hide();
            frmQuestions.Show();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Add();
        }
    }
}
