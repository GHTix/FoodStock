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

        public FoodItemReader()
        {
            _items = new List<FoodItem>();
            _items.Add(new FoodItem { Id = 1, Name = "One", Location = StorageLocation.Fridge, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
            _items.Add(new FoodItem { Id = 2, Name = "Two", Location = StorageLocation.Freezer, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
            _items.Add(new FoodItem { Id = 3, Name = "Three", Location = StorageLocation.Fridge, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
            _items.Add(new FoodItem { Id = 4, Name = "Four", Location = StorageLocation.Fridge, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
            _items.Add(new FoodItem { Id = 5, Name = "Five", Location = StorageLocation.Cabinet, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
            _items.Add(new FoodItem { Id = 6, Name = "Six", Location = StorageLocation.Fridge, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
            _items.Add(new FoodItem { Id = 7, Name = "Seven", Location = StorageLocation.Fridge, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
            _items.Add(new FoodItem { Id = 8, Name = "Eight", Location = StorageLocation.Cabinet, PurchasedDate = DateTime.UtcNow, UseByDate = DateTime.UtcNow });
        }


        public long NewId
        {
            get
            {
                return _items.Max(x => x.Id) + 1;
            }

        }

        public void AddItem(FoodItem item)
        {
            _items.Add(item);
            //throw new NotImplementedException();
        }

        public void DeleteItem(long key)
        {
            throw new NotImplementedException();
        }

        public FoodItem GetItem(long key)
        {
            return _items.FirstOrDefault(x => x.Id == key);

            //throw new NotImplementedException();
        }

        public IEnumerable<FoodItem> GetItems()
        {
            return _items;
        }

        public void UpdateItem(long key, FoodItem item)
        {
            var updatedItem = GetItem(key);
            updatedItem = item;

            //throw new NotImplementedException();
        }
    }
}
