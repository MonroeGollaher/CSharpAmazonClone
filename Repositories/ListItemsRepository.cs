using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Amazen.Models;

namespace Amazen.Repositories
{
  public class ListItemsRepository
  {
    private readonly IDbConnection _db;

    public ListItemsRepository(IDbConnection db)
    {
        _db = db;
    }
    public int CreateListItem(ListItem newLi)
    {
      string sql = @"
      INSERT INTO listitems
      (listId, itemId, creatorId, id)
      VALUES
      (@ListId, @ItemId, @CreatorId, @Id);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newLi);
    }

    internal object GetItemsByList(int listId)
    {
      string sql =@"
      SELECT item.*,
      listitem.id as ListItemId,
      profile.*
      FROM listitems listitem
      JOIN items item
      ON item.id = listitem.itemId
      JOIN profiles profile
      ON profile.id = item.creatorId
      WHERE listId = @ListId;";
      return _db.Query<ListItemViewModel, Profile, ListItemViewModel>(sql, (item, profile) => {item.Creator = profile; return item; }, new { listId }, splitOn: "id");
    }
  }
}