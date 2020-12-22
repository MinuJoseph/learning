using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BakedInHeaven.DataAccess.Context;
using BakedInHeaven.DataAccess.Entities;

namespace BakedInHeaven.DataAccess.Repositories
{
   public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Users userEntity)
        {

            _dbContext.Users.Add(userEntity);
            _dbContext.SaveChanges();
            
        }

        public List<Users> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

    }
}
