using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.BLL.Interfaces
{
    public interface IAccountService
    {
        ClaimsPrincipal Login(Account account);
    }
}
