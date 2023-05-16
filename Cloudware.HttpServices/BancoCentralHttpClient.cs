using Cloudware.HttpServices.BancoCentral;
using HtmlAgilityPack;

namespace Cloudware.HttpServices
{
    public interface IIBancoCentralHttpClient
    {
        /// <summary>
        /// Obtem a cotação atual do da Taxa Selic.
        /// </summary>
        /// <returns>Retorna objeto <see cref="SelicRateResponse">SelicRateResponse</see>.</returns>
        public Task<SelicRateResponse> ObtainSelicRate();
    }

    public class BancoCentralHttpClient : IIBancoCentralHttpClient
    {
        public readonly HttpClient _client;

        public BancoCentralHttpClient(HttpClient client)
        {
            _client = client; 
        }

        /// <summary>
        /// Obtem a cotação atual do da Taxa Selic.
        /// </summary>
        /// <returns>Retorna objeto <see cref="SelicRateResponse">SelicRateResponse</see>.</returns>
        public async Task<SelicRateResponse> ObtainSelicRate()
        {
            try
            {
                using (_client)
                {
                    var contentString = await _client.GetStringAsync("/controleinflacao/historicotaxasjuros");

                    if (string.IsNullOrEmpty(contentString))
                        throw new ArgumentException("Conteúdo inexistente.");

                    var htmlDocument = new HtmlDocument();
                    htmlDocument.LoadHtml(contentString);

                    try
                    {
                        // https://medium.com/@thepen0411/web-crawling-tutorial-in-c-48d921ef956a
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
    }
}
