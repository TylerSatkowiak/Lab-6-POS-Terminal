using System;
using System.Collections.Generic;


namespace Lab_6_Project_POS_Terminal
{
    public class Program
    {
        public static bool CheckOut()
        {
            ViewCart();
            Console.WriteLine("Would you like to add more or proceed to checkout (1/2)?");
            while (true)
            {
                string checkout = Console.ReadLine().ToLower();
                if (checkout != "1" && checkout != "2")
                {
                    Console.WriteLine("Sorry, please try inputting again.");
                    CheckOut();
                    return true;
                }

                else if (checkout == "1")
                {
                    Store.StoreInventory();
                    return true;
                }

                else
                {
                    double payment = 0;
                    double withTaxes = 0;
                    Console.WriteLine("Thanks for your order! Here is your receipt.");
                    ShoppingCart.CartInventory();
                    double total = ShoppingCart.GetTotal();
                    Console.WriteLine("");
                    Console.WriteLine($"Subtotal: ${total:N2}");
                    withTaxes = total * 1.06;

                    Console.WriteLine($"Total taxes paid: ${total * .06:N2}");
                    Console.WriteLine($"Total paid today: ${withTaxes:N2}");


                    Console.WriteLine("How much cash are you paying with?");
                    string entry = Console.ReadLine();
                    if (!double.TryParse(entry, out payment))
                    { 
                        Console.WriteLine("Not a valid input.");
                    }
                    else
                    {
                        double change = Payment(total, payment);
                        Console.WriteLine($"Here is your change: ${change:N2}");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Have a wonderful day!");
                    return false;
                }
            }
        }

        public static double Payment(double total, double CashTendered)
        {
            double cashReturned = CashTendered - total;
            return cashReturned;
        }


        public static void ViewCart()
        {
            Console.WriteLine("View your cart below:");
            Console.WriteLine(String.Format("{0,15} {1,15} {2,15} {3,15}", "Item", "Department", "Description", "Price"));
            for (int i = 0; i < ShoppingCart.cart.Count; i++)
            {
                //Printout each value in Cart and total at that moment.
                Console.WriteLine(ShoppingCart.cart[i]);
            }
            Console.WriteLine("");
        }

        //Validate input and return the Menu Value
        public static int SelectionValidation()
        {
            Console.WriteLine("Which item would you like to add to your cart?");
            while (true)
            {
                string entry = Console.ReadLine().ToLower();
                int menuValue = int.Parse(entry);
                
                if (menuValue > 0 && menuValue <= 13)
                {
                    return menuValue;
                }
                else
                {
                    Console.WriteLine("Please have a valid input next time.");
                    SelectionValidation();
                }
            }
        }

        public static void Main()
        {
            Descriptions apples = new Descriptions("3lbs. Apples", "Produce", "Granny Smith", 4.99);
            Descriptions avacado = new Descriptions("Avacado", "Produce", "From Mexico", 1.59);
            Descriptions game1 = new Descriptions("Prey", "Technology", "PS4", 19.99);
            Descriptions game2 = new Descriptions("Paper Mario", "Technology", "Switch", 49.99);
            Descriptions redkale = new Descriptions("Red Kale", "Produce", "Red Kale", .99);
            Descriptions tent = new Descriptions("Camping Tent", "Outdoors", "HardRock", 149.99);
            Descriptions candle = new Descriptions("Indoor Candle", "Home Goods", "Yankee Candle", 4.99);
            Descriptions card = new Descriptions("Holiday Card", "General Goods", "Hallmark Card", 19.99);
            Descriptions weights = new Descriptions("25lb Dumbell", "Toys/Equipment", "Tommy bells", 19.99);
            Descriptions laptop = new Descriptions("Dell Laptop", "Technology", "WIN 10", 449.99);
            Descriptions book = new Descriptions("1984", "Home Goods", "Hardcover", 9.99);
            Descriptions vitamins = new Descriptions("Multivitamins", "Personal Health", "Fitamins", 9.99);

            Console.WriteLine("Welcome to Wally World!");
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0,15} {1,15} {2,15} {3,15}", "Item", "Department", "Description", "Price"));
            Store.StoreInventory();

            int menuValue = 0;
            bool flag = true;

            
            while (flag)
            {
                menuValue = SelectionValidation();
                ShoppingCart.AddToCart(Store.items[menuValue-1]);
                ShoppingCart.GetTotal();
                Console.WriteLine("");
                Console.WriteLine($"Succesfully added {Store.items[menuValue-1].Name} to your cart.");
                Console.WriteLine("");
                Console.WriteLine($"You have {ShoppingCart.cart.Count} item(s) in your cart");
                Console.WriteLine("");
                flag = CheckOut();
            }

        }
    }
}
