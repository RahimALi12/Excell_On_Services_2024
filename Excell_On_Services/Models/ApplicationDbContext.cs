using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Excell_On_Services.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }


        public DbSet<Services> Service { get; set; }
        public DbSet<ClientServices> ClientService { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Stripesetting> Stripesettings { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }


    }
}
