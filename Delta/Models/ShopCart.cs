using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MaxShop.Delta.Models
{
    public class ShopCart
    {
        public int Id { get; set; }

        public string ShopCartId { get; set; }
        public List<ShopPhoneItem> listShopPhoneItems { get; set; }

        private readonly AppDbContent appDbContent;

        public ShopCart(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public static ShopCart GetCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartID = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartID);

            return new ShopCart(context) {ShopCartId = shopCartID };
        }

        public void AddToCart (Phone phone)
        {
            appDbContent.ShopPhoneItem.Add(new ShopPhoneItem
            {
                ShopCartId = ShopCartId,
                phone = phone,
                Price = phone.Price 

            });

            appDbContent.SaveChanges();
        }

        public List<ShopPhoneItem> GetShopItems ()
        {
            return appDbContent.ShopPhoneItem.Where(c => c.ShopCartId == ShopCartId).Include(f => f.phone).ToList();
        }
    }
}
