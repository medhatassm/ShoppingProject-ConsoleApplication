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
