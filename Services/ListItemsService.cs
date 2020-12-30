using System;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
  public class ListItemsService
  {
    private readonly ListItemsRepository _repo;

    public ListItemsService(ListItemsRepository repo)
    {
        _repo = repo;
    }
    public ListItem CreateListItem(ListItem newLi)
    {
      newLi.Id = _repo.CreateListItem(newLi);
      return newLi;
    }

    internal object GetItemsByList(int id)
    {
        return _repo.GetItemsByList(id);
    }

    internal object GetAllListItems()
    {
      return _repo.GetAllListItems();
    }

    internal string DeleteListItem(int id)
    {
      if(_repo.DeleteListItem(id))
      {
        return "The list item has been deleted";
      }
      return "The list item could not be deleted";
    }
  }
}