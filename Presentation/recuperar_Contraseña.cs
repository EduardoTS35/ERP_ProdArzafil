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

namespace Presentation
{
    public partial class recuperar_Contraseña : Form
    {
        UserModel userModel = new UserModel();
        public recuperar_Contraseña()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            userModel.Consultar_Contra(tboxUsuario.Text);
            dataGridView1.DataSource = userModel.Consultar_Contra(tboxUsuario.Text);
        }

        private void tboxUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                userModel.Consultar_Contra(tboxUsuario.Text);
                dataGridView1.DataSource = userModel.Consultar_Contra(tboxUsuario.Text);
            }
            catch
            {

            }
        }
    }
}
