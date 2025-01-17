﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace MasterDetailSampleApp.Models
{
   public class ItemRepository : IItemRepository
   {
      private static readonly ConcurrentDictionary<string, Item> items =
         new ConcurrentDictionary<string, Item>();

      public ItemRepository()
      {
         Add(new Item {Id = Guid.NewGuid().ToString(), Text = "Item 1", Description = "This is an item description."});
         Add(new Item {Id = Guid.NewGuid().ToString(), Text = "Item 2", Description = "This is an item description."});
         Add(new Item {Id = Guid.NewGuid().ToString(), Text = "Item 3", Description = "This is an item description."});
      }

      public IEnumerable<Item> GetAll() => items.Values;

      public void Add(Item item)
      {
         item.Id = Guid.NewGuid().ToString();
         items[item.Id] = item;
      }

      public Item Get(string id)
      {
         Item item;
         items.TryGetValue(id, out item);

         return item;
      }

      public Item Remove(string id)
      {
         Item item;
         items.TryRemove(id, out item);

         return item;
      }

      public void Update(Item item)
      {
         items[item.Id] = item;
      }
   }
}