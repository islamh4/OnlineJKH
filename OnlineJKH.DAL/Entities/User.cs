using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Фамилия обязательно!")]
        [Display(Name = "Фамилия")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Неправильно введено фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Имя обязательно!")]
        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 3,ErrorMessage = "Неправильно введено имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string? Paronymic { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "СНИЛС обязательно!")]
        [Display(Name = "СНИЛС")]
        [StringLength(11, MinimumLength = 11,ErrorMessage ="Неправильно введен СНИЛС")]
        public string Snils { get; set; }
        [Required(ErrorMessage = " Данные паспорта обязательно!")]
        [Display(Name = "Данные паспорта")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Неправильно введен паспорт")]
        public string PassportInfo { get; set; }
        [Display(Name = "Админ")]
        public bool IsAdmin { get; set; }
    }
}
