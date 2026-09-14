using WebApplication1.IUser;
using WebApplication1.Model;

namespace WebApplication1.UserService
{
    public class UserService : IUserService
    {
        public User infor(User user)
        {
            var users = new User()
            {
                name = user.name,
                age = user.age,
                address = user.address,
                gmail = user.gmail,
            };
            return users;
        }
        

        public string user(string name)
        {
            return $"Ten toi la{name}";
        }

        public string yearold(string name,int birthofdate)
        {
            
            int date = DateTime.Now.Year;
            return $"ten: {name},tuoi: {date - birthofdate}";
        }
        

    }
}
