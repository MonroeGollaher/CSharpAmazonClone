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

    internal List GetById(int id)
    {
      string sql = @"
      SELECT * FROM lists
      WHERE id = @Id
      LIMIT 1";
      return _db.QueryFirstOrDefault<List>(sql, new { id });
    }

    internal bool DeleteList(int id)
    {
      string sql = @"
      DELETE FROM lists
      WHERE id = @Id
      LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal void EditList(List editedList)
    {
      string sql = @"
      UPDATE lists
      SET
      title = @Title,
      isPublished = @IsPublished
      WHERE id = @Id;";
      _db.Execute(sql, editedList);
    }

    internal object GetLists()
    {
      string sql = populateCreator;
      return _db.Query<List, Profile, List>(sql, (list, profile) => { list.Creator = profile; return list; }, splitOn: "id");
    }
  }
}