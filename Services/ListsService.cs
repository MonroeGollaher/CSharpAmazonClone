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

    internal object DeleteList(int id)
    {
      if(_repo.DeleteList(id))
      {
        return "List deleted";
      }
      return "List couldn't be deleted";
    }

    internal object GetById(int id)
    {
      return _repo.GetById(id);
    }

    internal List EditList(Profile userInfo, List editedList)
    {
      List oldList = _repo.GetById(editedList.Id);
      if (oldList == null)
      {
        throw new Exception("Bad Id");
      }
      if (oldList.CreatorId != userInfo.Id)
      {
        throw new Exception("You are not the original poster : Access denied");
      }
      _repo.EditList(editedList);
      return _repo.GetById(editedList.Id);

    }
  }
}