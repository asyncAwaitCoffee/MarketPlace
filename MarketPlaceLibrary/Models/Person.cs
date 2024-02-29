using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceLibrary.Models
{
    public class Person(int userId, decimal balance)
    {
        public int UserId { get; private set; } = userId;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public decimal Balance { get; private set; } = balance;
    }
}
