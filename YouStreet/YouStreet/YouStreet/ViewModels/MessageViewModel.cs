﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YouStreet.Data.Models;
using YouStreet.Models;

namespace YouStreet.ViewModels
{
    public class MessageViewModel
    {
        [Required]
        [Display(Name = "Text")]
        public string Text { get; set; }
        public string ReaderId { get; set; }
        public string ReaderName { get; set; }

        public IEnumerable<UserMessage> UserMessages;
    }
}
