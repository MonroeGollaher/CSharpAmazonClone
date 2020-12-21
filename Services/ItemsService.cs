using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
  public class ItemsService
  {
    private readonly ItemsRepository _repo;
    public ItemsService(ItemsRepository repo)
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

    internal string DeleteItem(int id)
    {
      if(_repo.DeleteItem(id))
      {
        return "The item has been deleted";
      }
      return "The item could not be deleted";
    }
  }
}