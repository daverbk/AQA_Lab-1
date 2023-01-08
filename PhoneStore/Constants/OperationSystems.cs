using System.Collections.Generic;

namespace PhoneStore.Constants
{
    public static class OperationSystems
    {
        public const string Android = "Android";
        public const string Ios = "IOS";

        public static readonly List<string> AllOperationSystems = new()
        {
            Android,
            Ios
        };
    }
}
