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
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int UserLevel { get; private set; }
        public List<MarketItem> Cart { get; private set; } = new List<MarketItem>();
        private static object locker = new object();

        private User(int userId, string userName, int userLevel)
        {
            Id = userId;
            Name = userName;
            UserLevel = userLevel;
        }

        public static void Init(int userId, string userName, int userLevel)
        {
            if (user == null)
            {
                lock (locker)
                {
                    if (user == null)
                    {
                        user = new User(userId, userName, userLevel);                        
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
