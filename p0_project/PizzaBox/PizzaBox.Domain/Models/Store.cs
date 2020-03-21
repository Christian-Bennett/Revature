using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    public long StoreId { get; set; }
    public string StoreAddress { get; set; }
    public string StoreCity { get; set; }
    public string StoreState { get; set; }
    public string StoreZip { get; set; }
    public List<Order> Orders { get; set; }
    public Store()
    {
      StoreId = DateTime.Now.Ticks;
    }
  }
}