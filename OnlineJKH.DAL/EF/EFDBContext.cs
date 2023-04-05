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
        public DbSet<PersonalAccount> personalAccounts { get; set; }
        public DbSet<MeterReading> meterReadings { get; set; }
        public DbSet<Receipt> receipts { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
