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
    private static readonly UserRepository _ur = new UserRepository();
    private static readonly StoreRepository _str = new StoreRepository();
    private static readonly ToppingRepository _tr = new ToppingRepository();
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly PizzeriaSingleton _ps = PizzeriaSingleton.Instance;
    private static readonly OrderSingleton _os = OrderSingleton.Instance;

    private static void Main(string[] args)
    {
      //GetAllPizzas();
      //PostAllPizzas();
      //PostOrder();

      Console.WriteLine("User = 1");
      int uors = int.Parse(Console.ReadKey().KeyChar.ToString());
      if(uors == 8)
      {
        int sChoice = 1;
        do
        {
          var Store = _str.StoreLogin();

          Console.WriteLine("Orders = 1");
          Console.WriteLine("Inventory = 2");
          Console.WriteLine("Exit = !(1 || 2)");
          sChoice = int.Parse(Console.ReadKey().KeyChar.ToString());

          
          if(sChoice == 1)
          {
            GetStuff();
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
          }
          else if(sChoice == 2)
          {
            Console.WriteLine("Inventory Pending");
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
          }

        }
        while(sChoice == 1 || sChoice == 2);
      


      User currUser = _ur.VerifyLogin();
      
      
      Console.WriteLine("Order = 1");
      Console.WriteLine("Past Orders = 2");
      Console.WriteLine("Exit = !(1 || 2)");
      int uChoice = int.Parse(Console.ReadKey().KeyChar.ToString());
      if(uChoice == 1)
      {

        Console.WriteLine("Order");  
        Order no = new Order();
        Store storeC = _str.ChooseStore();

        _os.Post(currUser, storeC, no.OrderId, no.TimeOfOrder);
        int another = 1;
        int pm = 1;
        do
        {
          Console.WriteLine("Pizza {0}", pm);
          Size sizeC = _sr.ChooseSize();
          Crust crustC = _cr.ChooseCrust();
          List<Topping> tops = _tr.ChooseTops();

          _ps.Post(crustC, sizeC, tops, no.OrderId);
          
          Console.WriteLine("Another? 1 = Yes 0 = No");
          another = int.Parse(Console.ReadKey().KeyChar.ToString());

          pm++;

        }
        while(another == 1);
      }
      else if(uChoice == 2)
      {
        _pr.PastOrders(currUser.UserId);

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
      }

    }
    }  
    private static void GetStuff()
    {
      //var p = _str.GetStoreOrders();
      foreach(var i in _str.GetStoreOrders())
      {
        Console.WriteLine("{0}", i.StoreAddress);
        foreach(var j in i.Orders)
        {
          Console.WriteLine("{0}", j.TimeOfOrder);
        }
      }
    }

    private static void GetAllPizzas()
    {
      foreach (var p in _ps.Get())
      {
        Console.WriteLine(p);
      }
    }

    private static void PostAllPizzas(long orderId)
    {
      var crusts = _cr.Get(); // _db1
      var sizes = _sr.Get(); // _db2
      var toppings = _tr.Get(); // _db3


      _ps.Post(crusts[0], sizes[0], toppings, orderId);
    }

    private static void PostOrder(long orderId, DateTime dt)
    {
      var store = _str.Get(); // _db1
      var user = _ur.Get(); // _db2
      _os.Post(user[2], store[2], orderId, dt);
    }

    // public User UorS()
    // {
    //   Console.Write("New?");

    //     Console.Write("New?");
    //     int x = int.Parse(Console.ReadKey().KeyChar.ToString());
    //     if(x == 1)
    //     {
    //       User newt = User.NewUser();
    //       _ur.Post(newt);
    //       return newt;
    //     }
    //     else
    //     {
    //       User user = _ur.VerifyLogin();
    //       return user;
    //     }
    //   }
    //   else if(x == 0)
    //   {
    //     return new User();
    //   }
    //   else
    //   {
    //     UorS();
    //     return new User();
    //   }
    // }
  }
}
