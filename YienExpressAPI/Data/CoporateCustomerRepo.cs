using YienExpressAPI.Model;

namespace YienExpressAPI.Data
{
    public class CoporateCustomerRepo : ICoporateCustomerRepo
    {
        private AppDBContext context;

        public CoporateCustomerRepo(AppDBContext dBContext)
        {
            context = dBContext;
        }
        public void CreateCoporateCustomer(CoporateCustomer coporateCustomer)
        {
            if (coporateCustomer == null)
                throw new ArgumentNullException(nameof(coporateCustomer));
            context.coporateCustomers.Add(coporateCustomer);

        }

        public void Delete(CoporateCustomer coporateCustomer)
        {
            context.coporateCustomers.Remove(coporateCustomer);
            Save();
        }

        public CoporateCustomer GetCoporateCustomer(int id)
        {
            return context.coporateCustomers.FirstOrDefault(s => s.ID == id);
        }

        public IEnumerable<CoporateCustomer> GetCoporateCustomers()
        {
            return context.coporateCustomers.ToList();
        }

        


        public bool Save()
        {
            int count = context.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool Update(CoporateCustomer coporateCustomer)
        {
            context.coporateCustomers.Update(coporateCustomer);
            return Save();
        }
    }
}
