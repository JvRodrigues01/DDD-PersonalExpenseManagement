using MediatR;
using PEM.Application.Models;

namespace PEM.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<BaseResult<Guid>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
