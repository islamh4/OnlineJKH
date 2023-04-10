using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IMeterReadingService
    {
        IEnumerable<MeterReading> GetMeterReading();
        void Delete(int id);
        void Create(MeterReading meter);
        MeterReading Get(int id);
        void Update(MeterReading meter);
    }
}
