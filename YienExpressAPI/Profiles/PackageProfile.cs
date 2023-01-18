using AutoMapper;
using YienExpressAPI.DTO;
using YienExpressAPI.Model;

namespace YienExpressAPI.Profiles
{
    public class PackageProfile:Profile
    {
        public PackageProfile()
        {
            CreateMap<Package, PackageReadDTO>();
            CreateMap<PackageCreateDTO, Package>();

        }
    }
}
