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
        EFDBContext _db;
        public ReceiptService(EFDBContext db)
        {
            _db = db;
        }
        public void Create(Receipt receipt)
        {
            if (receipt == null)
                throw new Exception("Данные не найдены!");
            _db.Receipts.Add(receipt);
            _db.SaveChanges();
        }

        public IEnumerable<Receipt> GetReceipts()
        {
            return _db.Receipts.ToList();
        }
        public void Update(Receipt receipt)
        {
            if (receipt == null)
                throw new Exception("Данные не найдены!");
            _db.Entry(receipt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var receipt = Get(id);
            _db.Entry(receipt).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
        }

        public Receipt Get(int id)
        {
            var receipt = _db.Receipts.FirstOrDefault(m => m.Id == id);
            if (receipt == null)
            {
                throw new Exception("Объект не найден!");
            }
            return receipt;
        }
    }
}
