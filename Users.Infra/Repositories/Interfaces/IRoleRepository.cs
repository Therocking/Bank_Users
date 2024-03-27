using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;

namespace Users.Infra.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<RolesEntity> Add(RolesEntity role, CancellationToken cancellation);
        Task<RolesEntity?> GetByName(string roleName, CancellationToken cancellation);
    }
}
