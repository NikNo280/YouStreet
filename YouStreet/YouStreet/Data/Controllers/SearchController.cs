using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouStreet.Data.Interfaces;
using YouStreet.Models;

namespace YouStreet.Data.Controllers
{

    public class SearchController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IUserDb _userDb;
        public SearchController(ApplicationContext db, IUserDb UserDb)
        {
            _context = db;
            _userDb = UserDb;
        }

        [HttpGet]
        public IActionResult UsersList()
        {
            List<ApplicationUser> Users = _context.User.AsNoTracking().ToList();
            return View(Users);
        }
        
        public async Task<IActionResult> UserProfile(string id)
        {
            if (id != null)
            {
                ApplicationUser user = await _context.Users.FirstOrDefaultAsync((p => p.Id == id));
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
    }
}
