using Lab_6_Project_POS_Terminal;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lab_6_Project_POS_Terminal_Tests
{
    public class POS_TerminalTests
    {
        
        [Fact]
        public static void TestList()
        {
            Program.Main();
            Assert.Equal(12, Store.items.Count);
        }
        
        [Fact]
        public static void Testy()
        {
            ShoppingCart.cart.Insert(0, Store.items[0]);
            Assert.Equal(1, ShoppingCart.cart.Count);
        }
        
        [Fact]
        public static void TestCartTotal()
        {

            ShoppingCart.AddToCart(Store.items[1]);
            Assert.Equal(1.59, ShoppingCart.GetTotal());
        }
        
        [Fact]
        public static void TestChange()
        {

            double res = Program.Payment(4.00, 8.00);
            Assert.Equal(4.00,res);
        }


    }
}
