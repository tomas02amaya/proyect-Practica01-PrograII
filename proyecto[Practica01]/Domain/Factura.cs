using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPractica01.Domain
{
    public class Factura
    {
        public int NroFactura { get; set; }
        public DateOnly DateOnly { get; set; }
        public FormaPago FormaPago { get; set; }
        public string Cliente { get; set; }
        public List<DetalleFactura> DetalleFactura { get; set; }

    }
}
