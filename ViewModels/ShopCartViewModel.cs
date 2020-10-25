using MaxShop.Delta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart shopCart { get; set; }

        public ShopCartViewModel ()
        {

        }

        public ShopCartViewModel (ShopCart shopCart)
        {
            this.shopCart = shopCart;
        }
    }
}
