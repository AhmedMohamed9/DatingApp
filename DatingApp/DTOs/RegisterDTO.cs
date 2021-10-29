using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [MinLength(3)]
        public string name { get; set; }
        [Required]
        [MinLength(3)]
        public string password { get; set; }

    }
}
