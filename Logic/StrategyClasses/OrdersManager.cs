using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.StrategyClasses
{
    public class OrdersManager
    {
        IEnumerable<Order> OrdersInfo;
        AnalyticsStrategy analyticsStrategy;
        public OrdersManager(AnalyticsStrategy analyticsStrategy)
        {
            this.analyticsStrategy = analyticsStrategy;
        }

        public void Import(string fileSource)
        {
            OrdersInfo = new OrdersReader(fileSource).GetOrdersFromFile();
        }

        public IEnumerable<string> PrintAnalitycs()
        {
            var orders = analyticsStrategy.Analyze(OrdersInfo);
            foreach (var order in orders)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{order}");
               
            }
            return orders;
        }
    }
}
