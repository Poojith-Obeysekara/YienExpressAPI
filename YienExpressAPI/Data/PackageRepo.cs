using YienExpressAPI.Model;

namespace YienExpressAPI.Data
{
    public class PackageRepo : IPackageRepo
    {
        private AppDBContext context;

        public PackageRepo(AppDBContext dBContext)
        {
            context = dBContext;
        }
        public void CreatePackage(Package Package)
        {
          if(Package == null)
                throw new ArgumentNullException(nameof(Package));
          context.Packages.Add(Package);
               
        }

        public void Delete(Package Package)
        {
            context.Packages.Remove(Package);
            Save();
        }

        public Package GetPackage(int id)
        {
            return context.Packages.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<Package> GetPackages()
        {
            return context.Packages.ToList();
        }

        public bool Save()
        {
          int count = context.SaveChanges();
            if(count > 0)
                return true;
            else
                return false;
        }

        public bool Update(Package Package)
        {
            context.Packages.Update(Package);
            return Save();
        }
    }
}
