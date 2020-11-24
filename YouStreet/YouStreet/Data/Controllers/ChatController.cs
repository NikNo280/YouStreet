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
        public ChatController(ApplicationContext db, IUserDb UserDb)
        {
            _context = db;
        }

        [HttpGet]
        public async Task<IActionResult> Chat(string id)
        {
            if (id != null)
            {
                ApplicationUser user = await _context.Users.FirstOrDefaultAsync((p => p.Id == id));
                if (user != null)
                {
                    IEnumerable<UserMessage> userMessages = await _context.UserMessage.ToListAsync();
                    MessageViewModel mvm = new MessageViewModel();
                    userMessages = userMessages.OrderByDescending(p => p.Date)
                        .Where(p => (p.SenderId == User.Identity.GetUserId() &&
                        p.ReaderId == user.Id) || (p.SenderId == user.Id &&
                        p.ReaderId == User.Identity.GetUserId()));
                    mvm.ReaderId = user.Id;
                    mvm.ReaderName = user.UserName;
                    mvm.UserMessages = userMessages;
                    return View(mvm);
                }
            }
            return NotFound();
        }

        [HttpPost]
        
        public async Task<IActionResult> Chat(MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserMessage message = new UserMessage();
                message.Id = Guid.NewGuid().ToString();
                message.Date = DateTime.Now;
                message.Text = model.Text;
                message.SenderId = User.Identity.GetUserId();
                message.ReaderId = model.ReaderId;
                message.ReaderName = model.ReaderName;
                message.SenderName = User.Identity.Name;
                await _context.UserMessage.AddAsync(message);
                await _context.SaveChangesAsync();
                return Redirect(model.ReaderId);
            }
            return NotFound();
        }
        
    }
}
