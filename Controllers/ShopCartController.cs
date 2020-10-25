using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using MaxShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MaxShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllPhones _phoneRep;
        private readonly ShopCart _shopCart;

        public ShopCartController (IAllPhones phoneRepository, ShopCart shopCart)
        {
            _phoneRep = phoneRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index ()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopPhoneItems = items;
            var obj = new ShopCartViewModel(_shopCart);
            return View(obj);
        }

        public RedirectToActionResult AddToCart (int id)
        {
            var item = _phoneRep.Phones.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
