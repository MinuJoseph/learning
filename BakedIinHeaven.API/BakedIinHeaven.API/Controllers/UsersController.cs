using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakedInHeaven.API.Context;
using BakedInHeaven.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakedInHeaven.API.Controllers
{
    public class UsersController : ControllerBase
    {
        [Route("user")]
        [HttpGet]
        public List<User> GetAllUsers()
        {
            using var dbContext = new BakeryDbContext();
            return dbContext.User.ToList();

        }

        [Route("user")]
        [HttpPost]
        public bool CreateUsers(User user)
        {
            using var dbContext = new BakeryDbContext();

            dbContext.User.Add(user);
            dbContext.SaveChanges();

            return true;

        }
   }
}