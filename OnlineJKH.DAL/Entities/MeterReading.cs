using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.DAL.Entities
{
    public class MeterReading
    {
        public int Id { get; set; }
        [Display(Name = "Показания счетчика")]
        [RegularExpression(@"\d{8}", ErrorMessage = "Ошибка ввода!")]
        [Range(10000000, 99999999, ErrorMessage = "Показания счетчиков обязательно!")]
        public int IndicationValue { get; set; }
        public int PersonalAccountId { get; set; }
        public virtual PersonalAccount? PersonalAccount { get; set; }
    }
}
