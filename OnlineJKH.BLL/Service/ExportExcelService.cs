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
        public void ExportExcel()
        {
            var ExpEXl = db.PersonalAccounts.Select(m => new ExportExcel
            {
                Number = m.Number,
                FIO = (m.User.Surname + " " + m.User.Name + " " + m.User.Patronymic).ToString(),
                Snils = m.User.Snils
            }).ToList();
            Excel.Application app = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 1,
            };
            Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = $"Отчёт {DateTime.Now.ToString("d")}";
            sheet.Cells[1, 1] = "Лицевой счёт";
            sheet.Cells[1, 2] = "ФИО";
            sheet.Cells[1, 3] = "СНИЛС";
            for (int i = 2; i <= ExpEXl.Count+1; i++)
            {
                sheet.Cells[i, 1] = ExpEXl[i-2].Number;
                sheet.Cells[i, 2] = ExpEXl[i-2].FIO;
                sheet.Cells[i, 3] = ExpEXl[i-2].Snils;
            }
            Excel.Range range;
            for (int i = 1; i <= ExpEXl.Count+1; i++) 
            {
                for (int j = 1; j <= 3; j++)
                {
                    range = sheet.Cells[i, j] as Excel.Range;
                    range.EntireColumn.AutoFit();
                    range.EntireRow.AutoFit();
                }
            }
            app.Application.ActiveWorkbook.SaveAs("FileAdmin.xlsx", Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            app.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }
    }
}
