using Entities;

namespace Services
{
    public interface IUsersService
    {
        public Task<User> CreataeUser(User user);
        public Task<User> GetUserById(int id);
        public Task<User> SignIN(User data);
        public Task UpdateUser(int id, User userToUpdate);
        
    }
}