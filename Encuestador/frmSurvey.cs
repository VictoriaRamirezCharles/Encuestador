using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
   
        public frmSurvey()
        {
            InitializeComponent();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmSurvey_Load(object sender, EventArgs e)
        {
            lblUserName.Text = username;
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
    }
}
