using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto_pagado { get; set; }
        public Prestamo Prestamo { get; set; }
        public Cliente Cliente { get; set; }
    }
}
