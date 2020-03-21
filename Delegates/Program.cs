using System;
using System.Collections.Generic;
using Delegates.Models;

namespace Delegates
{
    class Program
    {
        public static ShoppingCartModel cart = new ShoppingCartModel();
        static void Main(string[] args)
        {
            PopulateCart();

            
            Console.WriteLine($"The total for the cart is {cart.GenTotal(subTotalAlert, DiscountedSubTotal, AlertUser):C2}");
            Console.WriteLine();
            Console.WriteLine("End");
            
        }

        private static void subTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The original Subtotal was {subTotal:C2}");
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        private static decimal DiscountedSubTotal(List<ProductModel> items, decimal subTotal)
        {
            if(subTotal > 100)
            {
                return subTotal * .80M;
            }
            else if(subTotal > 50)
            {
                return subTotal * .85M;
            }
            else if(subTotal > 10)
            {
              return subTotal * .95M;
            }
            else
            {
                return subTotal;
            }
        }


        private static void PopulateCart()
        {
            cart.Items.Add(new ProductModel {ItemName = "Cereal", Price = 3.63M});
            cart.Items.Add(new ProductModel {ItemName = "Milk", Price = 2.95M});
            cart.Items.Add(new ProductModel {ItemName = "Strawberries", Price = 7.51M});
            cart.Items.Add(new ProductModel {ItemName = "Blueberries", Price = 8.84M});
        }
    }
}
