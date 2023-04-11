using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using GemBox.Spreadsheet;

namespace Presentation
{
    public partial class frmStatusProceso : Form
    {
        UserModel userModel = new UserModel();
        public frmStatusProceso()
        {
            InitializeComponent();
        }

        private void frmStatusProceso_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = userModel.MostrarStatus();
        }
    }
}
