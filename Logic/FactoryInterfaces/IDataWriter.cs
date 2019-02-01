using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FactoryInterfaces
{
    public interface IDataWriter
    {
        UserFactory Add(string name,int age,string city);
        void Delete(Guid id);
    }
}
