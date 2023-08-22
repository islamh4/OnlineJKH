using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OnlineJKH.BLL.Interfaces;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;
using System.Text;

namespace OnlineJKH.BLL.Service
{
    public class ImportExcelService : IImportExcelService
    {
        IUserValidationService _userValidationService;
        EFDBContext _db;
        public ImportExcelService(EFDBContext db, IUserValidationService userValidationService)
        {
            _db = db;
            _userValidationService = userValidationService;
        }
        StringBuilder stringError = new StringBuilder("Уведомление!!!");
        public string ImportExcel(IFormFile formFile) 
        {
            using (var stream = new MemoryStream())
            {
                formFile.CopyToAsync(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int i = 2 ; i <= rowcount; i++)
                    {
                        var user = new User()
                        {
                            Surname = worksheet.Cells[i, 1]?.Value?.ToString().Trim()??"",
                            Name = worksheet.Cells[i, 2]?.Value?.ToString().Trim() ?? null,
                            Patronymic = worksheet.Cells[i, 3]?.Value?.ToString().Trim() ?? null,
                            Account = AccIndexNext(worksheet.Cells[i, 4].Value.ToString().Trim(), worksheet.Cells[i, 5].Value.ToString().Trim()),
                            Address = worksheet.Cells[i, 6]?.Value?.ToString().Trim() ?? null,
                            Snils = worksheet.Cells[i, 7]?.Value?.ToString().Trim() ?? null,
                            PassportInfo = worksheet.Cells[i, 8]?.Value?.ToString().Trim() ?? null,
                            RoleId = worksheet.Cells[i, 9].Value.ToString().Trim() == "Admin" ? 1 : 2
                        };
                        ( var stringErr, user) = _userValidationService.UserValidation(user);
                        stringError.Clear();
                        stringError.Append(stringErr.ToString());
                        if (user != null)
                        {
                            _db.Users.Add(user);
                            _db.Accounts.Add(user.Account);
                            _db.SaveChanges();
                        }
                    }
                }
            }
            return stringError.ToString();
        }
        public Account AccIndexNext(string login, string password)
        {
            var accNew = new Account()
            {
                Login = login,
                Password = password
            };
            return accNew;
        }
    }
}