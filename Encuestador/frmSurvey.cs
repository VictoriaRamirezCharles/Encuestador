using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestador
{
    public partial class frmSurvey : Form
    {
        public string username;
        private SqlConnection _connection;
        private int _id;
        private string _quantity;
        private string _name;
        private readonly IService<Survey> _service;
        public frmSurvey()
        {
            InitializeComponent();
            _id = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _service = new SurveyService(_connection);
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmSurvey_Load(object sender, EventArgs e)
        {
            lblUserName.Text = username;
            LoadData();


        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            lblAddSuervey.Visible = true;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            lblAddSuervey.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCreateSurvey createSurvey = new frmCreateSurvey();
            createSurvey.username = username;
            this.Hide();
            createSurvey.Show();
        }
        private void LoadData()
        {
            dgvSurveys.DataSource = _service.GetAll(username);
            dgvSurveys.ClearSelection();

        }

        private void Delete()
        {
            if (_id <=0)
            {
                MessageBox.Show("Debe Seleccionar a una encuesta", "Notificacion");
            }
            else
            {
                var result = MessageBox.Show("¿Seguro que desea eliminar a este Encuesta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _service.Delete(_id);
                    LoadData();
                    _id = 0;


                }
            }
        }

        //private void dgvSurveys_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    dgvSurveys.ClearSelection();
        //    _id = 0;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void dgvSurveys_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                _id = Convert.ToInt32(dgvSurveys.Rows[index].Cells[0].Value.ToString());
                _name=dgvSurveys.Rows[index].Cells[1].Value.ToString();
                _quantity= dgvSurveys.Rows[index].Cells[2].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_id <= 0)
            {
                MessageBox.Show("Debe Seleccionar la encuesta a editar", "Notificacion");
            }
            else
            {

                frmQuestions frmQuestions = new frmQuestions();
                frmQuestions.SurveyId = _id;
                frmQuestions.Quantity = Convert.ToInt32(_quantity);
                frmQuestions.userName = username;
                this.Hide();
                frmQuestions.Show();
         
            }
        }

        private void cerrarSesionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Hide();
            login.Show();
        }

        private void aplicarEncuestasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_id <= 0)
            {
                MessageBox.Show("Debe Seleccionar la encuesta que desea aplicar", "Notificacion");
            }
            else
            {
                var entry = Interaction.InputBox("Nombre del Encuestado", "Encuestado", "");
                if (String.IsNullOrEmpty(entry))
                {
                    MessageBox.Show("Debe escribir un nombre para continuar");
                }
                else
                {
                    frmSurveyed surveyed = new frmSurveyed();
                    surveyed.surveyed = entry;
                    surveyed.surveyId = _id;
                    surveyed.username = username;
                    this.Hide();
                    surveyed.Show();
                }
               
            }
        }
    }
}
