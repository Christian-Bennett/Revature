using System;
using System.Threading;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Book : AAudio
  {
    public delegate void CasingDelegate(string s);
    public delegate string CasingDelegate2();
    public event CasingDelegate BookEvent;


    public void Read(HowToRead r)
    {
      var text = "Read The Book";

      switch(r)
      {
        case HowToRead.Upper:
          Console.WriteLine(text.ToUpperInvariant());
          break;
        
        case HowToRead.Lower:
          Console.WriteLine(text.ToLowerInvariant());
          break;
      }
    }

    public void ReadAction(Action<string> d)
    {
      var text = "read from action";

      d(text);
    }

    public void ReadFunction(Func<string, string> d)
    {
      var text = "read form function";

      d(text);
    }

    public void ReadDelegate(CasingDelegate d)
    {
      var text = "read from delegate";

      d(text);
    }

    public void ReadDelegate2(CasingDelegate2 d)
    {
      Console.WriteLine(d());
    }

    public void Open()
    {
      if (BookEvent != null)
      {
        
      }

      var count = 0;

        while (count < 10)
        {
          this.BookEvent("someone opened a book");
          Thread.Sleep(1000);
          count += 1;
        }
    }
  }

  public enum HowToRead
  {
    Upper,
    Lower
  }
}
