using System.Collections.Generic;
using System;
using System.Linq;

namespace Delegates.Models
{
  public class ShoppingCartModel
  {
    public delegate void MentionDiscount(decimal mentionDiscount);
    public List<ProductModel> Items { get; set; } = new List<ProductModel>();

    public decimal GenTotal(MentionDiscount mentionDiscount, Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal, Action<string> alertDiscounting)
    {
        decimal subTotal = Items.Sum(x => x.Price);

        mentionDiscount(subTotal);

        alertDiscounting("We are applying your discount...");

        return calculateDiscountedTotal(Items, subTotal);
    }
  }
}