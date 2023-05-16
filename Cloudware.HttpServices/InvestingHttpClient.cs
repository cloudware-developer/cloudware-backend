using Cloudware.HttpServices.Investing;
using HtmlAgilityPack;

namespace Cloudware.HttpServices
{
    public interface IInvestingHttpClient
    {
        /// <summary>
        /// Obtem a cotação do dolar futuro.
        /// </summary>
        public Task<DollarFutureResponse> ObtainFutureCotationDollar();

        /// <summary>
        /// Obtem eventos de calendario econômico.
        /// </summary>
        /// <returns></returns>
        public Task<EconomicCalendarResponse> ObtainEconomicCalendar();
    }

    public class InvestingHttpClient : IInvestingHttpClient
    {
        public readonly HttpClient _client;

        public InvestingHttpClient(HttpClient client)
        {
            _client = client; 
        }

        /// <summary>
        /// Obtem a cotação do dolar futuro.
        /// </summary>
        public async Task<DollarFutureResponse> ObtainFutureCotationDollar()
        {
            try
            {
                using (_client)
                {
                    var contentString = await _client.GetStringAsync("/currencies/usd-brl");

                    if (string.IsNullOrEmpty(contentString))
                        throw new ArgumentException("Conteúdo inexistente.");

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(contentString);

                    try
                    {
                        // https://medium.com/@thepen0411/web-crawling-tutorial-in-c-48d921ef956a
                        return new DollarFutureResponse();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtem eventos de calendario econômico.
        /// </summary>
        /// <returns></returns>
        public async Task<EconomicCalendarResponse> ObtainEconomicCalendar()
        {
            try
            {
                using (_client)
                {
                    var contentString = await _client.GetStringAsync("/currencies/usd-brl");

                    if (string.IsNullOrEmpty(contentString))
                        throw new ArgumentException("Conteúdo inexistente.");

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(contentString);

                    try
                    {
                        // https://medium.com/@thepen0411/web-crawling-tutorial-in-c-48d921ef956a
                        return new EconomicCalendarResponse();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
