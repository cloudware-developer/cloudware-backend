using Cludware.Repository.Entities;
using MediatR;

namespace Cloudware.Application.Queries.Log
{
    public class ObtainLogQuery : IRequest<LogAuthenticationEntity>
    {
        public int LogId { get; set; }

        public ObtainLogQuery() { }

        public ObtainLogQuery(int logId)
        {
            LogId = logId;
        }
    }
}
