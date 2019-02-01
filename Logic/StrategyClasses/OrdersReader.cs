using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Logic.StrategyClasses
{
    public class OrdersReader
    {
        string fileSource;
        public OrdersReader(string fileSource)
        {
            this.fileSource = fileSource;
        }
        public IEnumerable<Order> GetOrdersFromFile()
        {
            string text = File.ReadAllText(fileSource);
            var orders = JsonConvert.DeserializeObject<List<Order>>(text);
            return orders;
        }
    }
}
