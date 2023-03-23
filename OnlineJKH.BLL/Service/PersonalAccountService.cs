using OnlineJKH.BLL.Interfaces;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.BLL.Service
{
    public class PersonalAccountService : IPersonalAccountService
    {
        EFDBContext db;
        public PersonalAccountService(EFDBContext _db)
        {
            db = _db;
        }

        public void Create(PersonalAccount personal)
        {
            if (personal == null)
                throw new Exception("Данные не найдены!");
            db.personalAccounts.Add(personal);
            db.SaveChanges();
        }

        public IEnumerable<PersonalAccount> GetPersonalAccounts()
        {
            return db.personalAccounts;
        }
        public void Update(PersonalAccount personal)
        {
            if (personal == null)
                throw new Exception("Данные не найдены!");
            db.Entry(personal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id == null)
                throw new Exception("Id номер не инициализован!");
            var persAc = db.personalAccounts.FirstOrDefault(m => m.Id == id);
            if (persAc == null)
                throw new Exception("Объект не найден!");
            db.Entry(persAc).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public PersonalAccount Get(int id)
        {
            if (id == null)
                throw new Exception("Id номер не инициализован!");
            return db.personalAccounts.FirstOrDefault(m => m.Id == id);
        }
    }
}
