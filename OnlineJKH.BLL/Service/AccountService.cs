using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using OnlineJKH.BLL.Interfaces;
using OnlineJKH.DAL.EF;
using OnlineJKH.DAL.Entities;
using System.Security.Claims;

namespace OnlineJKH.BLL.Service
{
    public class AccountService : IAccountService
    {
        EFDBContext _db;
        public AccountService(EFDBContext db) 
        {
            _db = db;
        }

        public void Delete(User user)
        {
            var acc = _db.Accounts.FirstOrDefault(a => a.Id == user.Account.Id);
            _db.Accounts.Remove(acc);
            _db.SaveChanges();
        }

        public ClaimsPrincipal Login(Account acc)
        {
            var account = _db.Accounts.FirstOrDefault(m => m.Login == acc.Login && m.Password == acc.Password);
            if (account == null)
               return null;
            var user = _db.Users.FirstOrDefault(m => m.Account.Login == account.Login && m.Account.Password == account.Password);
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Account.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
        public void Update(User user)
        {
            var acc = _db.Accounts.FirstOrDefault(m => m.Id == user.AccountId);
            if (acc != null)
            {
                acc.Login = user.Account.Login;
                acc.Password = user.Account.Password;
                _db.Entry(acc).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}
