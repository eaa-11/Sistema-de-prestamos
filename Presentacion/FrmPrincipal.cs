using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new FrmClientes().Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new FrmPrestamos().Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new FrmPagos().Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new FrmMovimientoPrestamo().Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
