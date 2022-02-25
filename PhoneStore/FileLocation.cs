using System.Reflection;

namespace PhoneStore
{
    public static class FileLocation
    {
        private const string FileName = "appsettings.json";
        public static readonly string BasePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string FullPath = $"{BasePath}{System.IO.Path.DirectorySeparatorChar}{FileName}";
    }
}
