using MaxShop.Delta.Interfaces;
using MaxShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Controllers
{
    public class HomeController : Controller
    {
        private IAllPhones _phoneRep;


        public HomeController (IAllPhones phoneRep)
        {
            _phoneRep = phoneRep;
        }

        public ViewResult Index ()
        {
            ViewBag.Title = "Max Shop";
            var obj = new HomeViewModel(_phoneRep.FavoritesPhones);
            return View(obj);
        }
    }
}
