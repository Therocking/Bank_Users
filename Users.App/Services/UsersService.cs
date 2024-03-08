using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;
using Users.App.Dtos;
using Users.App.Interfaces;
using Users.App.Services.Projections;
using Users.Infra.Repositories.Interfaces;

namespace Users.App.Services
{
    public class UsersService : IUserServices
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDto> Login(LoginUserDto loginDto)
        {
            UsersEntity? user = await _repository.GetByEmail(loginDto.Email);
            if (user is null) throw new Exception();
            return ResponseUser.EntityToDto(user);
        }

        public async Task<UserResponseDto> Register(RegisterUserDto registerDto)
        {
            UsersEntity newUser = RegisterUser.RegisterUserToUser(registerDto);
            await _repository.Add(newUser);
            return ResponseUser.EntityToDto(newUser);
        }
    }
}
