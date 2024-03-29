﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;
using Users.App.Dtos;


namespace Users.App.Services.Projections
{
    public static class RegisterUser
    {
        public static UsersEntity RegisterUserToUser(RegisterUserDto registerUserDto)
        {
            var user = new UsersEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = registerUserDto.Name,
                Email = registerUserDto.Email,
                Password = registerUserDto.Password,
                CreatedBy = registerUserDto.Email,
                CreatedDate = DateTime.Now,
            };

            return user;
        }
    }
}
