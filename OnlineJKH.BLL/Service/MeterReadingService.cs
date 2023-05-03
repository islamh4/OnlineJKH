using Microsoft.EntityFrameworkCore;
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
    public class MeterReadingService : IMeterReadingService
    {
        EFDBContext _db;
        public MeterReadingService(EFDBContext db)
        {
            _db = db;
        }
        public void Create(MeterReading meter)
        {
            if (meter == null)
                throw new Exception("Данные не найдены!");
            _db.MeterReadings.Add(meter);
            _db.SaveChanges();
        }

        public IEnumerable<MeterReading> GetMeterReadings()
        {
            return _db.MeterReadings.ToList();
        }
        public void Update(MeterReading meter)
        {
            if (meter == null)
                throw new Exception("Данные не найдены!");
            _db.Entry(meter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var metRead = Get(id);
            _db.Entry(metRead).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
        }

        public MeterReading Get(int id)
        {
            var metRead = _db.MeterReadings.FirstOrDefault(m => m.Id == id);
            if (metRead == null)
            {
                throw new Exception("Объект не найден!");
            }
            return metRead;
        }
    }
}
