﻿using System;
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
        [Required(ErrorMessage = "Лицевой счёт обязательно!")]
        [Display(Name = "Лицевой счёт")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Ошибка ввода!")]
        public string Number { get; set; }
    }
}
