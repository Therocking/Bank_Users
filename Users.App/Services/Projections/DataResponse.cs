using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;
using Users.App.Dtos;

namespace Users.App.Services.Projections
{
    public static class DataResponse
    {
        public static DataResponseDto ResponseToUser(UsersEntity entity, string token)
        {
             DataResponseDto dto = new DataResponseDto
             {
                 User = new UserResponseDto
                 {
                     Email = entity.Email,
                     Name = entity.Name,
                     Id = entity.Id,
                 },
                 Token = token
             };

            return dto;
        }
    }
}
