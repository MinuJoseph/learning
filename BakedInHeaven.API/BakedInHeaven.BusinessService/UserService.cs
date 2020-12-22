using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BakedInHeaven.BusinessService.Dtos;
using BakedInHeaven.DataAccess.Entities;
using BakedInHeaven.DataAccess.Repositories;


namespace BakedInHeaven.BusinessService
{
  public class UserService : IUserService
    {

        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        public void AddUser(UserDto user)
        {
            var userEntity = new Users
            {

                Name = user.Name,
                Password = user.Password,

            };

            _usersRepository.Add(userEntity);

        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _usersRepository.GetAllUsers();

            return users.Select(p => new UserDto
            {
                
                Id = p.Id,
                Name = p.Name,
                Password=p.Password
            });
        }
    }
}
