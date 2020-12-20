using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
  public class ItemService
  {
    private readonly ItemRepository _repo;
    public ItemService(ItemRepository repo)
    {
        _repo = repo;
    }
    public Item CreateItem(Item newItem)
    {
      newItem.Id = _repo.CreateItem(newItem);
      return newItem;
    }

    internal object GetItems()
    {
      return _repo.GetItems();
    }
  }
}