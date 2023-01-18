using YienExpressAPI.Model;

namespace YienExpressAPI.Data
{
    public interface ICoporateCustomerRepo
    {
        void CreateCoporateCustomer(CoporateCustomer coporateCustomer);
        void Delete(CoporateCustomer coporateCustomer);
        bool Update(CoporateCustomer coporateCustomer);
        CoporateCustomer GetCoporateCustomer(int id);
        IEnumerable<CoporateCustomer> GetCoporateCustomers();

        bool Save();
    }
}
