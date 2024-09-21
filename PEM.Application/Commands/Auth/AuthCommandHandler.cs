using MediatR;
using Microsoft.AspNetCore.Identity;
using PEM.Application.Models;
using PEM.Application.Services;
using PEM.Domain.Repositories;

namespace PEM.Application.Commands.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, BaseResult<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        private readonly JwtTokenService _jwtTokenService;

        public AuthCommandHandler(IUserRepository userRepository, IPasswordHasher<Domain.Entities.User> passwordHasher, JwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<BaseResult<string>> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user is null)
            {
                return new BaseResult<string>(null, false, "Invalid credentials");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return new BaseResult<string>(null, false, "Invalid credentials");
            }

            var token = _jwtTokenService.GenerateToken(user);

            return new BaseResult<string>(token);
        }
    }
}
