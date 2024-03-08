using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;
using Users.App.Dtos;

namespace Users.App.Services.Projections
{
    public static class ResponseUser
    {
        public static UserResponseDto EntityToDto(UsersEntity entity)
        {
            UserResponseDto dto = new UserResponseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
            };

            return dto;
        }
    }
}
