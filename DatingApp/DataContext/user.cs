using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DataContext
{
    public class user
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
    }
}
