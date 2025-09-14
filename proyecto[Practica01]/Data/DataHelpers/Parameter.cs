using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPractica01.Data.DataHelpers
{
    public class Parameter
    {
        public Parameter()
        {
            Nombre = string.Empty;
            Valor = null;
        }
        public Parameter(string name, object valor)
        {
            this.Nombre = name;
            this.Valor = valor;
        }
        public string Nombre { get; set; }
        public object Valor { get; set; }
    }
}
