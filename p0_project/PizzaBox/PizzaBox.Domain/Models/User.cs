using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string UserPass { get; set; }
    public string UserAddress { get; set; }
    public string UserCity { get; set; }
    public string UserState { get; set; }
    public string UserZip { get; set; }
    public List<Order> Orders { get; set; }

    public User()
    {
      UserId = DateTime.Now.Ticks;
    }

    public static User NewUser()
    {
      User nu = new User();
      nu.GetInfo();

      //Check

      Console.Write("Please enter a Username: ");
      nu.UserName = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter a Password: ");
      string t1pass = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter a Password: ");
      string t2pass = Console.ReadLine();
      Console.WriteLine();
      if(t1pass == t2pass){nu.UserPass = t1pass;}

      return nu; 

    }

    public void GetInfo()
    {
      Console.Write("Please enter your first name: ");
      this.FirstName = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter your last name: ");
      this.LastName = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter your Street Address name: ");
      this.UserAddress = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter your City: ");
      this.UserCity = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter your State: ");
      this.UserState = Console.ReadLine();
      Console.WriteLine();
      Console.Write("Please enter your Zip Code: ");
      this.UserZip = Console.ReadLine();
      Console.WriteLine();
    }

    



  }
}