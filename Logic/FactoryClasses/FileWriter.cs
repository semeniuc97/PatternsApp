using Logic.FactoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.FactoryClasses
{
    public class FileWriter : IDataWriter
    {
        private string fileSource;
        public FileWriter(string fileSource)
        {
            this.fileSource = fileSource;
        }
        public UserFactory Add(string name, int age, string city)
        {
            var user = new UserFactory()
            {
                Name = name,
                Age = age,
                City = city
            };
            using (StreamWriter outputFile = new StreamWriter(fileSource, true))
            {
                outputFile.WriteLine($"{user.Id},{user.Name},{user.Age},{user.City}");
            }
            return user;
        }

        public void Delete(Guid id)
        {
            string tempFile = Path.GetTempFileName();
            using (StreamReader reader = new StreamReader(fileSource))
            {
                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (line.Split(',')[0] == id.ToString())
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }
            File.Delete(fileSource);
            File.Move(tempFile, fileSource);
        }
    }
}
