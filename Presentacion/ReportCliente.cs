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
    public partial class ReportCliente : Form
    {
        public ReportCliente()
        {
            InitializeComponent();
        }
        public string filter { get; set; }
        private void ReportCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.sp_filtrarClientes' Puede moverla o quitarla según sea necesario.
            this.sp_filtrarClientesTableAdapter.Fill(this.DataSetPrincipal.sp_filtrarClientes,filter);

            this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }
    }
}
