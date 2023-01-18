using YienExpressAPI.Model;
using YienExpressAPI.Profiles;

namespace YienExpressAPI.Data
{
    public interface IYienEmployeeRepo
    {
        void CreateYienEmployee(YienEmployee yienEmployee);
        void Delete(YienEmployee yienEmployee);
        bool Update(YienEmployee yienEmployee);
        YienEmployee GetYienEmployee(int id);
        IEnumerable<YienEmployee> GetYienEmployees();

        bool Save();

    }
}
