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
    public partial class ReportPagos : Form
    {
        public ReportPagos()
        {
            InitializeComponent();
        }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        private void ReportPagos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.sp_filtrarPagos' Puede moverla o quitarla según sea necesario.
            this.sp_filtrarPagosTableAdapter.Fill(this.DataSetPrincipal.sp_filtrarPagos, fecha_inicio, fecha_fin);

            this.reportViewer1.RefreshReport();
        }
    }
}
