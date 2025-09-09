using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograII_tp1.Data.DataHelpers
{
    public class Parameter
    {
        public Parameter()
        {
            Name = string.Empty;
            Valor = null;
        }
        public Parameter(string name, object valor)
        {
            this.Name = name;
            this.Valor = valor;
        }
        public string Name { get; set; }
        public object Valor { get; set; }
    }
}
