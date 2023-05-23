using System.ComponentModel.DataAnnotations;

namespace OnlineJKH.Models.ViewModel
{
    public class AccountViewModel
    {
        public int Id { get; set; } 
        [Phone]
        public string Login { get; set; }
        [MinLength(8,ErrorMessage ="Пароль не минимум 8 символов.")]
        public string Password { get; set; }
    }
}
