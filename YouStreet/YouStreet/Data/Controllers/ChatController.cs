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
    public class ChatController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IUserDb _userDb;
        private static string ReaderId;
        private static string ReaderName;
        public ChatController(ApplicationContext db, IUserDb UserDb)
        {
            _context = db;
            _userDb = UserDb;
        }

        [HttpGet]
        public async Task<IActionResult> Chat()
        {
            if(TempData["UserId"] != null)
            {
                ReaderId = TempData["UserId"].ToString();
                ReaderName = _userDb.GetUser(ReaderId).UserName;
            }
            IEnumerable<UserMessage> userMessages = await _context.UserMessage.ToListAsync();

            MessageViewModel mvm = new MessageViewModel();        
            userMessages = userMessages.OrderByDescending(p => p.Date)
                .Where(p => (p.SenderId == User.Identity.GetUserId() &&
                p.ReaderId == ReaderId) || (p.SenderId == ReaderId &&
                p.ReaderId == User.Identity.GetUserId()));
            mvm.ReaderName = ReaderName;
            mvm.UserMessages = userMessages;
            return View(mvm);
        }

        [HttpPost]
        
        public async Task<IActionResult> Chat(MessageViewModel model)
        {
            if(ModelState.IsValid)
            {
                UserMessage message = new UserMessage();
                message.Id = Guid.NewGuid().ToString();
                message.Date = DateTime.Now;
                message.Text = model.Text;
                message.SenderId = User.Identity.GetUserId();            
                message.ReaderId = ReaderId;
                message.ReaderName = _userDb.GetUser(ReaderId).UserName;
                message.SenderName = User.Identity.Name;
                await _context.UserMessage.AddAsync(message);
                await _context.SaveChangesAsync();
            }
            return View();
        }
    }
}
