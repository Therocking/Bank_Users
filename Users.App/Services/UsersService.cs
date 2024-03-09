using Bank_Users.Domain.Entites;
using Users.App.Dtos;
using Users.App.Interfaces;
using Users.App.Services.Helpers;
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
            try
            {
                UsersEntity? user = await _repository.GetByEmail(loginDto.Email) ?? throw HandleErrors.NotFound();

                return ResponseUser.EntityToDto(user);
            }
            catch (Exception ex)
            {
                if (ex is HandleErrors) throw;

                throw HandleErrors.InternalError();
            }
        }

        public async Task<UserResponseDto> Register(RegisterUserDto registerDto)
        {
            try
            {
                UsersEntity newUser = RegisterUser.RegisterUserToUser(registerDto);
                await _repository.Add(newUser);
                return ResponseUser.EntityToDto(newUser);
            }
            catch (Exception)
            {
                throw HandleErrors.InternalError();
            }
        }
    }
}
