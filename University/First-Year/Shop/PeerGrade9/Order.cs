using System;
using System.Collections.Generic;
using System.Text;

namespace PeerGrade9
{
    public class Order
    {
        public static ulong numberOfAllOrders;
        public List<Item> OrderedItems { get; set; } = new List<Item>();
        public ulong OrderNumber { get; set; }
        public DateTime RegistrationTime { get; set; }
        public Client Customer { get; set; }
        public Status OrderStatus { get; set; }

        public Order(Client customer,List<Item> basket)
        {
            OrderedItems = basket;
            Customer = customer;
            OrderNumber = ++numberOfAllOrders;
            RegistrationTime = DateTime.Now;
        }

        /// <summary>
        /// Gives the string that contains all goods in the order.
        /// </summary>
        /// <returns></returns>
        public string GetAllGoods()
        {
            string output = "";
            for (int i = 0; i < OrderedItems.Count; i++)
            {
                output += $"{OrderedItems[i].Name}, ";
            }
            return output.Trim().Trim(',');
        }

        /// <summary>
        /// Gives the cost of the order.
        /// </summary>
        /// <returns></returns>
        public double FindPrice()
        {
            double price = 0;
            for (int i = 0; i < OrderedItems.Count; i++)
            {
                price += OrderedItems[i].Price;
            }
            return price;
        }
    }

    [Flags]
    public enum Status
    {
        Processed = 1,
        Paid = 2,
        Shipped = 4,
        Executed = 8
    }
}
