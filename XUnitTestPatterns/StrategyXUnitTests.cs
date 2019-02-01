using Logic.AdapterProxyClasses;
using Logic.AdapterProxyInterfaces;
using Logic.StrategyClasses;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestPatterns
{
    public class StrategyXUnitTests
    {
        [Fact]
        public void CheckAverageAnalyticsStrategy()
        {
            AverageAnalyticStrategy averageStrategy = new AverageAnalyticStrategy();

            var result = averageStrategy.Analyze(new List<Order>()
            {
                new Order()
                {
                    Destination="Minsk",
                    Products=new List<Product>()
                    {
                        new Product()
                        {
                            cost=100,
                            name="fruits"
                        },
                        new Product()
                        {
                            cost=300,
                            name="sand"
                        }
                    }
                },
                new Order()
                {
                    Destination="Liverpool",
                    Products=new List<Product>()
                    {
                        new Product()
                        {
                            cost=200,
                            name="pills"
                        },
                        new Product()
                        {
                            cost=300,
                            name="wood"
                        }
                    }
                },

            });

            var expected = new List<string>()
            {
                "Minsk 200",
                "Liverpool 250"
            };

            Assert.Equal(expected, result);
            
        }


        [Fact]
        public void CheckCostSumAnalyticsStrategy()
        {
            CostSumAnalyticsStrategy costSumStrategy = new CostSumAnalyticsStrategy();

            var result = costSumStrategy.Analyze(new List<Order>()
            {
                new Order()
                {
                    Destination="Minsk",
                    Products=new List<Product>()
                    {
                        new Product()
                        {
                            cost=100,
                            name="fruits"
                        },
                        new Product()
                        {
                            cost=300,
                            name="sand"
                        }
                    }
                },
                new Order()
                {
                    Destination="Liverpool",
                    Products=new List<Product>()
                    {
                        new Product()
                        {
                            cost=200,
                            name="pills"
                        },
                        new Product()
                        {
                            cost=300,
                            name="wood"
                        }
                    }
                },

            });

            var expected = new List<string>()
            {
                "Minsk 400",
                "Liverpool 500"
            };

            Assert.Equal(expected, result);

        }
    }
}
