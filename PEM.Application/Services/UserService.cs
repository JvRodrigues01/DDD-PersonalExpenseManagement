using MediatR; 
using PEM.Application.Commands.User.CreateUser;
using PEM.Application.Models;

namespace PEM.Application.Services
{
    public class UserService
    {
        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<BaseResult<Guid>> CreateUserAsync(string firstName, string lastName, string email, string password)
        {
            var command = new CreateUserCommand
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            return await _mediator.Send(command);
        }
    }
}
