namespace Cludware.Repository.Entities
{
    public class Base
    {
        /// <summary>
        /// Data da última edição.
        /// </summary>
        public DateTime? EditedAt { get; set; }

        /// <summary>
        /// Data da cadastro.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
    }
}
