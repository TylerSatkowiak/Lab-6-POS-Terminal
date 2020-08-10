using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_6_Project_POS_Terminal
{
    public class ShoppingCart
    {
        public static List<Descriptions> cart = new List<Descriptions>();

        public static void AddToCart(Descriptions item)
        {
            cart.Add(item);
        }

        public static double GetTotal()
        {
            double total = 0;
            for (int i = 0; i < cart.Count; i++)
            {
                total  = total + (cart[i].Price);
            }
            return total;
        }

        public static void CartInventory()
        {
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cart[i]}");
            }
        }
    }
}
