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

        /// <summary>
        /// Obtem a quantidade e data de lelão de dolar feito pelo Banco Central.
        /// </summary>
        /// <returns>Retorna objeto <see cref="DollarAuctionResponse">SelicRateResponse</see>.</returns>
        Task<DollarAuctionResponse> ObtainDollarAuction();

        /// <summary>
        /// Obtem os Dealers de mercado intitulado pelo Banco Central.
        /// </summary>
        /// <returns>Retorna objeto <see cref="DealersResponse">DealersResponse</see>.</returns>
        Task<DealersResponse> ObtainDealers();

        /// <summary>
        /// Obtem o histórico da Taxa Selic.
        /// </summary>
        /// <returns>Retorna objeto <see cref="List{SelicRateResponse}<>">List<SelicRateResponse></see>.</returns>
        Task<List<SelicRateResponse>> ObtainSelicRateHistory();
    }

    public class BancoCentralHttpClient : IIBancoCentralHttpClient
    {
        public readonly HttpClient _client;

        public BancoCentralHttpClient(HttpClient client)
        {
            _client = client; 
        }

        /// <summary>
        /// Obtem a quantidade e data de lelão de dolar feito pelo Banco Central.
        /// </summary>
        /// <returns>Retorna objeto <see cref="DollarAuctionResponse">SelicRateResponse</see>.</returns>
        public async Task<DollarAuctionResponse> ObtainDollarAuction()
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
                        return new DollarAuctionResponse();
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

        /// <summary>
        /// Obtem os Dealers de mercado intitulado pelo Banco Central.
        /// </summary>
        /// <returns>Retorna objeto <see cref="DealersResponse">DealersResponse</see>.</returns>
        public async Task<DealersResponse> ObtainDealers()
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
                        return new DealersResponse();
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
        /// Obtem o histórico da Taxa Selic.
        /// </summary>
        /// <returns>Retorna objeto <see cref="List{SelicRateResponse}<>">List<SelicRateResponse></see>.</returns>
        public async Task<List<SelicRateResponse>> ObtainSelicRateHistory()
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
                        //        https://www.bcb.gov.br/controleinflacao/historicotaxasjuros
                        return new List<SelicRateResponse>();
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
