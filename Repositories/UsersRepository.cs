using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository : IUsersRepository
    {
        EstyWebApiContext estyWebApiContext;
        static private string path = "M:\\web_API\\web-api\\Entities\\Db.txt";

        public UsersRepository(EstyWebApiContext estyWebApiContext)
        {
            this.estyWebApiContext = estyWebApiContext;
        }

        public async Task<User> GetUserById(int id)
        {
            User? user=await estyWebApiContext.Users.FindAsync(id);
            return user;
        }
        
        public async Task<User> CreataeUser(User user)
        {
            await estyWebApiContext.AddAsync(user);
            await estyWebApiContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> SignIN(User data)
        {
            List<User> user=await estyWebApiContext.Users.Where(user => user.Password == data.Password && user.Email == data.Email).ToListAsync();
            if (user.Count == 0)
                return null;
            return user[0];
        }
        //  PUT api/<LoginController>
        public async Task UpdateUser(int id, User userToUpdate)
        {
            estyWebApiContext.Update(userToUpdate);
            await estyWebApiContext.SaveChangesAsync();
        }
    }
}