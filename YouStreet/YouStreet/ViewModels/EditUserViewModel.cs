using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using YouStreet.Data.Models;
using Microsoft.AspNetCore.Http;

namespace YouStreet.ViewModels
{
    public class EditUserViewModel
    {
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "SecondName")]
        public string SecondName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "District")]
        public string District { get; set; }

        [Display(Name = "UploadedFile")]
        public IFormFile UploadedFile { get; set; }

    }
}
