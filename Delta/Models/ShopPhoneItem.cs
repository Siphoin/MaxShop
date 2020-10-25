using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Models
{
    public class ShopPhoneItem
    {
        public int Id { get; set; }
     public   Phone phone { get; set; }
        public int Price { get; set; }

        public string ShopCartId { get; set; }
    }
}
