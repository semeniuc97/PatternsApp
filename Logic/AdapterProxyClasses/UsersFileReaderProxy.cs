using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Logic.AdapterProxyClasses
{
    public class UsersFileReaderProxy : UsersFileReader
    {
        
        public override void AddUser(UserInfoAdapterProxy user, string fileSource)
        {
            Console.WriteLine("Executing \"AddUser\"");
            var watch = Stopwatch.StartNew();
            base.AddUser(user, fileSource);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        public override List<UserInfoAdapterProxy> FromFile(string fileSource)
        {
            Console.WriteLine("Executing \"FromFile\"");
            var watch = Stopwatch.StartNew();
            var users = base.FromFile(fileSource);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            return users;
        }

    }
}
