using MediatR;
using PEM.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace PEM.Application.Commands.Auth
{
    public class AuthCommand : IRequest<BaseResult<string>>
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Password { get; set; }
    }
}
