using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OrdersCount
    {
        public string Destination { get; set; }
        public IEnumerable<Product> Product { get; set; }
        public double Sum { get; set; }
    }
}
