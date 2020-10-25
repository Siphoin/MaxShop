using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Repository
{
    public class CategoryRepository : IPhonesCategory
    {
        private readonly AppDbContent appDbContent;

        public CategoryRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}
