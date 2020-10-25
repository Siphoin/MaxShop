using MaxShop.Delta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.ViewModels
{
    public class PhonesListVewModel
    {
        public IEnumerable<Phone> AllPhones { get; set; }

        public string currCategory { get; set; }

    }
}
