﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;

namespace Users.Infra.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task Add(UsersEntity entity, UsersRolesEntity role, CancellationToken cancellationToken);
        Task<UsersEntity?> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
