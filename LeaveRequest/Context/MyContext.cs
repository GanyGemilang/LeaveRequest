using LeaveRequest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequest.Context
{
    public class MyContext : DbContext
    {
        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestHistory> RequestHistories { get; set; }
        public DbSet<Parameter> Parameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.User).WithOne(b => b.Account).HasForeignKey<Account>(a => a.NIK);
            modelBuilder.Entity<User>().HasOne(x => x.Role);
            modelBuilder.Entity<RequestHistory>().HasOne(x => x.User);
            modelBuilder.Entity<RequestHistory>().HasOne(x => x.Request);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
