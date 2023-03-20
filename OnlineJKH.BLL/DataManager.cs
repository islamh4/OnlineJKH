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
        private IPersonalAccount _personalAccount;
        public DataManager(IPersonalAccount personalAccount)
        {
            _personalAccount = personalAccount;
        }
        public IPersonalAccount PersonalAccount { get { return _personalAccount; } }
    }
}
