using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouStreet.Models;

namespace YouStreet.Data.Interfaces
{
    public interface IUserDb
    {
        IEnumerable<ApplicationUser> GetAllUsers { get; }
        ApplicationUser GetUser(string userId);
    }
}
