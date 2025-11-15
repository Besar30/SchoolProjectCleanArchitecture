using SchoolProject.Core.Features.Instractors.Commands.Models;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Instracotors
{
    public partial class InstractroProfile
    {
        public void UpdateInstractorCommandMapping()
        {
            CreateMap<UpdateInstractorCommand, Instractor>()
                 .ForMember(des => des.Image, opt => opt.Ignore())
                 .ForMember(des=>des.InsId,opt=>opt.MapFrom(src=>src.Id));
        }
    }
}
