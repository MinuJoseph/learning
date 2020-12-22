using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakedInHeaven.BusinessService;
using BakedInHeaven.BusinessService.Dtos;
using BakedInHeaven.DataAccess.Entities;

namespace BakedInHeaven.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
            private readonly IUserService _userService;
            public UsersController(IUserService userService)
            {
                _userService = userService;
            }
            [Route("users")]
            [HttpGet]
            public IEnumerable< UserDto> GetAllUsers()
            {

                return _userService.GetAllUsers();
            }

            [Route("users")]
            [HttpPost]
            public void AddUser(UserDto user)
            {
               _userService.AddUser(user);
                
            }


        
    }
}
