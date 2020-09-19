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
        private readonly ApplicationUser identityDbContext;

        public UserRepository(ApplicationUser identityDbContext)
        {
            this.identityDbContext = identityDbContext;
        }
        public IEnumerable<User> GetAllUsers => identityDbContext.User.Include(c => c.Id);

        public User GetUser(string UserId) => identityDbContext.User.FirstOrDefault(predicate => predicate.Id == UserId);

    }
}
