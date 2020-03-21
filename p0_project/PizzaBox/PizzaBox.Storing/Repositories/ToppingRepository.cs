using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Databases;
using PizzaBox.Domain.Models;
using System;

namespace PizzaBox.Storing.Repositories
{
  public class ToppingRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public List<Topping> Get()
    {
      return _db.Topping.ToList();
    }

    public Topping Get(long id)
    {
      return _db.Topping.SingleOrDefault(p => p.ToppingId == id);
    }

    public List<Topping> ChooseTops()
    {
      var toppings = Get();

      Console.WriteLine("Toppings");

      List<Topping> tops = new List<Topping>();

      while(tops.Count <= 1)
      {
        for(int i = 0; i <= toppings.Count - 1; i++)
        {
          Console.WriteLine("Option {0} {1}", i + 1, toppings[i].Name);
        }

        int tChoice = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
        tops.Add(toppings[tChoice]);
        toppings.RemoveAt(tChoice);
        Console.WriteLine();
      }
      return tops;
    }

    public bool Post(Topping Topping)
    {
      _db.Topping.Add(Topping);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Topping Topping)
    {
      Topping p = Get(Topping.ToppingId);

      p = Topping;
      return _db.SaveChanges() == 1;
    }
  }
}
