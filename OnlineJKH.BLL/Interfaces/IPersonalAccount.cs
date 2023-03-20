using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IPersonalAccount
    {
        IEnumerable<PersonalAccount> GetPersonalAccounts();
        void Delete(int? id);
        void Creat(PersonalAccount personal);
        PersonalAccount UpdateId(int? id);
        void Update(PersonalAccount personal);
    }
}
