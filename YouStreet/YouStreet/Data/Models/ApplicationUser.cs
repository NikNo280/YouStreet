using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouStreet.Models
{
    public class ApplicationUser : IdentityDbContext<User>
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
    }
}
