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
    public class PagoController : Informacion
    {
        PagoDAO PagoDAO = new PagoDAO();

        public List<Pago> Index()
        {
            return PagoDAO.GetListPagos();
        }
        public List<Pago> FilterByDate(DateTime fecha_inicio, DateTime fecha_fin)
        {
            return PagoDAO.FilterByDate(fecha_inicio, fecha_fin);
        }

        public bool Create(Pago Pago)
        {
            return PagoDAO.Create(Pago);
        }

        public bool Edit(Pago Pago)
        {
            return PagoDAO.Edit(Pago);
        }
        public Pago Search(int id)
        {
            return PagoDAO.Search(id);
        }
        public bool Delete(int id)
        {
            return PagoDAO.Delete(id);
        }

        public override string informacion()
        {
            return "Pago : " + this.ToString();
        }

        public override string datos()
        {
            base.datos();
            return "Pago : " + this.ToString();
        }
    }
}
