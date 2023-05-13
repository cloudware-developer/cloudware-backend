using MediatR;

namespace Cloudware.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool Status { get; set; }

        public DateTime? EditedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public UpdateUserCommand()
        {
        }

        public UpdateUserCommand(int userId, string? name, string? email, string? password, bool status, DateTime? editedAt, DateTime? createdAt)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            Status = status;
            EditedAt = editedAt;
            CreatedAt = createdAt;
        }
    }
}
