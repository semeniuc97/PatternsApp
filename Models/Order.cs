using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public string Destination { get; set; }
        public List<Product> Products { get; set; }
    }
}
