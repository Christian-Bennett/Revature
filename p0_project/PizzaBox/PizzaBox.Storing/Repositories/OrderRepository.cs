using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Databases;
using PizzaBox.Domain.Models;
using System;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public Order Get(long id)
    {
      return _db.Order.SingleOrDefault(p => p.OrderId == id);
    }

    public bool Post(Order Order)
    {
      _db.Order.Add(Order);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Order Order)
    {
      Order o = Get(Order.OrderId);

      o = Order;
      return _db.SaveChanges() == 1;
    }
  }
}
