﻿using DatingApp.DataContext;
using DatingApp.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Services
{
    public class TokenServices : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
      
        public TokenServices(IConfiguration config)
        {
           
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public async Task<string> createToken(user user)
        {
            var claims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.NameId, user.id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
            };



            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
