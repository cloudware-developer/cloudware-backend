namespace Cludware.Repository.Entities
{
    public class UserEntity : Base
    {
        /// <summary>
        /// Codigo interno.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Senha de acesso do usuário
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Token de autenticação do usuário.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Status de Ativo ou não Ativo.
        /// </summary>
        public bool Status { get; set; }
    }
}
