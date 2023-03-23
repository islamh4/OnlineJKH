using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IPersonalAccountService
    {
        IEnumerable<PersonalAccount> GetPersonalAccounts();
        void Delete(int id);
        void Create(PersonalAccount personal);
        PersonalAccount Get(int id);
        void Update(PersonalAccount personal);
    }
}
