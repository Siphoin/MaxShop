using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using System.Collections.Generic;

namespace MaxShop.Delta.Mocks
{
    public class MockCategory : IPhonesCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category("Смартфоны Apple", "IPhones"),
                    new Category("Смартфоны Samsung", "Samsung"),
                    new Category("Смартфоны HONOR", "Honor"),
                    new Category("Смартфоны Xuawei", "Xuawei"),
                    new Category("Смартфоны Realme", "Realme"),
                    new Category("Смартфоны Redmi", "Redmi"),
                };
            }
        }
    }
}
