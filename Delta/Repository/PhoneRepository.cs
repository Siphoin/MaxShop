using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MaxShop.Delta.Repository
{
    public class PhoneRepository : IAllPhones
    {
        private readonly AppDbContent appDbContent;

        public PhoneRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Phone> Phones => appDbContent.Phone.Include(c => c.Category);

        public IEnumerable<Phone> FavoritesPhones => appDbContent.Phone.Where(p => p.IsFavorite).Include(c => c.Category);

        public Phone GetObjectPhone(int phoneId) => appDbContent.Phone.FirstOrDefault(a => a.Id == phoneId);
    }
}
