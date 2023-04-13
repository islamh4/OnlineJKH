using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUser();
        void Delete(int id);
        void Create(User user);
        User Get(int id);
        void Update(User user);
    }
}
