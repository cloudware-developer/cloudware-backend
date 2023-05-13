using MediatR;

namespace Cloudware.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }

        public DeleteUserCommand() { }

        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }
    }
}
