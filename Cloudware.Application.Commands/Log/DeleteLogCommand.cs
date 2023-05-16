using Cloudware.Core.Infra.Enums;
using MediatR;

namespace Cloudware.Application.Commands.Log
{
    public class DeleteLogCommand : IRequest<bool>
    {
        public int LogId { get; set; }

        public ETypeLog TypeLog { get; set; }
    }
}
