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

    internal Item GetById(int id)
    {
      return _repo.GetById(id);
    }

    internal Item EditItem(Profile userInfo, Item editedItem)
    {
      Item oldItem = _repo.GetById(editedItem.Id);
      if ( oldItem == null)
      {
        throw new Exception("Bad Id");
      }
      if( oldItem.CreatorId != userInfo.Id)
      {
        throw new Exception("You are not the original poster : Access denied");
      }
      _repo.EditItem(editedItem);
      return _repo.GetById(editedItem.Id);
    }

    internal IEnumerable<Item> GetItemsByProfile(string profId, string userId)
    {
      return _repo.GetItemsByProfile(profId).ToList().FindAll(i => i.CreatorId == userId || i.IsAvailable);
    }
  }
}