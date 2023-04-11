using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commun.Cache;

namespace Presentation
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            string IdS = UserLoginCache.Id.ToString();
            lblUsuarios.Text = IdS;
            lblAreaPnl.Text = UserLoginCache.Area;
            lblTurno.Text = UserLoginCache.Position;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFecha.Text = DateTime.Now.ToString("dddd dd MMMM yyyy");
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}
