using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interface
{
    public interface ICliente
    {
        int Id { get; set; }
        string Cedula { get; set; }
        string Nombre { get; set; }
        string Email { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
    }
}
