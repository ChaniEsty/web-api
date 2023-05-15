using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public class UsersService : IUsersService
    {

        private IUsersRepository usersRepository;
        static private string path = "Entities\\Db.txt";

        public UsersService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return  await usersRepository.GetUserById(id);

           
        }
         public async Task<User> CreataeUser(User user)
         {

            return await usersRepository.CreataeUser(user);


         }

        public async Task<User> SignIN(User data)
        {
            return await usersRepository.SignIN(data);

        }

        public async Task UpdateUser(int id, User userToUpdate)
        {

            await usersRepository.UpdateUser(id, userToUpdate);
        }



    }
}
