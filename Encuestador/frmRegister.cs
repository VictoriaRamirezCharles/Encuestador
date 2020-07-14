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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestador
{
    public partial class frmRegister : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private readonly IService<User> _service;
 
        public frmRegister()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            SqlConnection _connection = new SqlConnection(connectionString);

            _service = new UserService(_connection);
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                this.Hide();
                login.Show();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Add();
        }

        public void Add()
        {
            User user = new User(txtName.Text, txtLastName.Text, txtUserName.Text, txtPassword.Text);
            if (txtPassword.Text.Equals(txtRePassword.Text))
            {
                var exist = _service.Get(txtUserName.Text);
                if (!exist)
                {
                    _service.Add(user);
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.userName = txtUserName.Text;
                    frmLogin.password = txtPassword.Text;
                    this.Hide();
                    frmLogin.Show();
                }
                else
                {
                    MessageBox.Show("Este usuario ya existe, intente con uno diferente");
                }

            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden, intente de nuevo");
            }
                
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
