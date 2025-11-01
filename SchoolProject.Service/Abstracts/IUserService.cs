using SchoolProject.Shared.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IUserService
    {
        public Task<Result> ResetConfirmEmailService(string email);
        public Task<Result> ResetPasswordService(string email);
        public Task<Result> ResetPasswordConfirmationService(string email,string code);
        public Task<Result> ResetPasswordConfirmationConfirmationService(string email, string NewPassword, string ConfirmPassword);
    }
}
