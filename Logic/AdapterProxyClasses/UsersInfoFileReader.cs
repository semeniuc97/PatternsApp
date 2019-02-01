using Logic.AdapterProxyInterfaces;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logic.AdapterProxyClasses
{
    public class UsersInfoFileReader : IDataProvider
    {
        public void AddUser(UserInfoAdapterProxy user, string fileSource)
        {
            using (StreamWriter outputFile = new StreamWriter(fileSource,true))
            {
                outputFile.WriteLine(user.Name + "," + user.Age);
            }
        }

        public List<UserInfoAdapterProxy> FromFile(string fileSource)
        {
            var users = new List<UserInfoAdapterProxy>();
            using (StreamReader myFile = new StreamReader(fileSource))
            {
                while (!myFile.EndOfStream)
                {
                    UserInfoAdapterProxy userInfo = new UserInfoAdapterProxy();
                    string[] usersData = myFile.ReadLine().Split(',');
                    string name = usersData[0];
                    int age = int.Parse(usersData[1]);
                    userInfo.Name = name;
                    userInfo.Age = age;
                    users.Add(userInfo);
                }
            }
            return users;
        }


    }
}
