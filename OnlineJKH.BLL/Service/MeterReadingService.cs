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
            db.meterReadings.Add(meter);
            db.SaveChanges();
        }

        public IEnumerable<MeterReading> GetMeterReading()
        {
            return db.meterReadings.Include(m => m.PersonalAccount);
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
            var metRead = db.meterReadings.FirstOrDefault(m => m.Id == id);
            if (metRead == null)
                throw new Exception("Объект не найден!");
            db.Entry(metRead).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public MeterReading Get(int id)
        {
            var metRead = db.meterReadings.FirstOrDefault(m => m.Id == id);
            if (metRead == null)
            {
                throw new Exception("Объект не найден!");
            }
            return metRead;
        }
        public SelectList GetSelectList(IEnumerable<PersonalAccount> personalAccount)
        {
            return new SelectList(personalAccount.ToList(), "Id", "Number");
        }
    }
}
