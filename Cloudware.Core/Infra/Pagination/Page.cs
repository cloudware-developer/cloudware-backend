namespace Cloudware.Core.Infra.Pagination
{
    public class Page<TEntity>
    {
        public int Total { get; set; }
        public TEntity Items { get; set; }
        public Page()
        {
        }
    }
}
