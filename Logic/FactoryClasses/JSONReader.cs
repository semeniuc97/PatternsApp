using Logic.FactoryInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace Logic.FactoryClasses
{
    public class JSONReader : IDataReader
    {
        string fileSource;
        public JSONReader(string fileSource)
        {
            this.fileSource = fileSource;
        }

        public IEnumerable<UserFactory> All()
        {

            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<User>));
            //using (FileStream outputFile = new FileStream(fileSource, FileMode.OpenOrCreate))
            //{
            //   usersList = (List<User>)serializer.ReadObject(outputFile);
            //}
            //using (StreamReader file = new StreamReader(fileSource))
            //{
            //    while (!file.EndOfStream)
            //    {
            //        JsonSerializer serializer = new JsonSerializer();
            //        User[] users = (User[])serializer.Deserialize(file, typeof(User[]));
            //        usersList.AddRange(users);
            //    }
            //}
            List<UserFactory> usersList = new List<UserFactory>();

            using (var reader = new StreamReader(fileSource))
            {
                while (!reader.EndOfStream)
                {
                    var user = JsonConvert.DeserializeObject<UserFactory>(reader.ReadLine());
                    usersList.Add(user);
                }
            }
            return usersList;
        }

        public IEnumerable<UserFactory> ByCity(string city)
        {
            List<UserFactory> usersList = new List<UserFactory>();

            using (var reader = new StreamReader(fileSource))
            {
                while (!reader.EndOfStream)
                {
                    var user = JsonConvert.DeserializeObject<UserFactory>(reader.ReadLine());
                    if (user.City != city)
                        continue;
                    usersList.Add(user);
                }
            }
            return usersList;
        }
    }
}
