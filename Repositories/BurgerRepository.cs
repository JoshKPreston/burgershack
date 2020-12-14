using System;
using System.Collections.Generic;
using System.Data;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
        _db = db;
    }
    public IEnumerable<Burger> Get()
    {
        string sql = "SELECT * FROM burgers";
        return _db.Query<Burger>(sql);
    }
    public Burger Create(Burger burger)
    {
        string sql = @"INSERT INTO burgers
            (title, description, isBacon)
            VALUES
            (@Title, @Description, @IsBacon);
            SELECT LAST_INSERT_ID();";
        burger.Id = _db.ExecuteScalar<int>(sql, burger);
        return burger;
    }
    public Burger GetById(int id)
    {
        string sql = "SELECT * FROM burgers WHERE id = @Id";
        return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }
    public bool Delete(int id)
    {
        string sql = "DELETE FROM burgers WHERE id = @Id LIMIT 1";
        int affectedRows = _db.Execute(sql, new { id });
        return affectedRows > 0;
    }
  }
}