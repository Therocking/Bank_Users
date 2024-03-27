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
        private readonly IRoleRepository _rolesRepository;
        private readonly IEncryptPass _encryptPass;
        private readonly IGenerateJWT _generateJWT;

        public UsersService(IUsersRepository repository, IEncryptPass encryptPass, IGenerateJWT generateJWT, IRoleRepository rolesRepository)
        {
            _repository = repository;
            _encryptPass = encryptPass;
            _generateJWT = generateJWT;
            _rolesRepository = rolesRepository;
        }

        public async Task<DataResponseDto> Login(LoginUserDto loginDto, CancellationToken cancellationToken = default)
        {
            UsersEntity? user = await _repository.GetByEmail(loginDto.Email, cancellationToken) ?? throw HandleErrors.NotFound();
            string token = _generateJWT.GenerateToken(user.Email);

            bool IsCorrectPass = _encryptPass.ComparePass(user.Password, loginDto.Password);
            if (!IsCorrectPass) throw HandleErrors.IncorrectPass();

            return DataResponse.ResponseToUser(user, token);
        }

        public async Task<DataResponseDto> Register(RegisterUserDto registerDto, CancellationToken cancellationToken = default)
        {
            registerDto.Password = _encryptPass.HashPass(registerDto.Password);
            UsersEntity newUser = RegisterUser.RegisterUserToUser(registerDto);
            string token = _generateJWT.GenerateToken(newUser.Email);

            RolesEntity? role = await _rolesRepository.GetByName("user", cancellationToken);
            if(role is null)
            {
                RolesEntity roleEntity = new RolesEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "user",
                    CreatedBy = "Anonymus",
                    CreatedDate = DateTimeOffset.Now,
                    IsDeleted = false,
                };
                role = await _rolesRepository.Add(roleEntity, cancellationToken);
            }

            var UserRole = new UsersRolesEntity
            {
                Id = Guid.NewGuid().ToString(),
                RoleId = role.Id,
                UserId = newUser.Id,
            };

            await _repository.Add(newUser, UserRole, cancellationToken);
            return DataResponse.ResponseToUser(newUser, token);
        }
    }
}
