using Logic.FactoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace Logic.FactoryClasses
{
    public class JSONWriter : IDataWriter
    {
        string fileSource;
        public JSONWriter(string fileSource)
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
            using (StreamWriter sw = new StreamWriter(fileSource, true))
            {
                sw.WriteLine(JsonConvert.SerializeObject(user));
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
                        var user = JsonConvert.DeserializeObject<UserFactory>(line);
                        if (user.Id == id)
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
