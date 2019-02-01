using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.StrategyClasses
{
    public class AverageAnalyticStrategy : AnalyticsStrategy
    {
        public override IEnumerable<string> Analyze(IEnumerable<Order> orders)
        {
            var ordersSumCount = orders.GroupBy(x => x.Destination)
                .Select(c => c.Key + " " + c.SelectMany(y => y.Products)
                .Average(y => y.cost)).ToList();
            return ordersSumCount;
        }
    }
}
