using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmPrestamos : Form
    {
        PrestamoController PrestamoController = new PrestamoController();
        ClienteController ClienteController = new ClienteController();
        Prestamo Prestamo;
        public FrmPrestamos()
        {
            InitializeComponent();
        }
        private void FrmPrestamos_Load(object sender, EventArgs e)
        {
            actualizarTablaPrestamos();
            inicializar(new Prestamo());
        }

        private void inicializar(Prestamo Prestamo)
        {
            labelId.Visible = false;
            txtid.Visible = false;
            txtfecha.Focus();
            txtid.Text = Prestamo.Id + "";
            txtmontoprestado.Text = Prestamo.Monto_prestamo + "";
            txtfecha.Value = DateTime.Now;
            txtcuotas.Text = Prestamo.Cuotas + "";
            jcbCliente.DataSource = ClienteController.GetListClientes("");
            if (Prestamo.Cliente != null)
            {
                jcbCliente.SelectedItem = Prestamo.Cliente;
                txtfecha.Value = Prestamo.Fecha;
                labelId.Visible = true;
                txtid.Visible = true;
            }
            this.Prestamo = Prestamo;
        }

        private void actualizarTablaPrestamos()
        {
            tablaPrestamos.DataSource = PrestamoController.Index(txtfilter.Text);
            tablaPrestamos.ClearSelection();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfecha.Value != null)
                {
                    if (Convert.ToInt32(txtmontoprestado.Text) > 0)
                    {
                        if (Convert.ToInt32(txtcuotas.Text) > 0)
                        {
                            if (jcbCliente.SelectedIndex >= 0)
                            {
                                Prestamo.Fecha = txtfecha.Value.Date;
                                Prestamo.Monto_prestamo = Convert.ToInt32(txtmontoprestado.Text);
                                Prestamo.Cuotas = Convert.ToInt32(txtcuotas.Text);
                                Prestamo.Cliente = (Cliente) jcbCliente.SelectedItem;
                                if (Prestamo.Id > 0)
                                {
                                    if (PrestamoController.Edit(Prestamo))
                                    {
                                        MessageBox.Show("Éxito!!! Se actualizó el Prestamo", "Mensaje");
                                        inicializar(new Prestamo());
                                        actualizarTablaPrestamos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error!!! No se actualizó el Prestamo", "Mensaje");
                                    }
                                }
                                else
                                {
                                    if (PrestamoController.Create(Prestamo))
                                    {
                                        MessageBox.Show("Éxito!!! Se agregó el Prestamo", "Mensaje");
                                        inicializar(new Prestamo());
                                        actualizarTablaPrestamos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error!!! No se agregó el Prestamo", "Mensaje");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Selecciona un Cliente", "Mensaje");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Las Cuotas son obligatorias", "Mensaje");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Monto Prestado es obligatorio", "Mensaje");
                    }
                }
                else
                {
                    MessageBox.Show("La Fecha es obligatoria", "Mensaje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Advertencia");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaPrestamos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(tablaPrestamos.CurrentRow.Cells[0].Value.ToString());
                inicializar(PrestamoController.Search(id));
            }
            else
            {
                MessageBox.Show("Seleccionar un Prestamo de la tabla a Editar", "Mensaje");
            }
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            actualizarTablaPrestamos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            inicializar(new Prestamo());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaPrestamos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(tablaPrestamos.CurrentRow.Cells[0].Value.ToString());
                if (PrestamoController.Delete(id))
                {
                    MessageBox.Show("Éxito!!! Se eliminó el Prestamo", "Mensaje");
                    actualizarTablaPrestamos();
                }
                else
                {
                    MessageBox.Show("Error!!! No se eliminó el Prestamo", "Mensaje");
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un Prestamo de la tabla a Eliminar", "Mensaje");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            actualizarTablaPrestamos();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReportPrestamos frmReporte = new ReportPrestamos();
            frmReporte.filter = txtfilter.Text;
            frmReporte.Visible = true;
        }
    }
}
