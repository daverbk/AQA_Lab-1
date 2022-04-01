using System.IO;
using System.Reflection;

namespace LocatorsHomework
{
    public static class Endpoits
    {
        private static readonly string BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string FullPathToIndex =
        $"file:{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}index.html";
    }
}
