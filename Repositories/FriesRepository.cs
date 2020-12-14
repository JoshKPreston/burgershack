using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class FriesRepository
  {
    private readonly IDbConnection _db;

    public FriesRepository(IDbConnection db)
    {
        _db = db;
    }
    public IEnumerable<Fries> Get()
    {
        string sql = "SELECT * FROM fries";
        return _db.Query<Fries>(sql);
    }
    public Fries Create(Fries fries)
    {
        string sql = @"INSERT INTO fries
            (title, description, isBacon)
            VALUES
            (@Title, @Description, @IsBacon);
            SELECT LAST_INSERT_ID();";
        fries.Id = _db.ExecuteScalar<int>(sql, fries);
        return fries;
    }
    public Fries GetById(int id)
    {
        string sql = "SELECT * FROM fries WHERE id = @Id";
        return _db.QueryFirstOrDefault<Fries>(sql, new { id });
    }
    public bool Delete(int id)
    {
        string sql = "DELETE FROM fries WHERE id = @Id LIMIT 1";
        int affectedRows = _db.Execute(sql, new { id });
        return affectedRows > 0;
    }
  }
}