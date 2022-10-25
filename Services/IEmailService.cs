using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miguelestradam.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(string ToEmail, string Subject, string HTMLBody);
    }
}