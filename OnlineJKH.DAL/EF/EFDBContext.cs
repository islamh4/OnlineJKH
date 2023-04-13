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
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
