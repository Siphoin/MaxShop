using MaxShop.Delta;
using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Controllers
{
    public class OrderController : Controller
    {
            
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.allOrders = allOrders;
        }

        public IActionResult CheckOut ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.listShopPhoneItems = shopCart.GetShopItems();
            if (shopCart.listShopPhoneItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete ()
        {
            ViewBag.Message = "Заказ успешно обработан и добавлен.";
            return View();
        }

    }
}
