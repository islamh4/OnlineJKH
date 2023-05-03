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
        private IPersonalAccountService _personalAccountService;
        private IMeterReadingService _meterReadingService;
        private IReceiptService _receiptService;
        private IUserService _userService;
        public DataManager(IPersonalAccountService personalAccountService, IMeterReadingService meterReadingService, IReceiptService receiptService, IUserService userService)
        {
            _personalAccountService = personalAccountService;
            _meterReadingService = meterReadingService;
            _receiptService = receiptService;
            _userService = userService;
        }
        public IPersonalAccountService PersonalAccountService { get { return _personalAccountService; } }
        public IMeterReadingService MeterReadingService { get {  return _meterReadingService; } }
        public IReceiptService ReceiptService { get {  return _receiptService; } }
        public IUserService UserService { get { return _userService; } }
    }
}
