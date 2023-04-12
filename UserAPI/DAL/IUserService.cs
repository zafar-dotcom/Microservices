using UserAPI.Model;

namespace UserAPI.DAL
{
    public interface IUserService
    {
        public IEnumerable<User> GetUSerList();
        public User GetUserByID(int id);    
        public User AddUuser(User user);
        public User UpdateUuser(User user);
        public bool DeleteUser(int id);
    }
}
