namespace CurrencyConvertor
{
    public static class Currency
    {
        public const string UsdType = "USD";
        public const string EurType = "EUR";
        public const string RubType = "RUB";
        
        public static decimal UsdValue { get; set; }
        public static decimal EurValue { get; set; }
        public static decimal RubValue { get; set; }
    }
}
