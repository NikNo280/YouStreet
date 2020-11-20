using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouStreet.Data.Interfaces
{
    public interface ISender
    {
        Task SendMessage(string email, string subject, string message);
    }
}
