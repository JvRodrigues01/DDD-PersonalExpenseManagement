using MediatR;
using Microsoft.AspNetCore.Identity;
using PEM.Application.Models;
using PEM.Domain.Repositories;

namespace PEM.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResult<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<Domain.Entities.User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<BaseResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already in use");
            }

            var user = new Domain.Entities.User(request.FirstName, request.LastName, request.Email, request.Password);
            var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
            user.UpdatePasswordHash(hashedPassword);

            await _userRepository.AddAsync(user);

            return new BaseResult<Guid>(user.Id);
        }
    }
}
