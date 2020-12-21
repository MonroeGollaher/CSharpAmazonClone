using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Amazen.Models;

namespace Amazen.Repositories
{
  public class ItemRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT item.*, profile.* FROM items item INNER JOIN profiles profile ON item.creatorId = profile.id ";
    public ItemRepository(IDbConnection db)
    {
        _db = db;
    }

    public int CreateItem(Item newItem)
    {
      string sql = @"
      INSERT INTO items
      (title, body, image, price, salePrice, quantity, isAvailable, isPublished, id, creatorId)
      VALUES
      (@Title, @Body, @Image, @Price, @SalePrice, @Quantity, @IsAvailable, @IsPublished, @Id, @CreatorId);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newItem);
    }

    internal object GetItems()
    {
      string sql = populateCreator + "WHERE isPublished = 1";
      return _db.Query<Item, Profile, Item>(sql, (item, profile) => { item.Creator = profile; return item; }, splitOn: "id");
    }
  }
}