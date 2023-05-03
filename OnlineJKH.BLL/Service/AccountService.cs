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
        public ClaimsPrincipal? Login(Account acc)
        {
            var account = _db.Accounts.FirstOrDefault(m => m.Login == acc.Login);
            if (account == null)
                return null;
            var user = _db.Users.FirstOrDefault(m => m.Id == account.Id);
            if (user == null) return null;
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Account.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}
