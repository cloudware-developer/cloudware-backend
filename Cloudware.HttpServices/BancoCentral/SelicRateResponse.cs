namespace Cloudware.HttpServices.BancoCentral
{
    public class SelicRateResponse
    {
        /// <summary>
        /// Cotação atual da taxa selic.
        /// </summary>
        public Decimal CurrentQuotation { get; set; }

        /// <summary>
        /// Data de divulgação da taxa.
        /// </summary>
        public DateTime Date { get; set; }

        public SelicRateResponse() { }

        public SelicRateResponse(decimal currentQuotation, DateTime date)
        {
            CurrentQuotation = currentQuotation;
            Date = date;
        }
    }
}
