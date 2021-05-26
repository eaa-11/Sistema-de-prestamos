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
    public partial class FrmClientes : Form
    {
        ClienteController clienteController = new ClienteController();
        Cliente cliente;
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            actualizarTablaClientes();
            inicializar(new Cliente());
        }

        private void inicializar(Cliente cliente)
        {
            txtcedula.Focus();
            txtcedula.Text = cliente.Cedula;
            txtnombre.Text = cliente.Nombre;
            txtemail.Text = cliente.Email;
            txtdireccion.Text = cliente.Direccion;
            txttelefono.Text = cliente.Telefono;
            this.cliente = cliente;
        }

        private void actualizarTablaClientes()
        {            
            tablaClientes.DataSource = clienteController.GetListClientes(txtfilter.Text);
            tablaClientes.Columns[0].Visible = false;
            tablaClientes.ClearSelection();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!txtcedula.Text.Trim().Equals(""))
            {
                if (!txtnombre.Text.Trim().Equals(""))
                {
                    cliente.Cedula = txtcedula.Text;
                    cliente.Nombre = txtnombre.Text;
                    cliente.Email = txtemail.Text;
                    cliente.Direccion = txtdireccion.Text;
                    cliente.Telefono = txttelefono.Text;
                    if (cliente.Id > 0)
                    {
                        if (clienteController.Edit(cliente))
                        {
                            MessageBox.Show("Éxito!!! Se actualizó el Cliente", "Mensaje");
                            inicializar(new Cliente());
                            actualizarTablaClientes();
                        }
                        else
                        {
                            MessageBox.Show("Error!!! No se actualizó el Cliente", "Mensaje");
                        }
                    }
                    else
                    {
                        if (clienteController.Create(cliente))
                        {
                            MessageBox.Show("Éxito!!! Se agregó el Cliente", "Mensaje");
                            inicializar(new Cliente());
                            actualizarTablaClientes();
                        }
                        else
                        {
                            MessageBox.Show("Error!!! No se agregó el Cliente", "Mensaje");
                        }
                    }                    
                }
                else
                {
                    MessageBox.Show("El Nombre es obligatorio", "Mensaje");
                }
            }
            else
            {
                MessageBox.Show("La Cédula es obligatoria", "Mensaje");
            }
        }
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(tablaClientes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(tablaClientes.CurrentRow.Cells[0].Value.ToString());
                inicializar(clienteController.Search(id));
            }
            else
            {
                MessageBox.Show("Seleccionar un Cliente de la tabla a Editar", "Mensaje");
            }
        }

        private void txtfilter_TextChanged(object sender, EventArgs e)
        {
            actualizarTablaClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            inicializar(new Cliente());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(tablaClientes.CurrentRow.Cells[0].Value.ToString());
                if (clienteController.Delete(id))
                {
                    MessageBox.Show("Éxito!!! Se eliminó el Cliente", "Mensaje");
                    actualizarTablaClientes();
                }
                else
                {
                    MessageBox.Show("Error!!! No se eliminó el Cliente", "Mensaje");
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un Cliente de la tabla a Eliminar", "Mensaje");
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReportCliente frmReporte = new ReportCliente();
            frmReporte.filter = txtfilter.Text;
            frmReporte.Visible = true;
        }
    }
}
