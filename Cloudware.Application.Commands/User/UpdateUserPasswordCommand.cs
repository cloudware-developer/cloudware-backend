using MediatR;

namespace Cloudware.Application.Commands.User
{
    public class UpdateUserPasswordCommand : IRequest<bool>
    {
        public int UserId { get; set; }

        public string? Password { get; set; }

        public UpdateUserPasswordCommand()
        {
        }

        public UpdateUserPasswordCommand(int userId, string? password)
        {
            UserId = userId;
            Password = password;
        }
    }
}
