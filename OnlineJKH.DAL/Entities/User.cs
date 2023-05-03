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
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина фамилии составляет максимум 30 символов, пожалуйста, введите корректно.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Имя обязательно!")]
        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 3,ErrorMessage = "Длина имени составляет максимум 30 символов, пожалуйста, введите корректно.")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "СНИЛС обязательно!")]
        [Display(Name = "СНИЛС")]
        [StringLength(11, MinimumLength = 11,ErrorMessage = "Длина СНИЛС составляет 11 символов, пожалуйста, введите корректно.")]
        public string Snils { get; set; }
        [Required(ErrorMessage = " Данные паспорта обязательно!")]
        [Display(Name = "Данные паспорта")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Длина паспорта составляет 10 символов, пожалуйста, введите корректно.")]
        public string PassportInfo { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
