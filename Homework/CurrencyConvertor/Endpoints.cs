namespace CurrencyConvertor
{
    public static class Endpoints
    {
        private const string ServiceUrl = "https://www.nbrb.by";
        private const string ApiPrefix = "/api";
        public static readonly string UsdRate = $"{ServiceUrl}{ApiPrefix}/exrates/rates/431";
        public static readonly string EurRate = $"{ServiceUrl}{ApiPrefix}/exrates/rates/451";
        public static readonly string RubRate = $"{ServiceUrl}{ApiPrefix}/exrates/rates/456";
    }
}
