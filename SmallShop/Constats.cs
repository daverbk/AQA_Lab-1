namespace SmallShop
{
    public static class Constats
    {
        public static class PersonAge
        {
            // DEVNOTE: Let's assume that human starts visiting shops at age 8.
            public const int Min = 8;
            public const int Max = 100;
        }

        public static class NewProduct
        {
            public const int CountOfProductsWhenAdding = 1;
            public const int IndexOfProductWhenAdding = 0;
        }

        public static class NewUser
        {
            public const int CountOfProductsWhenCreated = 0;
        }

        public static class MainMenuOptions
        {
            public const int UserListOption = 0;
            public const int AddUserOption = 1;
            public const int ExitOption = 2;
        }

        public static class Indexes
        {
            public const int Min = 0;
            public const int ToMainMenuIndex = -1;
            public const int StartingIndexForPrint = 1;
        }

        public static class ListSubtrahend
        {
            public const int Subtrahend = 1;
        }

        public static class TimeToWait
        {
            public const int InMilliseconds = 4000;
        }

        public static class AgeToBuyAlcohol
        {
            public const int Age = 18;
        }
    }
}
