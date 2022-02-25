namespace PhoneStore
{
    public class Phone
    {
        public string Model { get; set; }

        public string OperationSystemType { get; set; }

        public string MarketLaunchDate { get; set; }

        public int Price { get; set; }

        public bool IsAvailable { get; set; }

        public int ShopId { get; set; }

        public bool ShouldSerializeIsAvailable()
        {
            return false;
        }

        public bool ShouldSerializeShopId()
        {
            return false;
        }
    }
}
