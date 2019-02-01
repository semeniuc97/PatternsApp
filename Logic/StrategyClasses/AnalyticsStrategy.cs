using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.StrategyClasses
{
    public class AnalyticsStrategy
    {
        public virtual IEnumerable<string> Analyze(IEnumerable<Order> orders)
        {
            var ordersSumCount = orders.GroupBy(x => new { product=x.Products.Select(u=>u.name),destination=x.Destination})
                .Select(c =>c.Key.destination + " " + c.Key.product.Select(x=>x) ).ToList();
            return ordersSumCount;
            //IEnumerable<OrdersCount> list=new List<OrdersCount>();
            //return list;
        }
    }
}
