using MediatR;
using PEM.Application.Models;

namespace PEM.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<BaseResult<GetUserByIdDto>>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
