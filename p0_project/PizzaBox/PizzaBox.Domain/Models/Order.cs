using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public long OrderId { get; set; }
    public DateTime TimeOfOrder { get; set; }
    public List<Pizza> Pizzas { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public Store Store { get; set; }
    public long StoreId { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }

    #endregion

    public Order()
    {
      OrderId = DateTime.Now.Ticks;
      TimeOfOrder = DateTime.Now;
    }

    public Order(long orderId, DateTime dt)
    {
      OrderId = orderId;
      TimeOfOrder = dt;
    }
  }
}