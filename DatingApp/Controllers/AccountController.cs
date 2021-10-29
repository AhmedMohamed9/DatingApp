using DatingApp.DataContext;
using DatingApp.DTOs;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly context db;
        private readonly ITokenService jwt;

        public AccountController(context db, ITokenService jwt)
        {
            this.db = db;
            this.jwt = jwt;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> register(RegisterDTO reg)
        {
            if (await isExist(reg.name))
                return BadRequest("User Name Is Exist, Please try another name");
            
           using var hmack = new HMACSHA512();
            var user = new user
            {
                Username = reg.name.ToLower(),
                passwordHash = hmack.ComputeHash(Encoding.UTF8.GetBytes(reg.password)),
                passwordSalt = hmack.Key
            };
            db.Add(user);
            await db.SaveChangesAsync();
           
            return new UserDTO {name=user.Username,token=await jwt.createToken(user) };
            
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> login(LoginDto reg)
        {
            var user = await db.users.SingleOrDefaultAsync(a => a.Username == reg.name);
            if (user == null)
                return Unauthorized("Invalid UserNAme");

            using var hmac = new HMACSHA512(user.passwordSalt);

            var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(reg.password));

            for (int i = 0; i < computedhash.Length; i++)
                     if (computedhash[i] != user.passwordHash[i]) return Unauthorized("Invalid Password");

            return new UserDTO { name = user.Username, token = await jwt.createToken(user) };
        }
        private async Task<bool> isExist(string name)
        {
            return await db.users.AnyAsync(s => s.Username == name.ToLower());
        }
    }
}
