using Castle.Components.DictionaryAdapter;
using Castle.Components.DictionaryAdapter.Xml;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OnlineJKH.BLL.Interfaces;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineJKH.BLL.Service
{
    public class ImportExcelService : IImportExcelService
    {
        EFDBContext _db;
        public ImportExcelService(EFDBContext db)
        {
            _db = db;
        }
        StringBuilder stringError = new StringBuilder();
        public string ImportExcel(IFormFile formFile) 
        {
            if (formFile == null)
            {
                stringError.Append("Импортируйте файл! ");
            }
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
                        stringError.Append($"Пользователь номер {i - 1}: ");
                        for (int j = 1; j <= worksheet.Dimension.Columns; j++)
                        {
                            if (worksheet.Cells[i, j].Value == null)
                            {
                                stringError.Append(" не добавлен,");
                                stringError.Append($" {worksheet.Cells[1, j].Value.ToString().Trim()} - пустая строка,");
                            }
                        }
                        if (worksheet.Cells[i, 4].Value.ToString().Trim() == worksheet.Cells[i, 5].Value.ToString().Trim())
                        {
                            stringError.Append(" логин и пароль не должны совподать!");
                        }
                        if (stringError.Length > 22)
                        {
                            stringError.Append(" Другие пользователи не были добавлены из-за не ожиданной ошибки исправте их!");
                            return stringError.ToString();
                        }
                        stringError.Append($" добавлен! ");
                        var user = new User()
                        {
                            Surname = worksheet.Cells[i, 1].Value.ToString().Trim(),
                            Name = worksheet.Cells[i, 2].Value.ToString().Trim(),
                            Patronymic = worksheet.Cells[i, 3].Value.ToString().Trim(),
                            Account = AccIndexNext(worksheet.Cells[i, 4].Value.ToString().Trim(), worksheet.Cells[i, 5].Value.ToString().Trim()),
                            Address = worksheet.Cells[i, 6].Value.ToString().Trim(),
                            Snils = worksheet.Cells[i, 7].Value.ToString().Trim(),
                            PassportInfo = worksheet.Cells[i, 8].Value.ToString().Trim(),
                            RoleId = worksheet.Cells[i, 9].Value.ToString().Trim() == "Admin" ? 1 : 2
                        };
                        _db.Users.Add(user);
                        _db.SaveChanges();
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
            _db.Accounts.Add(accNew);
            _db.SaveChanges();
            return accNew;
        }
    }
}