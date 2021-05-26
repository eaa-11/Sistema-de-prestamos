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
    public class PrestamoController : Informacion
    {
        PrestamoDAO PrestamoDAO = new PrestamoDAO();

        public List<Prestamo> Index(string filter)
        {
            return PrestamoDAO.GetListPrestamos(filter);
        }

        public bool Create(Prestamo Prestamo)
        {
            return PrestamoDAO.Create(Prestamo);
        }

        public bool Edit(Prestamo Prestamo)
        {
            return PrestamoDAO.Edit(Prestamo);
        }
        public Prestamo Search(int id)
        {
            return PrestamoDAO.Search(id);
        }
        public bool Delete(int id)
        {
            return PrestamoDAO.Delete(id);
        }

        public override string informacion()
        {
            return "Prestamo : " + this.ToString();
        }

        public override string datos()
        {
            base.datos();
            return "Prestamo : " + this.ToString();
        }
    }
}
