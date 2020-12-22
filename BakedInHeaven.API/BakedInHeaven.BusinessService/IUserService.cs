using BakedInHeaven.BusinessService.Dtos;
using BakedInHeaven.DataAccess.Entities;
using System.Collections.Generic;


namespace BakedInHeaven.BusinessService
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();

        void AddUser(UserDto user);

    }
}