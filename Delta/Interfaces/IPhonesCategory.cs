using MaxShop.Delta.Models;
using System.Collections.Generic;

namespace MaxShop.Delta.Interfaces
{
   public interface IPhonesCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
