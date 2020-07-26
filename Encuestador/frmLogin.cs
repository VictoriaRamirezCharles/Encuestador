using BusinessLayer;
using DataAccessLayer;
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
    public partial class frmLogin : Form
    {
        public string userName;
        public string password;
        private readonly IService<User> _service;
        public frmLogin()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(connectionString);

            _service = new UserService(_connection);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = userName;
            txtPassword.Text = password;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            valid();
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister registration = new frmRegister();
            this.Hide();
            registration.Show();
        }

    
        void valid()
        {
            var exist = _service.Get(null, txtUserName.Text);
            var existPass = _service.validPassWord(txtUserName.Text, txtPassword.Text);

            if (exist)
            {
                if (existPass)
                {
                    frmSurvey survey = new frmSurvey();
                    survey.username = txtUserName.Text;
                    this.Hide();
                    survey.Show();

                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta");
                }
            }
            else
            {
                var result = MessageBox.Show("Este usuario no se encuentra en el sistema, ¿Desea Registrarse?", "Registrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    frmRegister registration = new frmRegister();
                    this.Hide();
                    registration.Show();
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                valid();
            }
        }
    }
}
