using System;
using System.Collections.Generic;
using Catalog.Models;

namespace Catalog.Interfaces
{
    public interface IInMemItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
    }
}   