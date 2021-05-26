using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto_prestamo { get; set; }
        public int Cuotas { get; set; }
        public virtual Cliente Cliente{ get; set; }

        public override string ToString()
        {
            return "Id = " + Id;
        }
    }
}
