using DocumentFormat.OpenXml.Spreadsheet;
using Irony.Ast;
using OnlineJKH.BLL.Interfaces;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace OnlineJKH.BLL.Service
{
    public class UserValidationService : Controller, IUserValidationService
    {
        EFDBContext _db;
        public UserValidationService(EFDBContext db)
        {
            _db = db;
        }
        public (StringBuilder, User) UserValidation(User user)
        {
            StringBuilder stringError = new StringBuilder();
            stringError.Append($"\nПользовтель {user.Surname} {user.Name} {user.Patronymic}: не добавлен! \n !!!ОШИБКИ!!! ");
            bool userTrue = false;
            if (user.Surname == null || user.Name == null)
            {
                userTrue = true;
                stringError.Append($"\nПоля Фамилия и Имя обязательны для заполнения!");
            }
            if (user.Surname?.Length < 3 || user.Name.Length < 3)
            {
                userTrue = true;
                stringError.Append($"\nДлина полей Фамилия и Имя составляет минимум 3 символа!");
            }
            if (user.Account.Login == user.Account.Password)
            {
                userTrue = true;
                stringError.Append($"\nЛогин и Пароль не должны совподать!");
            }
            if (_db.Users.Any(m => m.Account.Login == user.Account.Login))
            {
                userTrue = true;
                stringError.Append($"\nПользователь с таким логином уже существует!");
            }
            var userProf = _db.Users.Any(m => m.PassportInfo == user.PassportInfo) || _db.Users.Any(m => m.Snils == user.Snils);
            if (userProf)
            {
                userTrue = true;
                stringError.Append($"\nПользователь с такими паспортными данными и СНИЛС уже существует!");
            }
            if (!userTrue)
            {
                stringError.Remove(0, stringError.Length);
                stringError.Append($"Пользователь {user.Surname} {user.Name} {user.Patronymic}: добавлен!");
                return (stringError, user);
            }
            return (stringError, null);
        }
    }
}
 