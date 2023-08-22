using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineJKH.DAL.Entities
{
    public class PersonalAccount
    {
        public int Id { get; set; }
        [Display(Name = "Лицевой счёт")]
        [RegularExpression(@"\d{11}", ErrorMessage = "Длина номера составляет 10 символов, пожалуйста, введите корректно.")]
        [Required(ErrorMessage = "Лицевой счёт обязателен!")]
        public string Number { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
