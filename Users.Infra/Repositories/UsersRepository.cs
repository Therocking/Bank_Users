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

        public async Task Add(UsersEntity entity, UsersRolesEntity role, CancellationToken cancellationToken = default)
        {
            _context.Add(entity);
            _context.Add(role);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<UsersEntity?> GetByEmail(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users.Where(e => e.Email == email && !e.IsDeleted).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
