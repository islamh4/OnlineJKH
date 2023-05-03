using Microsoft.EntityFrameworkCore;
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
        EFDBContext _db;
        public PersonalAccountService(EFDBContext db)
        {
            _db = db;
        }

        public void Create(PersonalAccount personal)
        {
            if (personal == null)
                throw new Exception("Данные не найдены!");
            _db.PersonalAccounts.Add(personal);
            _db.SaveChanges();
        }

        public IEnumerable<PersonalAccount> GetPersonalAccounts()
        {
            return _db.PersonalAccounts.ToList();
        }
        public void Update(PersonalAccount personal)
        {
            if (personal == null)
                throw new Exception("Данные не найдены!");
            _db.Entry(personal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var persAc = Get(id);
            _db.Entry(persAc).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
        }

        public PersonalAccount Get(int id)
        {
            var persAc = _db.PersonalAccounts.FirstOrDefault(m => m.Id == id);
            if (persAc == null)
            {
                throw new Exception("Объект не найден!");
            }
            return persAc;
        }
    }
}
