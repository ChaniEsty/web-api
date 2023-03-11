using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {

        public int UserId { get; set; }

        //   [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; }


        /// [StringLength(20, ErrorMessage = "password length must be between 5-20", MinimumLength = 5)]
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


    }
}
