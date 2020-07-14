using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encuestador
{
    public partial class frmQuestions : Form
    {
        public int Quantity;
        public int SurveyId;
        public frmQuestions()
        {
            InitializeComponent();
        }

        private void frmQuestions_Load(object sender, EventArgs e)
        {
            lblQuantity.Text = Quantity.ToString();
            var a = SurveyId;
        }
    }
}
