namespace AllureExtensionsFluentAssertionsHomework.Extensions
{
    public static class StringExtension
    {
        public static bool IsEqualTo(this string str, string comparedStr)
        {
            return str == comparedStr;
        }
    }
}
