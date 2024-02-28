using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceLibrary.Models
{
    public class HistoryItem(int userId, int partnerId, int marketItemId, int operationType, decimal cost, DateTime historyDate)
    {
        public int UserId { get; set; } = userId;
        public int PartnerId { get; set; } = partnerId;
        public int MarketItemId { get; set; } = marketItemId;
        public int OperationType { get; set; } = operationType;
        public decimal Cost { get; set; } = cost;
        public DateTime HistoryDate { get; set; } = historyDate;
        public byte OrderState { get; set; } = 0;
    }
}
