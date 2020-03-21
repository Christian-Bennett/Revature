using System;
using System.Collections.Generic;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static readonly CrustRepository _cr = new CrustRepository();
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly SizeRepository _sr = new SizeRepository();
    private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;

    private static void Main(string[] args)
    {
      //GetAllPizzas();
      PostAllPizzas();
    }

    private static void GetAllPizzas()
    {
      foreach (var p in _ps.Get())
      {
        Console.WriteLine(p);
      }
    }

    private static void PostAllPizzas()
    {
      var crusts = _cr.Get(); // _db1
      var sizes = _sr.Get(); // _db2

      _ps.Post(crusts[0], sizes[0], null);
    }
  }
}
