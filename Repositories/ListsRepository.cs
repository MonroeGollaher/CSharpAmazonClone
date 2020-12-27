using System;
using System.Data;
using Amazen.Models;
using Dapper;

namespace Amazen.Repositories
{
  public class ListsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT list.*, profile.* FROM lists list INNER JOIN profiles profile ON list.creatorId = profile.id ";

    public ListsRepository(IDbConnection db)
    {
        _db = db;
    }
    public int CreateList(List newList)
    {
      string sql = @"
      INSERT INTO lists
      (title, isPublished, id, creatorId)
      VALUES
      (@Title, @IsPublished, @Id, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newList);
    }

    internal object GetLists()
    {
      string sql = populateCreator;
      return _db.Query<List, Profile, List>(sql, (list, profile) => { list.Creator = profile; return list; }, splitOn: "id");
    }
  }
}