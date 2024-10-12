using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models
{
    public abstract class StoreItems
    {
        public List<Item> Storeitems = new List<Item>()
            {
                new Item(Title: "Headphone" , Price: 5000.00),
                new Item(Title: "Labtop" , Price: 30000.00),
                new Item(Title: "Computer" , Price: 24500.00),
                new Item(Title: "Airpod" , Price: 600.00),
                new Item(Title: "iPhone" , Price: 21499.99),
            };
    }
}