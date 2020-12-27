using System;
using Amazen.Models;
using Amazen.Repositories;

namespace Amazen.Services
{
  public class ListsService
  {
    private readonly ListsRepository _repo;
    public ListsService(ListsRepository repo)
    {
        _repo = repo;
    }
    public List CreateList(List newList)
    {
      newList.Id = _repo.CreateList(newList);
      return newList;
    }

    internal object GetLists()
    {
      return _repo.GetLists();
    }
  }
}