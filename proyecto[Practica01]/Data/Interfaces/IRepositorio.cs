using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPractica01.Data.Interfaces
{
    public interface IRepositorio <Clas> 
    {
        Clas GetByID(int id);
        List<Clas> GetAll();
        void Save(Clas clas);
    }
}
