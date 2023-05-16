using Cloudware.HttpServices.Melhorcambio;
using HtmlAgilityPack;

namespace Cloudware.HttpServices
{
    public interface IMelhorcambioHttpClient
    {
        /// <summary>
        /// Obtem a cotação atual da taxa selic.
        /// </summary>
        public Task<SelicRateResponse> ObtainSelicRate();

        /// <summary>
        /// Obtem a cotação do dolar futuro.
        /// </summary>
        public Task<DollarFutureResponse> ObtainFutureCotationDollar();
    }

    public class MelhorcambioHttpClient : IMelhorcambioHttpClient
    {
        public readonly HttpClient _client;

        public MelhorcambioHttpClient(HttpClient client)
        {
            _client = client; 
        }

        /// <summary>
        /// Obtem a cotação atual da taxa selic.
        /// </summary>
        public async Task<SelicRateResponse> ObtainSelicRate()
        {
            try
            {
                using (_client)
                {
                    var contentString = await _client.GetStringAsync("/taxa-selic");

                    if (string.IsNullOrEmpty(contentString))
                        throw new ArgumentException("Conteúdo inexistente.");

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(contentString);

                    try
                    {
                        //https://www.melhorcambio.com/taxa-selic
                        return new SelicRateResponse();
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
        /// Obtem a cotação do dolar futuro.
        /// </summary>
        public async Task<DollarFutureResponse> ObtainFutureCotationDollar()
        {
            try
            {
                using (_client)
                {
                    var contentString = await _client.GetStringAsync("/dolar-hoje");

                    if (string.IsNullOrEmpty(contentString))
                        throw new ArgumentException("Conteúdo inexistente.");

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(contentString);

                    try
                    {
                        //https://www.melhorcambio.com/dolar-hoje
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
    }
}
