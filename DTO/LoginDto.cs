using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginDto
    {
        public string Password { get; set; } = null!;
        [EmailAddress(ErrorMessage ="wrong email address")]
        public string Email { get; set; } = null!;

    }
}
