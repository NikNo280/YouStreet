using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YouStreet.Data.Models;

namespace YouStreet.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public uint Year { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string GetName()
        {
            return FirstName + " " + SecondName;
        }
    }
 
}
