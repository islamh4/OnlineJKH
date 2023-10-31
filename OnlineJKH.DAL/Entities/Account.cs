using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.DAL.Entities
{
    public class Account
    {
        public int Id { get; set; }
        [Phone]
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Логин обязательно!")]
        public string Login { get; set; }
        [MinLength(8)]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Пароль обязательно!")]
        public string Password { get; set; }
    }
}
