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
    public class FileReader : IDataReader
    {
        private string fileSource;
        public FileReader(string fileSource)
        {
            this.fileSource = fileSource;
        }


        public virtual IEnumerable<UserFactory> All()
        {
            var users = new List<UserFactory>();
            using (StreamReader myFile = new StreamReader(fileSource))
            {
                while (!myFile.EndOfStream)
                {
                    UserFactory user = new UserFactory();
                    string[] usersData = myFile.ReadLine().Split(',');
                    string name = usersData[0];
                    int age = int.Parse(usersData[1]);
                    string city = usersData[2];
                    user.Name = name;
                    user.Age = age;
                    user.City = city;
                    users.Add(user);
                }
            }
            return users;
        }

        public IEnumerable<UserFactory> ByCity(string city)
        {
            var users = new List<UserFactory>();
            using (StreamReader myFile = new StreamReader(fileSource))
            {
                while (!myFile.EndOfStream)
                {
                    UserFactory user = new UserFactory();
                    string[] usersData = myFile.ReadLine().Split(',');
                    if (usersData[3] == city)
                    {
                        string name = usersData[1];
                        int age = int.Parse(usersData[2]);
                        user.Id = new Guid(usersData[0]);
                        user.Name = name;
                        user.Age = age;
                        user.City = usersData[3];
                        users.Add(user);
                    }
                    else
                        continue;

                }
            }
            return users;
        }
    }
}
