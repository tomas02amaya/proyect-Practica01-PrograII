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

        public Factura()
        {
            DetalleFactura = new List<DetalleFactura>();
        }

        public void AddDetalleFactura(DetalleFactura detalleFactura)
        {
            DetalleFactura.Add(detalleFactura);
        }
        public void RevomeDetalleFactura(DetalleFactura detalleFactura)
        {
            DetalleFactura.Remove(detalleFactura);
        }

        public void Total() { 
            double total = 0;
            foreach (DetalleFactura df in DetalleFactura)
            {
                total += df.SubTotal();
            }
        }
    }
}
