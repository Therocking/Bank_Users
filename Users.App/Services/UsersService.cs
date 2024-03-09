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
        private readonly IEncryptPass _encryptPass;

        public UsersService(IUsersRepository repository, IEncryptPass encryptPass)
        {
            _repository = repository;
            _encryptPass = encryptPass;
        }

        public async Task<UserResponseDto> Login(LoginUserDto loginDto)
        {
            try
            {
                UsersEntity? user = await _repository.GetByEmail(loginDto.Email) ?? throw HandleErrors.NotFound();

                bool IsCorrectPass = _encryptPass.ComparePass(user.Password, loginDto.Password);
                if (!IsCorrectPass) throw HandleErrors.IncorrectPass();

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
                registerDto.Password = _encryptPass.HashPass(registerDto.Password);
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
