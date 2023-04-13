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
    public class ReceiptService : IReceiptService
    {
        EFDBContext db;
        public ReceiptService(EFDBContext _db)
        {
            db = _db;
        }
        public void Create(Receipt receipt)
        {
            if (receipt == null)
                throw new Exception("Данные не найдены!");
            db.Receipts.Add(receipt);
            db.SaveChanges();
        }

        public IEnumerable<Receipt> GetReceipt()
        {
            return db.Receipts.Include(m => m.MeterReading);
        }
        public void Update(Receipt receipt)
        {
            if (receipt == null)
                throw new Exception("Данные не найдены!");
            db.Entry(receipt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var receipt = Get(id);
            db.Entry(receipt).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public Receipt Get(int id)
        {
            var receipt = db.Receipts.FirstOrDefault(m => m.Id == id);
            if (receipt == null)
            {
                throw new Exception("Объект не найден!");
            }
            return receipt;
        }
    }
}
