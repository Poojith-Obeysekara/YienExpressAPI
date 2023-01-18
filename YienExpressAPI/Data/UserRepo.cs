using YienExpressAPI.Model;

namespace YienExpressAPI.Data
{
    public class UserRepo : IUserRepo
    {
        private AppDBContext context;

        public UserRepo(AppDBContext dBContext)
        {
            context = dBContext;
        }
        public void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(User));
            context.users.Add(user);

        }

        public void Delete(User user)
        {
            context.users.Remove(user);
            Save();
        }

        public User GetUser(int id)
        {
            return context.users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.users.ToList();
        }

        public bool Save()
        {
            int count = context.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool Update(User user)
        {
            context.users.Update(user);
            return Save();
        }
    }
}
