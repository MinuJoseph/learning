using System;
using System.Collections.Generic;
using BakedInHeaven.DataAccess.Entities;



namespace BakedInHeaven.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        List<Users> GetAllUsers();
        void Add(Users userEntity);
    }
}