using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
    public class MovimientoPrestamoController: Informacion
    {
        MovimientoPrestamoDAO MovimientoPrestamoDAO = new MovimientoPrestamoDAO();

        public List<MovimientoPrestamo> Index(string filter)
        {
            return MovimientoPrestamoDAO.GetListMovimientos(filter);
        }
        public override string informacion()
        {
            return "Movimiento Prestamo : " + /*this.*/ToString();
        }
        public override string datos()
        {
            base.datos();
            return "Movimiento Prestamo : " + /*this.*/ToString();
        }
    }
}
