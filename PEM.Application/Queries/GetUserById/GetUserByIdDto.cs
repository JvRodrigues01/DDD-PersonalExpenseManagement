using PEM.Domain.Entities;

namespace PEM.Application.Queries.GetUserById
{
    public class GetUserByIdDto
    {
        public GetUserByIdDto(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}