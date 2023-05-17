namespace Cloudware.HttpServices.BancoCentral
{
    public class DollarAuctionResponse
    {
        /// <summary>
        /// Quantidade de dolars que o Banco central fara o leilão.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Data da execução do leilão.
        /// </summary>
        public DateTime Date { get; set; }

        public DollarAuctionResponse() { }

        public DollarAuctionResponse(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}
