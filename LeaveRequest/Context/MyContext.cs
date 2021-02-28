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

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.User).WithOne(b => b.Account).HasForeignKey<Account>(a => a.NIK);
            modelBuilder.Entity<User>().HasOne(x => x.Role);
            modelBuilder.Entity<Request>().HasOne(x => x.User);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            /*optionsBuilder.UseSqlServer("server=localhost;port=44349;user=sa;password=sapassword;database=LeaveRequest");*/
        }
    }
}
