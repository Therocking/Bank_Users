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
        private readonly IGenerateJWT _generateJWT;

        public UsersService(IUsersRepository repository, IEncryptPass encryptPass, IGenerateJWT generateJWT)
        {
            _repository = repository;
            _encryptPass = encryptPass;
            _generateJWT = generateJWT;
        }

        public async Task<DataResponseDto> Login(LoginUserDto loginDto)
        {
            try
            {
                UsersEntity? user = await _repository.GetByEmail(loginDto.Email) ?? throw HandleErrors.NotFound();
                string token = _generateJWT.GenerateToken(user.Email);

                bool IsCorrectPass = _encryptPass.ComparePass(user.Password, loginDto.Password);
                if (!IsCorrectPass) throw HandleErrors.IncorrectPass();

                return DataResponse.ResponseToUser(user, token);
            }
            catch (Exception ex)
            {
                if (ex is HandleErrors) throw;

                throw HandleErrors.InternalError();
            }
        }

        public async Task<DataResponseDto> Register(RegisterUserDto registerDto)
        {
            try
            {
                registerDto.Password = _encryptPass.HashPass(registerDto.Password);
                UsersEntity newUser = RegisterUser.RegisterUserToUser(registerDto);
                string token = _generateJWT.GenerateToken(newUser.Email);


                await _repository.Add(newUser);
                return DataResponse.ResponseToUser(newUser, token);
            }
            catch (Exception)
            {
                throw HandleErrors.InternalError();
            }
        }
    }
}
