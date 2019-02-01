using Logic.AdapterProxyInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logic.AdapterProxyClasses
{
    public class UsersFileReader : IDataProvider
    {
        public virtual void AddUser(UserInfoAdapterProxy user, string fileSource)
        {
            using (StreamWriter outputFile = new StreamWriter(fileSource,true))
            {
                outputFile.WriteLine(user.Name + "," + user.Age);
            }
        }

        public virtual List<UserInfoAdapterProxy> FromFile(string fileSource)
        {
            var users = ReadUsers(fileSource);
            return users.Select(x => new UserInfoAdapterProxy()
            {
                Age = x.Age,
                Name = x.Name

            }).ToList();
        }

        public virtual List<UserAdapterProxy> ReadUsers(string fileSource)
        {

            var users = new List<UserAdapterProxy>();
            using (StreamReader myFile = new StreamReader(fileSource))
            {
                while (!myFile.EndOfStream)
                {
                    UserAdapterProxy user = new UserAdapterProxy();
                    string[] usersData = myFile.ReadLine().Split(',');
                    string name = usersData[0];
                    int age = int.Parse(usersData[1]);
                    user.Name = name;
                    user.Age = age;
                    users.Add(user);
                }
            }
            return users;
        }
    }


}

