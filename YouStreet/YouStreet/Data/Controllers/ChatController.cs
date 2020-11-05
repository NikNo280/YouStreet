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

            }
            IEnumerable<UserMessage> userMessage = await _context.UserMessage.ToListAsync();

            MessageViewModel mvm = new MessageViewModel();        
            userMessage = userMessage.OrderBy(p => p.Date)
                .Where(p => (p.SenderId == User.Identity.GetUserId() &&
                p.ReaderId == ReaderId) || (p.SenderId == ReaderId &&
                p.ReaderId == User.Identity.GetUserId()));
            mvm.ReaderId = ReaderId;
            mvm.UserMessages = userMessage;
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
                await _context.UserMessage.AddAsync(message);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
