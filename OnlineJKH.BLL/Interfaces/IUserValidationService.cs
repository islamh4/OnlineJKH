using DocumentFormat.OpenXml.Spreadsheet;
using OnlineJKH.DAL.Entities;
using System.Text;
using System.Web.Mvc;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IUserValidationService
    {
        (StringBuilder, User) UserValidation(User user);
    }
}
