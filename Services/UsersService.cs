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
    public class UsersService
    {

        private UsersRepository usersRepository = new UsersRepository();
        static private string path = "Entities\\Db.txt";

        public User GetUserById(int id)
        {

            return usersRepository.GetUserById(id);
        }


        public User CreataeUser(User user)
        {
           
           return usersRepository.CreataeUser(user);


        }

        public User SignIN(User data)
        {
            return usersRepository.SignIN(data);

        }

        public void UpdateUser(int id, User userToUpdate)
        {

            usersRepository.UpdateUser(id,userToUpdate);
        }



    }
}
