using DatingApp.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly context db;
        public UserController(context db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Getusers()
        {
            return await db.users.ToListAsync();
           
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<user>> Getuser(int id)
        {
            return await db.users.FindAsync(id);
            
        }
    }
}
