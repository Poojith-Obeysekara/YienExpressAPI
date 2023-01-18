using YienExpressAPI.Model;

namespace YienExpressAPI.Data
{
    public class OrderRepo : IOrderRepo
    {
        private AppDBContext context;

        public OrderRepo(AppDBContext dBContext)
        {
            context = dBContext;
        }
        public void CreateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(Order));
            context.orders.Add(order);

        }

        public void Delete(Order order)
        {
            context.orders.Remove(order);
            Save();
        }

        public Order GetOrder(int id)
        {
            return context.orders.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.orders.ToList();
        }

        public bool Save()
        {
            int count = context.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool Update(Order order)
        {
            context.orders.Update(order);
            return Save();
        }
    }
}
