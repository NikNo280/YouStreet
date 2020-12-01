using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouStreet.Data.Interfaces;
using YouStreet.Models;

namespace YouStreet.Data.Repositories
{
    public class UserRepository : IUserDb
    {
        private readonly ApplicationContext identityDbContext;

        public UserRepository(ApplicationContext identityDbContext)
        {
            this.identityDbContext = identityDbContext;
        }
        public IEnumerable<ApplicationUser> GetAllUsers => identityDbContext.User.Include(c => c.Id);

        public ApplicationUser GetUser(string UserId) => identityDbContext.User.FirstOrDefault(predicate => predicate.Id == UserId);

    }
}
