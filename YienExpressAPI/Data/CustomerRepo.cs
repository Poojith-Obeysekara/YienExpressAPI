using YienExpressAPI.Model;

namespace YienExpressAPI.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private AppDBContext context;

        public CustomerRepo(AppDBContext dBContext)
        {
            context = dBContext;
        }
        public void CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            context.customers.Add(customer);

        }

        public void Delete(Customer customer)
        {
            context.customers.Remove(customer);
            Save();
        }

        public Customer GetCustomer(int id)
        {
            return context.customers.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.customers.ToList();
        }

        public bool Save()
        {
            int count = context.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool Update(Customer customer)
        {
            context.customers.Update(customer);
            return Save();
        }
    }
}
