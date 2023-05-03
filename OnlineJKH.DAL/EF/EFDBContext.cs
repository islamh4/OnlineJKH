using Microsoft.EntityFrameworkCore;
using OnlineJKH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineJKH.DAL.EF
{
    public class EFDBContext : DbContext
    {
        public DbSet<PersonalAccount> PersonalAccounts { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role admin = new() { Id = 1, Name = "admin" };
            Role user = new() { Id = 2, Name = "user" };
            Account account = new Account() { Id = 1, Login = "89867150328", Password = "12345678" };
            modelBuilder.Entity<Account>().HasData(account);
            modelBuilder.Entity<Role>().HasData(admin);
            modelBuilder.Entity<Role>().HasData(user);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Surname = "Admin", Name = "Admin", Snils = "11111111111", PassportInfo = "1111111111", RoleId = admin.Id, AccountId = account.Id });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer();
        }
    }
}
