using Datos;
using Entidades;
using Entidades.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteController : Informacion
    {
        ClienteDAO clienteDAO = new ClienteDAO();

        public List<ICliente> GetListClientes(string filter)
        {
            return clienteDAO.GetListCliente(filter);
        }

        public bool Create(Cliente cliente)
        {
            return clienteDAO.Create(cliente);
        }

        public bool Edit(Cliente cliente)
        {
            return clienteDAO.Edit(cliente);
        }
        public Cliente Search(int id)
        {
            return clienteDAO.GetClient(id);
        }
        public bool Delete(int id)
        {
            return clienteDAO.Delete(id);
        }

        public override string informacion()
        {
            return "Cliente : " + this.ToString();
        }
         
        public override string datos()
        {
            base.datos();
            return "Cliente : " + this.ToString();
        }
    }
}
