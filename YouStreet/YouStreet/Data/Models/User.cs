using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public FileModel Avatar { get; set; }
        public FileModel Gallary { get; set; }
        public List<User> Friends { get; set; }
        public string Gender { get; set; }
        public uint Year { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string GetName()
        {
            return FirstName + " " + SecondName;
        }
    }

    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
