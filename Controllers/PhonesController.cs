using MaxShop.Delta.Interfaces;
using MaxShop.Delta.Models;
using MaxShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IAllPhones _allPhones;
        private readonly IPhonesCategory _phonesCategories;

        public PhonesController (IAllPhones iAllPhones, IPhonesCategory iPhonesCategories)
        {
            _allPhones = iAllPhones;
            _phonesCategories = iPhonesCategories;
        }
        [Route("Phones/List")]
        [Route("Phones/List/{category}")]
        public   ViewResult List (string category)
        {
            string _category = category;
            IEnumerable<Phone> phones = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                phones = _allPhones.Phones.OrderBy(i => i.Id);
            }

            else
            
            {
                category = category.Trim();
              category =  category.ToLower();
                switch (category)
                {
                    case "honor":
                        phones = _allPhones.Phones.Where(t => t.Category.CategoryName.Equals("Смартфоны HONOR")).OrderBy(i => i.Id);
                        break;

                    case "samsung":
                        phones = _allPhones.Phones.Where(t => t.Category.CategoryName.Equals("Смартфоны Samsung")).OrderBy(i => i.Id);
                        break;

                    case "poco":
                        phones = _allPhones.Phones.Where(t => t.Category.CategoryName.Equals("Смартфоны Poco")).OrderBy(i => i.Id);
                        break;

                    case "realme":
                        phones = _allPhones.Phones.Where(t => t.Category.CategoryName.Equals("Смартфоны Realme")).OrderBy(i => i.Id);
                        break;

                    case "apple":
                        phones = _allPhones.Phones.Where(t => t.Category.CategoryName.Equals("Смартфоны Apple")).OrderBy(i => i.Id);
                        break;

                    case "redmi":
                        phones = _allPhones.Phones.Where(t => t.Category.CategoryName.Equals("Смартфоны Redmi")).OrderBy(i => i.Id);
                        break;

                    default:
                        phones = _allPhones.Phones.OrderBy(i => i.Id);
                        break;
                }
                



                currCategory = _category;

            }

            PhonesListVewModel phoneObj = new PhonesListVewModel();
            phoneObj.AllPhones = phones;
            phoneObj.currCategory = currCategory;
            ViewBag.Title = "Купить смартфон";
            PhonesListVewModel obj = new PhonesListVewModel();
            obj.AllPhones = _allPhones.Phones;
            obj.currCategory = "Категория";
            return View(phoneObj);
        }
    }
}
