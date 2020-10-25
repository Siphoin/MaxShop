using MaxShop.Delta.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MaxShop.Delta
{
    public class DbObjects
    {
        private static Dictionary<string, Category> categories = null;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var list = new Category[]
                    {
                    new Category("Смартфоны Apple", "IPhones"),
                    new Category("Смартфоны Samsung", "Samsung"),
                    new Category("Смартфоны HONOR", "Honor"),
                    new Category("Смартфоны Xuawei", "Xuawei"),
                    new Category("Смартфоны Realme", "Realme"),
                    new Category("Смартфоны Redmi", "Redmi"),
                    };

                    categories = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        categories.Add(item.CategoryName, item);
                        Debug.WriteLine(categories[item.CategoryName]);
                    }

                }
                return categories;
            }
        }
        public static void CreateStartedTablesDb(AppDbContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Phone.Any())
            {
content.AddRange(

                    new Phone("HONOR 20", 21000, "", "", "/img/honor20.png", true, true, Categories["Смартфоны HONOR"]),
                    new Phone("Samsung Galaxy A50", 18000, "", "", "/img/samsung_a50.png", true, true, Categories["Смартфоны Samsung"])

                    );
            }
                
            

            content.SaveChanges();

        }
    }
}
