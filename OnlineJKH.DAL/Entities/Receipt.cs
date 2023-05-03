using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.DAL.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Квитанция обязательно!")]
        [Display(Name = "Сумма для оплаты")]
        public int PaymentAmount { get; set; }
        public int MeterReadingId { get; set; }
        public virtual MeterReading? MeterReading { get; set; }
    }
}
