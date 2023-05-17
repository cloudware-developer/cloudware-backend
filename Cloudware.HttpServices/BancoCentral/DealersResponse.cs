namespace Cloudware.HttpServices.BancoCentral
{
    public class DealersResponse
    {
        /// <summary>
        /// Período inicial dos dealers.
        /// </summary>
        public DateTime StartPeriod { get; set; }

        /// <summary>
        /// Período final dos dealers.
        /// </summary>
        public DateTime EndPeriod { get; set; }

        /// <summary>
        /// Lista de nome dos dealers.
        /// </summary>
        public List<string> Names { get; set; } = new List<string>();

        public DealersResponse() { }

        public DealersResponse(DateTime startPeriod, DateTime endPeriod, List<string> names)
        {
            StartPeriod = startPeriod;
            EndPeriod = endPeriod;
            Names = names;
        }
    }
}
