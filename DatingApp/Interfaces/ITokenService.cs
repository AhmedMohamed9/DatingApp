﻿using DatingApp.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Interfaces
{
   public interface ITokenService
    {
         Task<string> createToken(user user);
    }
}
