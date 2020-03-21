using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  public class PizzeriaSingleton
  {
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static readonly PizzeriaSingleton _ps = new PizzeriaSingleton();

    public static PizzeriaSingleton Instance
    {
      get
      {
        return _ps;
      }
    }

    private PizzeriaSingleton() { }

    public List<Pizza> Get()
    {
      return _pr.Get();
    }

    public bool Post(Crust crust, Size size, List<Topping> toppings, long orderId)
    {
      var p = new Pizza(){ CrustId = crust.CrustId, SizeId = size.SizeId, OrderId = orderId};

      crust.Pizzas = new List<Pizza> { p };
      size.Pizzas = new List<Pizza> { p };
      List<PizzaTopping> pt = new List<PizzaTopping>();
      toppings.ForEach(t => pt.Add(new PizzaTopping(){ PizzaId = p.PizzaId, ToppingId = t.ToppingId}));
      p.PizzaToppings = pt;



      return _pr.Post(p);
    }
  }
}