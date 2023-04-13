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
    public class UserService : IUserService
    {
        EFDBContext db;
        public UserService(EFDBContext _db)
        {
            db = _db;
        }
        public void Create(User user)
        {
            if (user == null)
                throw new Exception("Данные не найдены!");
            db.Users.Add(user);
            db.SaveChanges();
        }

        public IEnumerable<User> GetUser()
        {
            return db.Users;
        }
        public void Update(User user)
        {
            if (user == null)
                throw new Exception("Данные не найдены!");
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public User Get(int id)
        {
            var user = db.Users.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                throw new Exception("Объект не найден!");
            }
            return user;
        }
    }
}
