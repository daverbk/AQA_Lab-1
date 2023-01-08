using System;

namespace PhoneStore.Models
{
    [Serializable]
    public class Phone
    {
        public string Model { get; set; }

        public string OperationSystemType { get; set; }

        public string MarketLaunchDate { get; set; }

        public string Price { get; set; }

        public bool IsAvailable { get; set; }

        public int ShopId { get; set; }
    }
}
