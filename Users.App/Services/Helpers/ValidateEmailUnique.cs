using Users.Infra.Repositories.Interfaces;

namespace Users.App.Services.Helpers
{
    public class ValidateEmailUnique
    {
        private readonly IUsersRepository _repository;

        public ValidateEmailUnique(IUsersRepository repository)
        {
            _repository = repository;
        }

        public bool IsEmailUnique(string email, CancellationToken cancellationToken = default)
        {
            var customer = _repository.GetByEmail(email, cancellationToken);

            return customer == null;
        }

    }
}
