using AutoMapper;
using YienExpressAPI.DTO;
using YienExpressAPI.Model;

namespace YienExpressAPI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDTO>();
            CreateMap<CustomerCreateDTO, Customer>();

        }
    }
}
