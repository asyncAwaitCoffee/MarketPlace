using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceLibrary.Models
{
    public class User
    {
        public static User user = null;
        public static bool isLoggedIn { get; private set; } = false;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int UserLevel { get; private set; }
        public decimal Balance { get; private set; }
        private static object locker = new object();

        private User(int userId, string userName, int userLevel, decimal balance)
        {
            Id = userId;
            Name = userName;
            UserLevel = userLevel;
            Balance = balance;
        }

        public static void Init(int userId, string userName, int userLevel, decimal balance)
        {
            if (user == null)
            {
                lock (locker)
                {
                    if (user == null)
                    {
                        user = new User(userId, userName, userLevel, balance);
                        isLoggedIn = true;
                    }
                }
            }
        }

        public static User Instance()
        {
            return user;
        }

        public static void LogOut()
        {
            user = null;
        }
    }
}
