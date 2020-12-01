using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YouStreet.Models;

namespace YouStreet.ViewModels
{
    public class SearchUsersViewModels
    {
        public List<ApplicationUser> Users;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public uint Year { get; set; }
    }
}
