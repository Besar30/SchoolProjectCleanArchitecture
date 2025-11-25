using AutoMapper;
namespace SchoolProject.Core.Mapping.Instracotors
{
    public partial class InstractroProfile:Profile
    {
        public InstractroProfile() {
            AddInstractorMapping();
            GetInstractorByIdMapping();
            UpdateInstractorCommandMapping();
            GetAllInstractorsMapping();
        }
    }
}
