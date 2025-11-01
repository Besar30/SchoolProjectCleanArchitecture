using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IEmailService
    {
        Task<Result> SendMassege(string Email, string Messege,string? reason);
    }
}
