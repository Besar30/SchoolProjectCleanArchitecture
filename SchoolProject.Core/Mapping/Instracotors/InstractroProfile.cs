using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Instracotors
{
    public partial class InstractroProfile:Profile
    {
        public InstractroProfile() {
            AddInstractorMapping();
        }
    }
}
