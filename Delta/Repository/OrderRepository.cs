using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDbContent appDBContent;
        private readonly ShopCart shopCart;

        public OrderRepository ()
        {

        }

        public OrderRepository (AppDbContent appDBContent, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.appDBContent = appDBContent;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopPhoneItems;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail(item.phone.Id, item.phone.Price, order.Id);
                appDBContent.OrderDetails.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
