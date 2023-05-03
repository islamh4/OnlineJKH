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
        EFDBContext db;
        public MeterReadingService(EFDBContext _db)
        {
            db = _db;
        }
        public void Create(MeterReading meter)
        {
            if (meter == null)
                throw new Exception("Данные не найдены!");
            db.MeterReadings.Add(meter);
            db.SaveChanges();
        }

        public IEnumerable<MeterReading> GetMeterReadings()
        {
            return db.MeterReadings.Include(m => m.PersonalAccount);
        }
        public void Update(MeterReading meter)
        {
            if (meter == null)
                throw new Exception("Данные не найдены!");
            db.Entry(meter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var metRead = Get(id);
            db.Entry(metRead).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public MeterReading Get(int id)
        {
            var metRead = db.MeterReadings.FirstOrDefault(m => m.Id == id);
            if (metRead == null)
            {
                throw new Exception("Объект не найден!");
            }
            return metRead;
        }
    }
}
