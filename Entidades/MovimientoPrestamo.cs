using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MovimientoPrestamo
    {
        public int Id { get; set; }
        public decimal Monto_pendiente { get; set; }
        public Prestamo Prestamo { get; set; }
    }
}
