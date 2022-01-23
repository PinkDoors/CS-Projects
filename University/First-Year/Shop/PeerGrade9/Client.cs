using System;
using System.Collections.Generic;
using System.Text;

namespace PeerGrade9
{
    public class Client:User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public ulong Phone { get; set; }
        public string Address { get; set; }
        public List<Order> AllOrders { get; set; } = new List<Order>();
        public List<Item> Basket = new List<Item>();
        public Client(string login, string password,int code):base (login, password, code)
        {
        }
    }
}
