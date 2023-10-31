using Microsoft.AspNetCore.Http;
using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IImportExcelService
    {
        string ImportExcel(IFormFile formFile);
    }
}
