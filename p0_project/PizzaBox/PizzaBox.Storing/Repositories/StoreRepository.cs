using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Databases;
using PizzaBox.Domain.Models;
using System;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public List<Store> Get()
    {
      return _db.Store.ToList();
    }

    public Store Get(long id)
    {
      return _db.Store.SingleOrDefault(st => st.StoreId == id);
    }

    public Store ChooseStore()
    {
      var storeList = Get();

      for(int i = 0; i <= storeList.Count - 1; i++)
      {
        Console.WriteLine("Option {0} {1} {2}", i + 1, storeList[i].StoreAddress, storeList[i].StoreCity);
      }
      int stChoice = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
      Store storeC = storeList[stChoice];
      Console.WriteLine();

      return storeC;


    }

    public List<Store> GetStoreOrders()
    {
      // Console.Write("Please enter your store Address: ");
      // string addr = Console.ReadLine();
      // Console.WriteLine();
      return _db.Store.Include(s => s.Orders).ToList();
    }

    public bool Post(Store Store)
    {
      _db.Store.Add(Store);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Store Store)
    {
      Store st = Get(Store.StoreId);

      st = Store;
      return _db.SaveChanges() == 1;
    }

    public Store StoreLogin()
    {
      Console.WriteLine("Store Login");
      Get();
      Console.Write("Enter Store Address:");
      string sname = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Enter Store Zip:");
      string spass = Console.ReadLine();

      if(_db.Store.Single(s => s.StoreAddress == sname) != null)
      {
        if(_db.Store.Single(s => s.StoreAddress == sname).StoreZip == spass)
        {
          Console.Write("Welcome back {0}", sname);
          Console.WriteLine();
          return _db.Store.Single(s => s.StoreAddress == sname);
        }
        else
        {
          Console.Write("Username or Password Incorrect");
          StoreLogin();
          return new Store();
        }
      }
      else
      {
        Console.Write("Username or Password Incorrect");
        StoreLogin();
        return new Store();
      }
    }
  }
}
