using Logic.FactoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FactoryClasses
{
    public class FileFactory : IFactory
    {
        string fileSource;
        public FileFactory()
        {

        }

        public FileFactory(string fileSource)
        {
            this.fileSource = fileSource;
        }
        public virtual IDataReader GetReader()
        {
            return new FileReader(fileSource);
        }

        public virtual IDataWriter GetWriter()
        {
            return new FileWriter(fileSource);
        }
    }
}
