using OnlineJKH.BLL.Interfaces;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;

namespace OnlineJKH.BLL.Service
{
    public class UserService : IUserService
    {
        EFDBContext _db;
        public UserService(EFDBContext db)
        {
            _db = db;
        }
        public void Create(User user)
        {
            if (user == null)
                throw new Exception("Данные не найдены!");
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.Users.ToList();
        }
        public void Update(User user)
        {
            if (user == null)
                throw new Exception("Данные не найдены!");
            _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Get(id);
            _db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
        }

        public User Get(int id)
        {
            var user = _db.Users.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                throw new Exception("Объект не найден!");
            }
            return user;
        }
    }
}
