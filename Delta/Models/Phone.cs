using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public ushort Price { get; set; }
        public bool Avaliable { get; set; }
        public string ImageURL { get; set; }
        public string ShortDecription { get; set; }
        public string LongDecription { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public Phone()
        {
            
        }

        public Phone (string phoneName,ushort price, string longDecription, string shortDecription, string imageURL, bool favorite, bool avaliable, Category category)
        {
            Name = phoneName;
            Avaliable = avaliable;
            Price = price;
            ImageURL = imageURL;
            LongDecription = longDecription;
            ShortDecription = shortDecription;
            Category = category;


        }
    }
}
