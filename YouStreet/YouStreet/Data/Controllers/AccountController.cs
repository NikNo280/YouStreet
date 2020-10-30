using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YouStreet.Data.Interfaces;
using YouStreet.Data.Models;
using YouStreet.Data.Validator;
using YouStreet.Models;
using YouStreet.ViewModels;

namespace YouStreet.Data.Controllers
{
    public class AccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserDb _userDb;
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public AccountController(ApplicationContext context, IWebHostEnvironment appEnvironment,
            Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserDb UserDb)
        {
            _context = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
            _userDb = UserDb;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Country = model.Country,
                    City = model.City,
                    Street = model.Street,
                    District = model.District,
                    Email = model.Email,
                    UserName = model.UserName,
                    Year = model.Year,
                    Gender = model.Gender,
                    RegistrationDate = DateTime.Now,
                    Avatar = @"~/img/first_avatar.jpeg"
                };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("UserProfile", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            ApplicationUser user = _userDb.GetUser(User.Identity.GetUserId());
            return View(user);
        }


        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            ApplicationUser user = _userDb.GetUser(User.Identity.GetUserId());
            if(model.FirstName != null)
            {
                user.FirstName = model.FirstName;
            }
            if (model.SecondName != null)
            {
                user.SecondName = model.SecondName;
            }
            if (model.Email != null)
            {
                user.Email = model.Email;
            }
            if (model.Description != null)
            {
                user.Description = model.Description;
            }
            if (model.Country != null)
            {
                user.Country = model.Country;
            }
            if (model.City != null)
            {
                user.City = model.City;
            }
            if (model.District != null)
            {
                user.District = model.District;
            }
            if (model.Street != null)
            {
                user.Street = model.Street;
            }
            if (model.UploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + user.UserName + model.UploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.UploadedFile.CopyToAsync(fileStream);
                }
                user.Avatar = path;
            }

            await _userManager.UpdateAsync(user);

            return RedirectToAction("UserProfile", "Account");
        }

    }
}
