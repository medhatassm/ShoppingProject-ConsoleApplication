# Shopping System Project 🛒

## Requirement

- Add Item To Cart
- View Cart
- Remove Item From Cart
- CheckOut
- Undo Last Action
- Exit

## Collections To Create

- Store Items
- Cart Items

---

## User Story

- Display All options to User
    - Add item to cart
    - View cart
    - Remove item from cart
    - checkout
    - Undo last action
    - Exit
- User can chose options by typing option number.
- **Add Item To Cart**
    - Display all item at store to user.
    - User can select item which he want by typing its name.
    - check if item that user select is exist at store
    - if selected item exist, add it to user cart.
- **View Cart**
    - Display all item (Title , Price) in user cart to user screen.
    - if user cart was empty display “Cart Empty” message to user screen.
- **RemoveI tem**
    - View all item in user cart to user screen.
    - User can select item which he want by typing its name.
    - Check if item that user select is exist in user cart.
    - Remove selected item from user cart.
- **Check Out**
    - If user decide to buy all item, then display “Are you sure?” message to screen.
    - Delete all item in user cart.
- **Undo Action**
    - Store user actions in collections.
    - Remove last action which user make.

---

## Development

1. Create Class **Item** that have 2 properties (Title,Price).
    
    ```csharp
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
    ```
    
2. Create **Abstract** Class **StoreItems** That have List<Item>, and make it abstract because it has fixed data (Never Changed).
    
    ```csharp
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
    ```
    
3. Create Class **CartItems** That have List<Item>, but this list is data changeable.
    
    ```csharp
    namespace ShoppingProject.Models
    {
        public class CartItems : StoreItems
        {
            List<Item> CartList = new List<Item>();
        }
    }
    ```
    
4. Add “AddItemToCart” Function To **CartItem** Class
    
    ```csharp
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
    
    ```
    
5. Add “ViewCart” Function To **CartItem** Class
    
    ```csharp
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
    
    ```
    
6. Add “RemoveItemFromCart” Function To **CartItem** Class
    
    ```csharp
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
    
    ```
    
7. Add “CheckOut” Function To **CartItem** Class
    
    ```csharp
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
    
    ```
    
8. Create Stack Collection That Hold Users Actions
    
    ```csharp
    Stack<string> actions = new Stack<string>();
    ```
    
9. Add “UndoAction” Function To **CartItem** Class
    
    ```csharp
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
            
    ```
    
10. Call CartItem Class To Program.
    
    ```csharp
    using ShoppingProject.Models;
    
    Console.WriteLine("Welcome To My Shop 🛒\n==============================\n");
    CartItems cartItems = new CartItems();
    while (true)
    {
        Console.WriteLine("\nHow can i help you?\n");
    
        Console.Write($"{(int)Options.AddItemToCart}- {Options.AddItemToCart}");
        Console.Write($"\t{(int)Options.ViewCart}- {Options.ViewCart}\n");
        Console.Write($"{(int)Options.RemoveItemFromCart}- {Options.RemoveItemFromCart}");
        Console.Write($"\t{(int)Options.CheckOut}- {Options.CheckOut}\n");
        Console.Write($"{(int)Options.UndoAction}- {Options.UndoAction}");
        Console.Write($"\t\t{(int)Options.Exit}- {Options.Exit}\n");
    
        Console.Write("\nEnter option number: ");
        int option = Convert.ToInt32(Console.ReadLine());
    
        switch (option)
        {
            case (int)Options.AddItemToCart:
                cartItems.AddCartToItem();
                break;
            case (int)Options.ViewCart:
                cartItems.ViewCart();
                break;
            case (int)Options.RemoveItemFromCart:
                cartItems.RemoveItemFromCart();
                break;
            case (int)Options.CheckOut:
                cartItems.CheckOut();
                break;
            case (int)Options.UndoAction:
                cartItems.UndoAction();
                break;
            case (int)Options.Exit:
                Console.WriteLine("Thanks For Using Our Shop");
                Console.WriteLine("Closing....");
                Thread.Sleep(1000);
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid Number Please Enter Number For 1 to 6");
                break;
        }
    
    }
    ```
    

---

## How To Run

1. Clone Repository to you device.
2. Open terminal (mac) || CMD (windows).
3. go to clone repository path with command `cd` work on both mac and windows.
4. using this command again
    
    ```
    cd ShoppingProject
    ```
    
5. using .Net CLI to run the project
    
    ```
    dotnet run
    ```
    

---

> This Project for practice on collections at C# programming language, and hope you learn from it, and if not i am sorry for it 😢
> 

## Author

***Medhat Assem 🔥***

### Thanks For Reading And Please Leave Star 😉