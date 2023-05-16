using Cloudware.Core.Infra.Enums;
using MediatR;

namespace Cloudware.Application.Commands.Log
{
    public class CreateLogCommand : IRequest<bool>
    {
        public int LogId { get; set; }

        public int UserId { get; set; }

        public string? Serialized { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public ETypeLog TypeLog { get; set; }

        public CreateLogCommand() {}

        public CreateLogCommand(int logId, int userId, string? serialized, DateTime? createdAt)
        {
            LogId = logId;
            UserId = userId;
            Serialized = serialized;
            CreatedAt = createdAt;
        }
    }
}
