using AutoMapper;
using YienExpressAPI.DTO;
using YienExpressAPI.Model;

namespace YienExpressAPI.Profiles
{
    public class CoporateCustomerProfile : Profile
    {
        public CoporateCustomerProfile()
        {
            CreateMap<CoporateCustomer, CoporateCustomerReadDTO>();
            CreateMap<CoporateCustomerCreateDTO, CoporateCustomer>();

        }
    }
}
