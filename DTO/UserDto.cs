using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "name to long")]
        public string? Firstname { get; set; }
        [StringLength(20 ,ErrorMessage ="name to long")]
        public string? Lastname { get; set; }
        [EmailAddress(ErrorMessage = "wrong email address")]
        public string Email { get; set; } = null!;

    }
}
