using MediatR;
using PEM.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace PEM.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<BaseResult<Guid>>
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Password { get; set; }
    }
}
