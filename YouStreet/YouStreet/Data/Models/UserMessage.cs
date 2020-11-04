using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouStreet.Data.Models
{
    public class UserMessage
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string SenderId { get; set; }

        public string ReaderId { get; set; }

        public UserMessage()
        {
            this.Date = DateTime.Now;
        }
    }
}
