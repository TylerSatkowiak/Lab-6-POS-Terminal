using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6_Project_POS_Terminal
{
    public class Store
    {
        public static List<Descriptions> items = new List<Descriptions>();

        public static void AddToStore(Descriptions item)
        {
            items.Add(item);
        }

        public static void StoreInventory()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
            Console.WriteLine("");
        }

    }
}
