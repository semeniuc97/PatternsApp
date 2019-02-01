using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FactoryInterfaces
{
    public interface IDataReader
    {
        IEnumerable<UserFactory> All();
        IEnumerable<UserFactory> ByCity(string city);

    }
}
