using MaxShop.Delta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Phone> FavoritePhones { get; set; }

        public HomeViewModel ()
        {

        }

        public HomeViewModel (IEnumerable<Phone> favPhones)
        {
            FavoritePhones = favPhones;
        }
    }
}
