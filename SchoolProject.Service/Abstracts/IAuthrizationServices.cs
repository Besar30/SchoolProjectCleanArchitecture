using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Abstracts
{
    public interface IAuthrizationServices
    {
        Task <bool> AddRoleAsync(string roleName);
       Task< bool> IsRoleIsExist(string roleName);

    }
}
