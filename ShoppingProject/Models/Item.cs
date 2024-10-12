using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models
{
    public class Item
    {
        public string? Title { get; set; }
        public double Price { get; set; }

        public Item(string Title, double Price)
        {
            this.Title = Title;
            this.Price = Price;
        }
    }
}