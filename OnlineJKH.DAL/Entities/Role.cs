using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [Display(Name="Роль")]
        [Required(ErrorMessage = "Роль обязательно!")]
        public string Name { get; set; }
    }
}
