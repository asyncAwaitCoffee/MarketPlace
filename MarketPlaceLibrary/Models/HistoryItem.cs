using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceLibrary.Models
{
    public class HistoryItem(string title, int operationType, decimal cost, DateTime historyDate)
    {
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; } = title;
        public int OperationType { get; set; } = operationType;
        public decimal Cost { get; set; } = cost;
        public DateTime HistoryDate { get; set; } = historyDate;
        public byte OrderState { get; set; }
        public int UserId { get; set; }
        public int PartnerId { get; set; }
        public int MarketItemId { get; set; }
    }
}
