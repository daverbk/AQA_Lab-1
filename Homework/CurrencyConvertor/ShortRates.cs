using Newtonsoft.Json;

namespace CurrencyConvertor
{
    public class RateShort
    {
        [JsonProperty("Cur_OfficialRate")] 
        public decimal Cur_OfficialRate { get; set; }
    }
}
