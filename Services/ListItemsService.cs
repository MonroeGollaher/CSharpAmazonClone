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
  }
}