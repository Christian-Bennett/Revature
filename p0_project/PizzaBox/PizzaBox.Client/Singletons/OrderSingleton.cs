using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class OrderSingleton
  {
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly OrderSingleton _os = new OrderSingleton();

    public static OrderSingleton Instance
    {
      get
      {
        return _os;
      }
    }

    private OrderSingleton() { }

    public Order Get(long id)
    {
      return _or.Get(id);
    }

    public bool Post(User user, Store store, long orderId, DateTime dt)
    {
      var o = new Order(orderId, dt){ UserId = user.UserId, StoreId = store.StoreId };

      user.Orders = new List<Order> { o };
      store.Orders = new List<Order> { o };


      return _or.Post(o);
    }
  }
}