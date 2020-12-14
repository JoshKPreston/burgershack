using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class BurgerService
  {
    private readonly BurgerRepository _br;

    public BurgerService(BurgerRepository burgerRepository)
    {
        _br = burgerRepository;
    }
    public IEnumerable<Burger> Get()
    {
        return _br.Get();
    }
    public Burger Create(Burger burger)
    {
        return _br.Create(burger);
    }
    public Burger GetById(int id)
    {
        Burger foundBurger = _br.GetById(id);
        if (foundBurger == null)
        {
            throw new Exception("There is no burger with that id");
        }
        return foundBurger;
    }
    public string Delete(int id)
    {
        if (_br.Delete(id))
        {
            return "Burger thrown away!";
        }
        throw new Exception("Burger still here... <.<");
    }
  }
}