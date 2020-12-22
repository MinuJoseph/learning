using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakedInHeaven.API.Context;

namespace BakedInHeaven.API.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public string Price { get; set; }

        public string WeightInGrams { get; set; }

        public string Kcal { get; set; }

        public bool IsVeg { get; set; }

        public bool IsSpecial { get; set; }

        public DateTime AvailableDate { get; set; }
    }

}
