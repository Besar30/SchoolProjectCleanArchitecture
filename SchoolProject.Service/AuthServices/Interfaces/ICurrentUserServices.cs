using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.AuthServices.Interfaces
{
    public interface ICurrentUserServices
    {
        public Task< User> user();
        public string GetUserId();
        public Task< List<string>> GetCurrentUserRolesAsync();

    }
}
