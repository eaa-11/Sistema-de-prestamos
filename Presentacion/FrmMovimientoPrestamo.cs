using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class FrmMovimientoPrestamo : Form
    {
        MovimientoPrestamoController MovimientoPrestamoController = new MovimientoPrestamoController();
        public FrmMovimientoPrestamo()
        {
            InitializeComponent();
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            tablaMovimientos.DataSource = MovimientoPrestamoController.Index(txtfilter.Text);
        }

        private void FrmMovimientoPrestamo_Load(object sender, EventArgs e)
        {
            tablaMovimientos.DataSource = MovimientoPrestamoController.Index(txtfilter.Text);
            tablaMovimientos.ClearSelection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
