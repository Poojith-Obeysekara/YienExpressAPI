using YienExpressAPI.Model;
using YienExpressAPI.Profiles;

namespace YienExpressAPI.Data
{
    public interface IPackageRepo
    {
        void CreatePackage(Package Package);
        void Delete(Package Package);
        bool Update(Package Package);   
        Package GetPackage(int id);   
        IEnumerable<Package> GetPackages();

        bool Save();

    }
}
