using YienExpressAPI.Model;
using YienExpressAPI.Profiles;

namespace YienExpressAPI.Data
{
    public interface ICustomerRepo
    {
        void CreateCustomer(Customer customer);
        void Delete(Customer customer);
        bool Update(Customer customer);
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomers();

        bool Save();

    }
}
