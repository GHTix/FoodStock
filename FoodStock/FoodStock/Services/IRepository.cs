using System;
using System.Collections.Generic;
using System.Text;

namespace FoodStock.Services
{
    public interface IRepository<T, Key>
    {
        IEnumerable<T> GetItems();
        T GetItem(Key key);
        void AddItem(T item);
        void UpdateItem(Key key, T item);
        void DeleteItem(Key key);
    }
}
