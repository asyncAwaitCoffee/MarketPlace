using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceLibrary.Models
{
    public static class AppState
    {
        private static int currentPage = 1;
        public static int CurrentPage {
            get { return currentPage; }
            set { currentPage = Math.Max(value, 1); }
        }
        public static int ItemsPerPage { get; set; } = 3;
        public static bool isLoadNext { get; set; } = true;
    }
}
