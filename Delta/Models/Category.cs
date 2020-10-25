using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Phone> Phones { get; set; }

        public Category()
        {
            
        }

        public Category (string categoryName, string desc)
        {
            Description = desc;
            CategoryName = categoryName;
        }
    }
}
