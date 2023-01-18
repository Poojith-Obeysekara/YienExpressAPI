using YienExpressAPI.Model;

namespace YienExpressAPI.Data
{
    public class YienEmployeeRepo : IYienEmployeeRepo
    {
        private AppDBContext context;

        public YienEmployeeRepo(AppDBContext dBContext)
        {
            context = dBContext;
        }
        public void CreateYienEmployee(YienEmployee yienEmployee)
        {
            if (yienEmployee == null)
                throw new ArgumentNullException(nameof(yienEmployee));
            context.yienEmployees.Add(yienEmployee);

        }

        public void Delete(YienEmployee yienEmployee)
        {
            context.yienEmployees.Remove(yienEmployee);
            Save();
        }

        public YienEmployee GetYienEmployee(int id)
        {
            return context.yienEmployees.FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<YienEmployee> GetYienEmployees()
        {
            return context.yienEmployees.ToList();
        }

        public bool Save()
        {
            int count = context.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool Update(YienEmployee yienEmployee)
        {
            context.yienEmployees.Update(yienEmployee);
            return Save();
        }
    }
}
