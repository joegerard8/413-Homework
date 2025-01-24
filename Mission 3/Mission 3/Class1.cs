using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mission_3
{
    public class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Quantity { get; set; }
        public string Date {  get; set; }
        public FoodItem (string name, string category, string quantity, string date) 
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            Date = date;     
        }
    }
}
