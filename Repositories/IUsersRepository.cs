using Entities;

namespace Repositories
{
    public interface IUsersRepository
    {
        User CreataeUser(User user);
        User GetUserById(int id);
        User SignIN(User data);
        void UpdateUser(int id, User userToUpdate);
    }
}