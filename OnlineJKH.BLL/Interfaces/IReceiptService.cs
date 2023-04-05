using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IReceiptService
    {
        IEnumerable<Receipt> GetReceipt();
        void Delete(int id);
        void Create(Receipt meter);
        Receipt Get(int id);
        void Update(Receipt meter);
      //  SelectList GetSelectList(IEnumerable<MeterReading> meterReadings);
    }
}
