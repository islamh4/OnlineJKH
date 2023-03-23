using OnlineJKH.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.BLL
{
    public class DataManager
    {
        private IPersonalAccountService _personalAccount;
        public DataManager(IPersonalAccountService personalAccount)
        {
            _personalAccount = personalAccount;
        }
        public IPersonalAccountService PersonalAccount { get { return _personalAccount; } }
    }
}
