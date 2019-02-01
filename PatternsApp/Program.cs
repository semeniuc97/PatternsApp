using Logic.AdapterProxyClasses;
using Logic.FactoryClasses;
using Logic.StrategyClasses;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = @"C:\Users\msemeniu\Desktop\UserAdapter.txt";
            UsersFileReaderProxy proxy = new UsersFileReaderProxy();
            UsersInfoFileReader fileReader = new UsersInfoFileReader();
            UsersFileReader usersFileReader = new UsersFileReader();
            UserManagerAdapter userManager = new UserManagerAdapter(usersFileReader, source);
            UserManagerAdapter userManager2 = new UserManagerAdapter(proxy, source);
            var users = userManager.GetAll();
            var users2 = userManager2.GetAll();
            //var testUser = new UserInfoAdapterProxy()
            //{
            //    Age = 20,
            //    Name="Petika"
            //};
            //userManager2.AddUser(testUser);

            foreach (var user in users2)
            {
                Console.WriteLine(user.Age + " " + user.Name);
            }

            Console.ReadKey();

            /////////////////////////////////////////////////////////////////////////

            //string source2 = @"C:\Users\msemeniu\Desktop\UsersInfo.txt";
            //FileFactory fileFactory = new FileFactory(source2);
            //UserManagerFactory userManagerFactory = new UserManagerFactory(fileFactory);
            //var userList = userManagerFactory.ByCity("Beijing");
            //foreach (var user in userList)
            //{
            //    Console.WriteLine($"{user.Name},{user.Age},{user.City}");
            //}
            ////userManagerFactory.Add("Vasya", 18, "Beijing");
            //userManagerFactory.Delete(new Guid("8ff8cec0-5930-47f4-913a-17bb613739bc"));

            //Console.ReadKey();

            /////////////////////////////////////////////////////////////////////////////////

            string jsonSource = @"C:\Users\msemeniu\Desktop\UsersJson.txt";
            JSONFactory jsonFactory = new JSONFactory(jsonSource);
            UserManagerFactory userManagerJson = new UserManagerFactory(jsonFactory);
            //userManagerJson.Add("Vasya", 18, "Beijing");
            //userManagerJson.Add("Kolya", 20, "Tokyo");
            var usersJson = userManagerJson.ByCity("Tokyo");
            foreach (var user in usersJson)
            {
                Console.WriteLine(user.Name + " " + user.Age + " " + user.City);
            }
            userManagerJson.Delete(new Guid("2f638806-9fcf-49f3-ab88-247ff481955d"));
            /////
            Console.ReadLine();

            OrdersReader reader = new OrdersReader(@"C:\Users\msemeniu\Desktop\StrategiFile.txt");
            CostSumAnalyticsStrategy strategy = new CostSumAnalyticsStrategy();
            OrdersManager ordersManager = new OrdersManager(strategy);
            ordersManager.Import(@"C:\Users\msemeniu\Desktop\StrategiFile.txt");
            ordersManager.PrintAnalitycs();

            Console.WriteLine("///////////////////////////////////////");

            AnalyticsStrategy avgStrategy = new AverageAnalyticStrategy();
            OrdersManager ordersManagerAvg = new OrdersManager(avgStrategy);
            ordersManagerAvg.Import(@"C:\Users\msemeniu\Desktop\StrategiFile.txt");
            ordersManagerAvg.PrintAnalitycs();


            Console.ReadKey();



        }
    }
}
