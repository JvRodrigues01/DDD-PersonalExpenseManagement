using MediatR;
using PEM.Application.Models;

namespace PEM.Application.Commands.Auth
{
    public class AuthCommand : IRequest<BaseResult<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
