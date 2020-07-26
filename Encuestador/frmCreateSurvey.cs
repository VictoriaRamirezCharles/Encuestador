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
        public string quantityToUpdate;
        public string nameToUpdate;
        public int _id;

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
            txtName.Text = nameToUpdate;
            txtQuantity.Text = quantityToUpdate;
        }

        private void Add()
        {
            try
            {
                Survey survey = new Survey(txtName.Text, Convert.ToInt32(txtQuantity.Text), username);
                var exist = _service.Get(txtName.Text.ToUpper(), username);
                if (!exist)
                {
                    _service.Add(survey);
                    frmQuestions frmQuestions = new frmQuestions();
                    frmQuestions.SurveyId = _service.GetId(survey);
                    frmQuestions.Quantity = Convert.ToInt32(txtQuantity.Text);
                    frmQuestions.userName = username;
                    this.Hide();
                    frmQuestions.Show();
                }
                else
                {
                    MessageBox.Show("Ya tiene una encuesta con ese nombre, escriba uno diferente");
                }
            }catch(Exception e)
            {
                MessageBox.Show("Ha ocurrido un error, verifique los valores introducidos sean correctos");
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                Add();
            }
            else
            {
                Update();
            }
        }

        public void Update()
        {

            Survey survey = new Survey(txtName.Text, Convert.ToInt32(txtQuantity.Text), username);
            survey.Id = _id;
            _service.Update(survey);
            _id = 0;
            frmSurvey frmSurvey = new frmSurvey();
            frmSurvey.username = username;
            this.Hide();
            frmSurvey.Show();
        }

        private void volverAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSurvey survey = new frmSurvey();
            survey.username = username;
            this.Hide();
            survey.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
