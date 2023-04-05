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
        private IMeterReadingService _meterReading;
        private IReceiptService _receipt;
        public DataManager(IPersonalAccountService personalAccount, IMeterReadingService meterReading, IReceiptService receipt)
        {
            _personalAccount = personalAccount;
            _meterReading = meterReading;
            _receipt = receipt;
        }
        public IPersonalAccountService PersonalAccount { get { return _personalAccount; } }
        public IMeterReadingService MeterReading { get {  return _meterReading; } }
        public IReceiptService Receipt { get {  return _receipt; } }
    }
}
