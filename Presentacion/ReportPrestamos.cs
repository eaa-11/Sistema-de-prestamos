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
    public partial class ReportPrestamos : Form
    {
        public ReportPrestamos()
        {
            InitializeComponent();
        }
        public string filter { get; set; }
        private void ReportPrestamos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.sp_filtrarPrestamos' Puede moverla o quitarla según sea necesario.
            this.sp_filtrarPrestamosTableAdapter.Fill(this.DataSetPrincipal.sp_filtrarPrestamos, filter);

            this.reportViewer1.RefreshReport();
        }
    }
}
