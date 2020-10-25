using MaxShop.Delta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Interfaces
{
  public  interface IAllPhones
    {
        IEnumerable<Phone> Phones { get;}
        IEnumerable<Phone> FavoritesPhones { get; }
        Phone GetObjectPhone(int phoneId);
    }
}
