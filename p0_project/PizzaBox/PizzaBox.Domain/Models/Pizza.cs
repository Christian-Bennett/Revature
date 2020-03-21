using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public long PizzaId { get; set; }
    public decimal Price
    {
      get
      {
        if (Crust == null || Size == null || PizzaToppings == null)
        {
          return 0;
        }

        return Crust.Price + Size.Price + PizzaToppings.Sum(pt => pt.Topping.Price);
      }
    }

    #region NAVIGATIONAL PROPERTIES

    public Crust Crust { get; set; }
    public long CrustId { get; set; }
    public Size Size { get; set; }
    public long SizeId { get; set; }
    public Order Order { get; set; }
    public long OrderId { get; set; }
    public List<PizzaTopping> PizzaToppings { get; set; }

    #endregion

    public Pizza()
    {
      PizzaId = DateTime.Now.Ticks;
    }

    public override string ToString()
    {
      return $"{PizzaId}  {Crust.Name ?? "N/A"} {Size.Name ?? "N/A"} {PizzaToppings.Count} {Price}";
    }
  }
}
