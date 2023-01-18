using AutoMapper;
using YienExpressAPI.DTO;
using YienExpressAPI.Model;

namespace YienExpressAPI.Profiles
{
    public class YienEmployeeProfile : Profile
    {
        public YienEmployeeProfile()
        {
            CreateMap<YienEmployee, YienEmployeeReadDTO>();
            CreateMap<YienEmployeeCreateDTO, YienEmployee>();

        }
    }
}
