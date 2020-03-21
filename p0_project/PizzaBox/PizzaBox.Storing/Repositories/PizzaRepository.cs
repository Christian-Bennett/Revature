using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public List<Pizza> Get()
    {
      return _db.Pizza.Include(p => p.Crust).Include(p => p.Size).Include(p => p.PizzaToppings).ToList();
    }

    public List<Pizza> GetPizzas()
    {
      return _db.Pizza.ToList();
    }

    public Pizza Get(long id)
    {
      return _db.Pizza.FirstOrDefault();
    }

    public bool Post(Pizza pizza)
    {
      _db.Pizza.Add(pizza);
      return _db.SaveChanges() == 1;
    }

    public void PastOrders(long uid)
    {
      Console.WriteLine("Past Orders");
      long oid = 0;
      foreach(var i in _db.Pizza
      .Include(p => p.Order)
      .Include(p => p.Crust)
      .Include(p => p.Size)
      .Include(p => p.PizzaToppings)
      .Where(p => p.Order.UserId == uid).ToList())
      {
        if(oid != i.OrderId)
        {
          Console.WriteLine("Order #{0}", i.OrderId);
          Console.WriteLine("Pizza details {0} {1} {2}", i.Size.Name, i.Crust.Name, i.Price);
          oid = i.OrderId;
        }
        else
        {
          Console.WriteLine("Pizza details {0} {1} {2}", i.Size.Name, i.Crust.Name, i.Price);
        }
      }
    }

    public bool Put(Pizza pizza)
    {
      Pizza p = Get(pizza.PizzaId);

      p = pizza;
      return _db.SaveChanges() == 1;
    }

  }
}
