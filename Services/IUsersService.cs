using Entities;

namespace Services
{
    public interface IUsersService
    {
        User CreataeUser(User user);
        User GetUserById(int id);
        User SignIN(User data);
        void UpdateUser(int id, User userToUpdate);
    }
}