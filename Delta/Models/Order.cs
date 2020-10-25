using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaxShop.Delta.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }


        [Display(Name = "Адрес")]
        public string Adress { get; set; }


        [Display(Name = "Введите имя")]
        public string Name { get; set; }


        [Display(Name = "Фамилия")]
        public string Surname { get; set; }


        [Display(Name = "Номер телефона")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не менее 10 символов")]

        public string phoneNumber { get; set; }


        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина E-mail не менее 15 символов")]
        public string Email { get; set; }


        [BindNever]
        [ScaffoldColumn(false)]

        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
