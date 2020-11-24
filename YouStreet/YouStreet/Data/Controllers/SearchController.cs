using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouStreet.Data.Interfaces;
using YouStreet.Data.Models;
using YouStreet.Models;
using YouStreet.ViewModels;

namespace YouStreet.Data.Controllers
{

    public class SearchController : Controller
    {
        private readonly ApplicationContext _context;
        public SearchController(ApplicationContext db, IUserDb UserDb)
        {
            _context = db;
        }

        public IActionResult UsersList(string FirstName, string SecondName, string Country, string City, string Street, string District, int? Year)
        {
            IQueryable<ApplicationUser> Users = _context.User.AsNoTracking();
            if (!String.IsNullOrEmpty(FirstName) && !FirstName.Equals(""))
            {
                Users = Users.Where(p => p.FirstName == FirstName);
            }
            if (!String.IsNullOrEmpty(SecondName) && !SecondName.Equals(""))
            {
                Users = Users.Where(p => p.SecondName == SecondName);
            }
            if (!String.IsNullOrEmpty(Country) && !Country.Equals(""))
            {
                Users = Users.Where(p => p.Country == Country);
            }
            if (!String.IsNullOrEmpty(City) && !City.Equals(""))
            {
                Users = Users.Where(p => p.City == City);
            }
            if (!String.IsNullOrEmpty(Street) && !Street.Equals(""))
            {
                Users = Users.Where(p => p.Street == Street);
            }
            if (!String.IsNullOrEmpty(District) && !District.Equals(""))
            {
                Users = Users.Where(p => p.District == District);
            }
            if (Year != null && Year != 0)
            {
                Users = Users.Where(p => p.Year == Year);
            }
            SearchUsersViewModels suvm = new SearchUsersViewModels
            {
                Users = Users.ToList()
            };
            return View(suvm);
        }
        
        public async Task<IActionResult> UserProfile(string id)
        {
            if (id != null)
            {
                ApplicationUser user = await _context.Users.FirstOrDefaultAsync((p => p.Id == id));
                if (user != null)
                {
                    return View(user);
                }
            }
            return NotFound();
        }
    }
}

