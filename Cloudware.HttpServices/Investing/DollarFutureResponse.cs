namespace Cloudware.HttpServices.Investing
{
    public class DollarFutureResponse
    {
        /// <summary>
        /// Cotação de fechamento do dia anterior.
        /// </summary>
        public Decimal LastDayCloseQuotation { get; set; }

        /// <summary>
        /// Cotação atual.
        /// </summary>
        public Decimal CurrentQuotation { get; set; }

        /// <summary>
        /// Cotação máxima atual.
        /// </summary>
        public Decimal CurrentMaximumQuotation { get; set; }

        /// <summary>
        /// Cotação mínima atual.
        /// </summary>
        public Decimal CurrentMinimumQuotation { get; set; }

        /// <summary>
        /// Data atual da consulta.
        /// </summary>
        private DateTime Date { get; set; } = DateTime.Now;

        public DollarFutureResponse() { }

        public DollarFutureResponse(decimal lastDayCloseQuotation, decimal currentQuotation, decimal currentMaximumQuotation, decimal currentMinimumQuotation)
        {
            LastDayCloseQuotation = lastDayCloseQuotation;
            CurrentQuotation = currentQuotation;
            CurrentMaximumQuotation = currentMaximumQuotation;
            CurrentMinimumQuotation = currentMinimumQuotation;
        }
    }
}
