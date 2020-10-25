using MaxShop.Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxShop.Delta
{
    public class AppDbContent : DbContext
    {
        public AppDbContent (DbContextOptions<AppDbContent> options) : base(options)
        {

        }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<ShopPhoneItem> ShopPhoneItem { get; set; }


        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
