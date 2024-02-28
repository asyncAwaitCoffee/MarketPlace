using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceLibrary.Models
{
    public class MarketItem
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal PriceStart { get; set; }
        public decimal PriceCurrent { get; set; }
        public decimal PriceEnd { get; set; }
        public byte Category { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int OwnerId { get; set; }

        public string Description { get; set; }
        public decimal BidStep { get; set; }

        // Constructor
        public MarketItem(int id, string title, decimal startPrice, byte category, DateTime dateStart, int ownerId)
        {
            Id = id;
            Title = title;
            PriceStart = startPrice;
            Category = category;
            DateStart = dateStart;
            OwnerId = ownerId;
        }
    }
}
