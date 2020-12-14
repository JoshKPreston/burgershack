using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;

namespace burgershack.Services
{
  public class FriesService
  {
    private readonly FriesRepository _fr;

    public FriesService(FriesRepository friesRepository)
    {
        _fr = friesRepository;
    }
    public IEnumerable<Fries> Get()
    {
        return _fr.Get();
    }
    public Fries Create(Fries fries)
    {
        return _fr.Create(fries);
    }
    public Fries GetById(int id)
    {
        Fries foundFries = _fr.GetById(id);
        if (foundFries == null)
        {
            throw new Exception("There is no fries with that id");
        }
        return foundFries;
    }
    public string Delete(int id)
    {
        if (_fr.Delete(id))
        {
            return "Fries thrown away!";
        }
        throw new Exception("Fries still here... <.<");
    }
  }
}