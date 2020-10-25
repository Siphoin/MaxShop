using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Mocks
{
    public class MockPhones : IAllPhones
    {
        private readonly IPhonesCategory _CategoriesPhones = new MockCategory();
        public IEnumerable<Phone> Phones { get
            {
                return new List<Phone>
                {
                    new Phone("HONOR 20", 21000, "", "", "/img/honor20.png", true, true, _CategoriesPhones.AllCategories.ElementAtOrDefault(2)),
                    new Phone("Samsung Galaxy A50", 18000, "", "", "/img/samsung_a50.png", true, true, _CategoriesPhones.AllCategories.ElementAtOrDefault(1)),
                };
                
            }

        }
        public IEnumerable<Phone> FavoritesPhones { get; set; }

        public Phone GetObjectPhone(int phoneId)
        {
            throw new NotImplementedException();
        }
    }
}
