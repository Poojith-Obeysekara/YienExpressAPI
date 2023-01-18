using YienExpressAPI.Model;
using YienExpressAPI.Profiles;

namespace YienExpressAPI.Data
{
    public interface IOrderRepo
    {
        void CreateOrder(Order Order);
        void Delete(Order Order);
        bool Update(Order Order);
        Order GetOrder(int id);
        IEnumerable<Order> GetOrders();

        bool Save();

    }
}
