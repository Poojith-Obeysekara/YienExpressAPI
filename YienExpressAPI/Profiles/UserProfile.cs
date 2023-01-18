using AutoMapper;
using YienExpressAPI.DTO;
using YienExpressAPI.Model;

namespace YienExpressAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();

        }
    }
}
