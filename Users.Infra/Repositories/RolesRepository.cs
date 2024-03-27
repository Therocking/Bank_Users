using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Users.Infra.Context;
using Users.Infra.Repositories.Interfaces;

namespace Users.Infra.Repositories
{
    public class RolesRepository : IRoleRepository
    {
        private readonly UsersDbContext _context;
        public RolesRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<RolesEntity> Add(RolesEntity role, CancellationToken cancellationToken)
        {
            _context.Add(role);
            await _context.SaveChangesAsync(cancellationToken);

            return role;
        }

        public Task<RolesEntity?> GetByName(string roleName, CancellationToken cancellation)
        {
            return _context.Roles.Where(x => x.Name == roleName).FirstOrDefaultAsync(cancellation);
        }
    }
}
