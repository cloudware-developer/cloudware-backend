using Cloudware.Core.Infra.Enums;
using Cloudware.Core.Infra.Pagination;
using Cludware.Repository.Entities;
using MediatR;

namespace Cloudware.Application.Queries.Log
{
    public class ObtainLogCollectionQuery : 
        IRequest<List<LogAuthenticationEntity>>, 
        ISortable, 
        IPaginable, 
        IQuery<List<LogAuthenticationEntity>>
    {
        public int LogId { get; set; }

        public int UserId { get; set; }

        public string? Serialized { get; set; }

        public ETypeLog TypeLog { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Pagination Pagination { get; set; } = new Pagination();

        public SortField SortField { get; set; } = new SortField();

        public ObtainLogCollectionQuery() { }

        public ObtainLogCollectionQuery(int logId, int userId, string? serialized, ETypeLog typeLog, DateTime? createdAt)
        {
            LogId = logId;
            UserId = userId;
            Serialized = serialized;
            TypeLog = typeLog;
            CreatedAt = createdAt;
        }

        public ObtainLogCollectionQuery(int logId, int userId, string? serialized, ETypeLog typeLog, DateTime? createdAt, Pagination pagination, SortField sortField)
        {
            LogId = logId;
            UserId = userId;
            Serialized = serialized;
            TypeLog = typeLog;
            CreatedAt = createdAt;
            Pagination = pagination;
            SortField = sortField;
        }
    }
}
