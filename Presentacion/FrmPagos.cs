using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FrmPagos : Form
    {
        PagoController PagoController = new PagoController();
        PrestamoController PrestamoController = new PrestamoController();
        ClienteController ClienteController = new ClienteController();
        Pago Pago;
        public FrmPagos()
        {
            InitializeComponent();
        }
        private void FrmPagos_Load(object sender, EventArgs e)
        {
            actualizarTablaPagos();
            inicializar(new Pago());
        }

        private void inicializar(Pago Pago)
        {
            labelId.Visible = false;
            txtid.Visible = false;
            txtfecha.Focus();
            txtid.Text = Pago.Id + "";
            txtmontopagado.Text = Pago.Monto_pagado + "";
            txtfecha.Value = DateTime.Now;
            //jcbPrestamo.DataSource = PrestamoController.Index("");
            jcbCliente.DataSource = ClienteController.GetListClientes("");
            if (Pago.Cliente != null && Pago.Prestamo != null)
            {
                jcbCliente.SelectedItem = Pago.Cliente;
                jcbPrestamo.SelectedItem = Pago.Prestamo;
                txtfecha.Value = Pago.Fecha;
                labelId.Visible = true;
                txtid.Visible = true;
            }
            this.Pago = Pago;
            txtcuotas.Items.Clear();
        }

        private void actualizarTablaPagos()
        {
            tablaPagos.DataSource = PagoController.Index();
            tablaPagos.ClearSelection();
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
                    if (Convert.ToDecimal(txtmontopagado.Text) > 0)
                    {
                        if (jcbCliente.SelectedIndex >= 0)
                        {
                            if (jcbCliente.SelectedIndex >= 0)
                            {
                                Pago.Fecha = txtfecha.Value.Date;
                                Pago.Monto_pagado = Convert.ToDecimal(txtmontopagado.Text);
                                Pago.Prestamo = (Prestamo) jcbPrestamo.SelectedItem;
                                Pago.Cliente = (Cliente)jcbCliente.SelectedItem;
                                if (Pago.Id > 0)
                                {
                                    if (PagoController.Edit(Pago))
                                    {
                                        MessageBox.Show("Éxito!!! Se actualizó el Pago", "Mensaje");
                                        inicializar(new Pago());
                                        actualizarTablaPagos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error!!! No se actualizó el Pago", "Mensaje");
                                    }
                                }
                                else
                                {
                                    if (PagoController.Create(Pago))
                                    {
                                        MessageBox.Show("Éxito!!! Se agregó el Pago", "Mensaje");
                                        inicializar(new Pago());
                                        actualizarTablaPagos();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error!!! No se agregó el Pago", "Mensaje");
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
                            MessageBox.Show("Selecciona un Préstamo", "Mensaje");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Monto Pagadoo es obligatorio", "Mensaje");
                    }
                }
                else
                {
                    MessageBox.Show("La Fecha es obligatoria", "Mensaje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaPagos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(tablaPagos.CurrentRow.Cells[0].Value.ToString());
                inicializar(PagoController.Search(id));
            }
            else
            {
                MessageBox.Show("Seleccionar un Pago de la tabla a Editar", "Mensaje");
            }
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            actualizarTablaPagos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            inicializar(new Pago());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaPagos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(tablaPagos.CurrentRow.Cells[0].Value.ToString());
                if (PagoController.Delete(id))
                {
                    MessageBox.Show("Éxito!!! Se eliminó el Pago", "Mensaje");
                    actualizarTablaPagos();
                }
                else
                {
                    MessageBox.Show("Error!!! No se eliminó el Pago", "Mensaje");
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un Pago de la tabla a Eliminar", "Mensaje");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            actualizarTablaPagos();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (txtfechainicio.Value != null && txtfechafin.Value != null)
            {
                tablaPagos.DataSource = PagoController.FilterByDate(txtfechainicio.Value, txtfechafin.Value);
            }
        }

        private void txtfechafin_ValueChanged(object sender, EventArgs e)
        {
            if (txtfechainicio.Value != null && txtfechafin.Value != null)
            {
                tablaPagos.DataSource = PagoController.FilterByDate(txtfechainicio.Value.Date, txtfechafin.Value.Date);
            }
        }

        private void jcbPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(jcbPrestamo.SelectedIndex >= 0)
            {
                txtcuotas.Items.Clear();
                Prestamo prestamo = (Prestamo)jcbPrestamo.SelectedItem;
                for(int i = 0; i < prestamo.Cuotas; i++)
                {
                    txtcuotas.Items.Add(i + 1);
                }
            }
        }

        private void txtcuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (jcbPrestamo.SelectedIndex >= 0 && txtcuotas.SelectedIndex >= 0)
            {
                Prestamo prestamo = (Prestamo)jcbPrestamo.SelectedItem;
                decimal cuota = (prestamo.Monto_prestamo / prestamo.Cuotas) * Convert.ToInt32(txtcuotas.SelectedItem);
                txtmontopagado.Text = Math.Round(cuota) + "";
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReportPagos frmReporte = new ReportPagos();
            frmReporte.fecha_inicio = txtfechainicio.Value;
            frmReporte.fecha_fin = txtfechafin.Value;
            frmReporte.Visible = true;
        }

        private void jcbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dragcontrol = (ComboBox)sender;
            var cliente = (Cliente)dragcontrol.SelectedItem;
            jcbPrestamo.DataSource = PrestamoController.Index(cliente.Cedula);
        }
    }
}
