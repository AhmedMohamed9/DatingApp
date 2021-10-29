using DatingApp.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace DatingApp.Controllers
{
    
    public class UserController : BaseApiController
    {
        private readonly context db;
        public UserController(context db)
        {
            this.db = db;
        }
        [Authorize]
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
