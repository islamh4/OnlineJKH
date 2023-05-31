using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IExportExcelService
    {
        byte[] ExportExcel();
    }
}
