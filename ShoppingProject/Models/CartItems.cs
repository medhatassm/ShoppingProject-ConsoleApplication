using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingProject.Models
{
    public class CartItems : StoreItems
    {
        List<Item> CartList = new List<Item>();
        Stack<string> actions = new Stack<string>();


        // Add Item To Cart
        public void AddCartToItem()
        {
            // Display Avaliable Item
            int counter = 1;
            foreach (var item in Storeitems)
            {
                Console.WriteLine($"{counter}- {item.Title}\tPrice: {item.Price}");
                counter++;
            }

            // User Select An Item
            Console.WriteLine("\nPlease Enter Selected Item Name\n");
            string selectedItem = Console.ReadLine().ToLower();

            // Add Item To  Cart
            bool found = true;
            Console.WriteLine();
            foreach (var item in Storeitems)
            {
                if (selectedItem.Equals(item.Title.ToLower()))
                {
                    Console.WriteLine("\nAdd Item To Your Cart...");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nItem Add Successfuly\n");
                    actions.Push($"Add {item.Title}");
                    CartList.Add(new Item(Title: item.Title, Price: item.Price));
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }
            }

            if (!found)
            {
                Console.WriteLine("\nYour Cart Is Empty\n");
            }

        }

        public void ViewCart()
        {
            double total = 0;
            if (CartList.Any())
            {
                int counter = 1;
                Console.WriteLine("\nLoading Your Cart....");
                Thread.Sleep(2000);
                Console.WriteLine();
                foreach (var item in CartList)
                {
                    Console.WriteLine($"{counter}- {item.Title}\tPrice:{item.Price}");
                    counter++;
                    total += item.Price;
                }
                Console.WriteLine("==============================");
                Console.WriteLine($"\nTotal Price is: {string.Format("{0:0.00}", total)}");

            }
            else
            {
                Console.WriteLine("\nCart is Empty\n");
            }
        }

        public void RemoveItemFromCart()
        {
            ViewCart();
            Console.Write("\nEnter Item Name Which You Want To Remove: ");
            string selectedItem = Console.ReadLine().ToLower();
            bool found = true;
            foreach (var item in CartList)
            {
                if (selectedItem.Equals(item.Title.ToLower()))
                {
                    Console.WriteLine("Item Removing...");
                    Thread.Sleep(2000);
                    CartList.Remove(item);
                    Console.WriteLine("Item Removed Successfuly");
                    actions.Push($"Remove {item.Title}");
                    break;
                }
                else
                {
                    found = false;
                }

            }
            if (!found)
            {
                Console.WriteLine("\nItem Not Found\n");
            }

        }

        public void CheckOut()
        {
            Console.WriteLine("Are you sure? (Answer yes/no)");
            string dis = Console.ReadLine().Trim().ToLower();
            if (CartList.Any())
            {
                if (dis.Equals("yes"))
                {
                    Console.WriteLine("Checking Out...");
                    Thread.Sleep(5000);
                    CartList.Clear();
                    Console.WriteLine("Checkout Complete");
                }
            }
            else
            {
                Console.WriteLine("\n Your Cart is Empty");
            }
        }

        public void UndoAction()
        {
            Console.WriteLine("Undo Last Action...");
            Thread.Sleep(2000);
            string[] actionArr = actions.Pop().Split(" ");
            if (actionArr[0].Equals("Add"))
            {
                foreach (var item in CartList)
                {
                    if (item.Title.Equals(actionArr[1]))
                    {
                        CartList.Remove(item);
                        break;
                    }
                }
            }
            else if (actionArr[0].Equals("Remove"))
            {
                foreach (var item in Storeitems)
                {
                    if (item.Title.Equals(actionArr[1]))
                    {
                        CartList.Add(item);
                    }
                }
            }
            Console.WriteLine("Action Undo Complete");
        }
        
    }
}