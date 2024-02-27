using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceLibrary.Models
{
    public class User(string userName)
    {
        public string Name { get; private set; } = userName;
    }
}
