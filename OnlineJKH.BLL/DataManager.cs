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
        public DataManager(IPersonalAccountService personalAccountService, IMeterReadingService meterReadingService, IReceiptService receiptService)
        {
            _personalAccountService = personalAccountService;
            _meterReadingService = meterReadingService;
            _receiptService = receiptService;
        }
        public IPersonalAccountService PersonalAccount { get { return _personalAccountService; } }
        public IMeterReadingService MeterReading { get {  return _meterReadingService; } }
        public IReceiptService Receipt { get {  return _receiptService; } }
    }
}
