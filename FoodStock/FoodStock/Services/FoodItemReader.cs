using FoodStock.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FoodStock.Services
{
    public class FoodItemReader : IRepository<FoodItem, long>
    {

        List<FoodItem> _items;

        static DateTime GetRandomDate(Random rnd,int minDays,int maxDays)
        {
            DateTime now = DateTime.UtcNow;
            
            TimeSpan ts = new TimeSpan(rnd.Next(minDays, maxDays), 0, 0, 0);
            return now + ts;
        }


        public FoodItemReader()
        {
            Random rnd = new Random(DateTime.UtcNow.Millisecond);
            _items = new List<FoodItem>();
            _items.Add(new FoodItem { Id = 1, Name = "One", Location = StorageLocation.Fridge, PurchasedDate = GetRandomDate(rnd,-10,0), UseByDate = GetRandomDate(rnd, 2,30) });
            _items.Add(new FoodItem { Id = 2, Name = "Two", Location = StorageLocation.Freezer, PurchasedDate = GetRandomDate(rnd, -10, 0), UseByDate = GetRandomDate(rnd, 2, 30) });
            _items.Add(new FoodItem { Id = 3, Name = "Three", Location = StorageLocation.Fridge, PurchasedDate = GetRandomDate(rnd, -10, 0), UseByDate = GetRandomDate(rnd, 2, 30) });
            //_items.Add(new FoodItem { Id = 4, Name = "Four", Location = StorageLocation.Fridge, PurchasedDate = GetRandomDate(rnd, -10, 0), UseByDate = GetRandomDate(rnd, 2, 30) });
            //_items.Add(new FoodItem { Id = 5, Name = "Five", Location = StorageLocation.Cabinet, PurchasedDate = GetRandomDate(rnd, -10, 0), UseByDate = GetRandomDate(rnd, 2, 30) });
            //_items.Add(new FoodItem { Id = 6, Name = "Six", Location = StorageLocation.Fridge, PurchasedDate = GetRandomDate(rnd, -10, 0), UseByDate = GetRandomDate(rnd, 2, 30) });
            //_items.Add(new FoodItem { Id = 7, Name = "Seven", Location = StorageLocation.Fridge, PurchasedDate = GetRandomDate(rnd, -10, 0), UseByDate = GetRandomDate(rnd, 2, 30) });
            //_items.Add(new FoodItem { Id = 8, Name = "Eight", Location = StorageLocation.Cabinet, PurchasedDate = GetRandomDate(rnd, -10, 0), UseByDate = GetRandomDate(rnd, 2, 30) });
        }



        public void AddItem(FoodItem item)
        {
            item.Id = _items.Max(x => x.Id) + 1;
            _items.Add(item);
        }

        public void DeleteItem(long key)
        {
            _items.Remove(GetItem(key));
        }

        public FoodItem GetItem(long key)
        {
            return _items.FirstOrDefault(x => x.Id == key);
        }

        public IEnumerable<FoodItem> GetItems()
        {
            return _items;
        }

        public void UpdateItem(long key, FoodItem item)
        {
            var updatedItem = GetItem(key);
            updatedItem = item;

        }
    }
}
