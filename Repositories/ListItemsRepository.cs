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
    private readonly string populateCreator = "SELECT listItem.*, profile.* FROM listItems listItem INNER JOIN profiles profile ON listItem.creatorId = profile.id";

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

    internal bool DeleteListItem(int id)
    {
      string sql = @"
      DELETE from listitems
      WHERE id = @Id
      LIMIT 1";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal object GetAllListItems()
    {
      string sql = populateCreator;
      return _db.Query<ListItem, Profile, ListItem>(sql, (ListItem, profile) => { ListItem.Creator = profile; return ListItem; }, splitOn: "id");
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