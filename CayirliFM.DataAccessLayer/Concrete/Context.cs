using CayirliFM.EntityLayer.Contrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CayirliFM.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3JI56T6\\SQLEXPRESS;initial catalog=FMCayirli;integrated security=true;TrustServerCertificate=true;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<SocialMediaAccounts> SocialMediaAccounts { get; set; }
        public DbSet<Strategy> Strategies { get; set; }
        public DbSet<WelcomeToOurSite> WelcomeToOurSites { get; set; }

    }
}
