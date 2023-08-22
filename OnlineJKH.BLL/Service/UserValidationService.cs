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
        StringBuilder stringError = new StringBuilder();
        public (StringBuilder, User) UserValidation(User user)
        {
            stringError.Append($"\nПользовтель {user.Surname} {user.Name} {user.Patronymic}: не добавлен! \n !!!ОШИБКИ!!! ");
            bool userTrue = false;
            if (user.Surname == null || user.Name == null)
            {
                userTrue = true;
                stringError.Append($"\nФамилия и Имя должны быть заполнены!");
            }
            if (user.Surname?.Length < 3 || user.Name.Length < 3)
            {
                userTrue = true;
                stringError.Append($"\nДлина Фамилия и Имя составляет минимум 3 символов!");
            }
            if (user.Account.Login == user.Account.Password)
            {
                userTrue = true;
                stringError.Append($"\nЛогин и Пароль не должны совподать!");
            }
            if (_db.Users.Any(m => m.Account.Login == user.Account.Login))
            {
                userTrue = true;
                stringError.Append($"\nТаким логином уже пользователь существует!");
            }
            bool userProf = _db.Users.Any(m => m.PassportInfo == user.PassportInfo);
            userProf = _db.Users.Any(m => m.PassportInfo == user.Snils);
            if (userProf)
            {
                stringError.Append($"\nТакими данными как паспорт и СНИЛС уже пользователь существует!");
            }
            if (!userTrue)
            {
                stringError.Remove(0, stringError.Length);
                stringError.Append($"Пользовтель {user.Surname} {user.Name} {user.Patronymic}: добавлен!");
                return (stringError, user);
            }
            return (stringError, null);
        }
    }
}
 