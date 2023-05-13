using static Dapper.SqlMapper;

namespace Cludware.Repository.Entities
{
    public class CompanyEntity : Base
    {
        /// <summary>
        /// Código interno do banco de dados.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Cnpj da empresa.
        /// </summary>
        public int LegalEntityId { get; set; }

        /// <summary>
        /// Inscrição estadual da empresa.
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Inscrição municipal da empresa.
        /// </summary>
        public int MunicipalId { get; set; }

        /// <summary>
        /// Nome da Empresa.
        /// </summary>
        public string? LegalEntityName { get; set; }

        /// <summary>
        /// Nome fantazia da Empresa.
        /// </summary>
        public string? LegalFantasyName { get; set; }

        /// <summary>
        /// Email da Empresa.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Telefone celular principal da Empresa.
        /// </summary>
        public int Cellphone { get; set; }

        /// <summary>
        /// Telefone fixo da empresa.
        /// </summary>
        public int Landline { get; set; }

        /// <summary>
        /// Status de Ativo ou não Ativo.
        /// </summary>
        public bool Status { get; set; }
    }
}
