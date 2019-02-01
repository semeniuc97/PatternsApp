using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic.StrategyClasses
{
    public class CostSumAnalyticsStrategy : AnalyticsStrategy
    {
        public override IEnumerable<string> Analyze(IEnumerable<Order> orders)
        {
            var ordersSumCount = orders.GroupBy(x => x.Destination)
                .Select(c => c.Key + " " + c.SelectMany(y => y.Products)
                .Sum(y => y.cost)).ToList();
            return ordersSumCount;
        }
    }
}
