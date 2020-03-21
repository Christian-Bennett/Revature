using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Databases;
using PizzaBox.Domain.Models;
using System;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public List<User> Get()
    {
      return _db.User.ToList();
    }

    public User Get(long id)
    {
      return _db.User.SingleOrDefault(u => u.UserId == id);
    }

    public User VerifyLogin()
    {
      Console.Write("Please enter your UserName ");
      string uname = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter your Password ");
      string upass = Console.ReadLine();
      Console.WriteLine();

      if(_db.User.Single(u => u.UserName == uname) != null)
      {
        if(_db.User.Single(u => u.UserName == uname).UserPass == upass)
        {
          Console.Write("Welcome back {0}", uname);
          Console.WriteLine();
          return _db.User.Single(u => u.UserName == uname);
        }
        else
        {
          Console.Write("Username or Password Incorrect");
          VerifyLogin();
          return new User();
        }
      }
      else
      {
        Console.Write("Username or Password Incorrect");
        VerifyLogin();
        return new User();
      }
        
    }

    public bool Post(User User)
    {
      _db.User.Add(User);
      return _db.SaveChanges() == 1;
    }

    public bool Put(User User)
    {
      User u = Get(User.UserId);

      u = User;
      return _db.SaveChanges() == 1;
    }
  }
}
