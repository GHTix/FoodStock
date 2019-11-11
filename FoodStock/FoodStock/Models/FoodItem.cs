using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStock.Models
{

    public enum StorageLocation
    {
        Fridge,
        Freezer,
        Cabinet
    }

    public class FoodItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public DateTime? UseByDate { get; set; }
        public StorageLocation Location { get; set; }
    }
}
