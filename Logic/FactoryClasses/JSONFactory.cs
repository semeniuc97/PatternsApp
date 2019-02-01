using Logic.FactoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FactoryClasses
{
    public class JSONFactory:IFactory
    {
        string fileSource;
        public JSONFactory(string fileSource)
        {
            this.fileSource = fileSource;
        }

        public IDataReader GetReader()
        {
            return new JSONReader(fileSource);
        }

        public IDataWriter GetWriter()
        {
            return new JSONWriter(fileSource);
        }
    }
}
