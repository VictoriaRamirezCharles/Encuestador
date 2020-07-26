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
    public partial class frmQuestions : Form
    {
        private SqlConnection _connection;
        public int Quantity;
        public int SurveyId;
        private int _id;
        public string userName;
        private readonly IService<Question> _service;
        public frmQuestions()
        {
            InitializeComponent();
            _id = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _service = new QuestionService(_connection);
        }

        private void frmQuestions_Load(object sender, EventArgs e)
        {
            lblQuantity.Text = Quantity.ToString();
            lblSurveyId.Text = SurveyId.ToString();
            LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                Update();
            }
            else
            {

                if (!_service.Get(lblSurveyId.Text, lblQuantity.Text))
                {
                    Add();

                }
                else
                {
                    var limite = MessageBox.Show("Ha llegado al limite de preguntas en esta encuesta,¿Desea Volver al Menu Principal?", "Limite Preguntas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (limite == DialogResult.Yes)
                    {
                        frmSurvey survey = new frmSurvey();
                        survey.username = userName;
                        this.Hide();
                        survey.Show();
                    }
                }
                LoadData();
            }
        }

        private void Add()
        {
            Question question = new Question(txtQuestion.Text, SurveyId);
          
            _service.Add(question);
            clearData();
         
        }

        public void Update()
        {
            Question question = new Question(txtQuestion.Text, SurveyId);
            question.Id = _id;
            _service.Update(question);
            _id = 0;
            LoadData();
            clearData();
        }
        private void Delete()
        {
            if (_id <= 0)
            {
                MessageBox.Show("Debe Seleccionar a una pregunta", "Notificacion");
            }
            else
            {
                var result = MessageBox.Show("¿Seguro que desea eliminar a este pregunta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _service.Delete(_id);
                    LoadData();
                    _id = 0;
                    clearData();
                }
            }
        }
        private void clearData()
        {
            txtQuestion.Clear();
          
        }

        private void LoadData()
        {
            dgvQuestions.DataSource = _service.GetAll(lblSurveyId.Text);
            dgvQuestions.ClearSelection();

        }

        private void dgvQuestions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                _id = Convert.ToInt32(dgvQuestions.Rows[index].Cells[0].Value.ToString());
                txtQuestion.Text = dgvQuestions.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
