using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using OnlineJKH.BLL.Interfaces;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace OnlineJKH.BLL.Service
{
    public class ExportExcelService : IExportExcelService
    {
        EFDBContext db;
        public ExportExcelService(EFDBContext context) 
        {
            db = context;
        }
        public byte[] ExportExcel()
        {
            var data = db.PersonalAccounts.Select(m => new ExportExcel
            {
                Number = m.Number,
                FIO = (m.User.Surname + " " + m.User.Name + " " + m.User.Patronymic).ToString(),
                Snils = m.User.Snils
            }).ToList();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add($"Отчёт {DateTime.Now.ToString("d")}");

                worksheet.Cell("A1").Value = "Лицевой счёт";
                worksheet.Cell("B1").Value = "ФИО";
                worksheet.Cell("C1").Value = "СНИЛС";
                worksheet.Row(1).Style.Font.Bold = true;

                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cell(i+2, 1).Value = data[i].Number;
                    worksheet.Cell(i+2, 2).Value = data[i].FIO;
                    worksheet.Cell(i + 2, 3).Value = data[i].Snils;
                }
                worksheet.Columns("A", "D").AdjustToContents();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return stream.ToArray();
                }
            }
        }
    }
}
