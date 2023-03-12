using Entities;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository : IUsersRepository
    {

        static private string path = "C:\\Users\\539137033\\Source\\Repos\\web-api\\Entities\\Db.txt";

        public User GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
            }
            return null;


        }


        public User CreataeUser(User user)
        {

            int numberOfUsers = System.IO.File.ReadLines(path).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(path, userJson + Environment.NewLine);

            //return nameof(GetUserById,user.UserId,user);
            return user;

        }

        public User SignIN(User data)
        {

            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == data.Email && user.Password == data.Password)
                        return user;
                    //return user;
                }
            }

            return null;


        }
        //  PUT api/<LoginController>


        public void UpdateUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;

            using (StreamReader reader = System.IO.File.OpenText(path))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(path);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(path, text);
            }


        }



    }
}