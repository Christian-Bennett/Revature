using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class SizeRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public List<Size> Get()
    {
      return _db.Size.ToList();
    }

    public Size Get(long id)
    {
      return _db.Size.SingleOrDefault(p => p.SizeId == id);
    }

    public Size ChooseSize()
    {
      var sizes = Get();

      for(int i = 0; i <= sizes.Count - 1; i++)
      {
        Console.WriteLine("Option {0} {1}", i + 1, sizes[i].Name);
      }
      int sChoice = int.Parse(Console.ReadKey().KeyChar.ToString()) - 1;
      Size sizeC = sizes[sChoice];
      Console.WriteLine();


      return sizeC;
    }

    public bool Post(Size Size)
    {
      _db.Size.Add(Size);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Size Size)
    {
      Size p = Get(Size.SizeId);

      p = Size;
      return _db.SaveChanges() == 1;
    }
  }
}
