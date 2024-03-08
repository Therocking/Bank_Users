using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Users.Infra.Repositories.Interfaces;
using Bank_Users.Domain.Entites;

namespace Users.Infra.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly UsersDbContext _context;
        public UsersRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task Add(UsersEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<UsersEntity?> GetByEmail(string email)
        {
            return await _context.Users.Where(e => e.Email == email).FirstOrDefaultAsync();
        }
    }
}
