namespace Cludware.Repository.Entities
{
    public class LogAuthenticationEntity
    {
        public int LogId { get; set; }

        public int UserId { get; set; }

        public string? Serialized { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public LogAuthenticationEntity(int userId, string? serialized)
        {
            UserId = userId;
            Serialized = serialized;
        }
    }
}
