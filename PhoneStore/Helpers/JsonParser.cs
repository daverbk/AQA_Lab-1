using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using PhoneStore.Models;

namespace PhoneStore.Helpers
{
    public static class JsonParser
    {
        private const string FileName = "appsettings.json";
        public static readonly string? BasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string FullPath = $"{BasePath}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{FileName}";

        public static void DeserializeJsonFile()
        {
            var parsedAppsettings = ReadAppsettingsToString();
            ProgramData.RootObject = JsonSerializer.Deserialize<RootObject>(parsedAppsettings)
                ?? throw new JsonException($"Json is in incorrect format. Check {FileName}.");
        }

        private static string ReadAppsettingsToString()
        {
            try
            {
                return File.ReadAllText(FullPath);
            }
            catch (FileNotFoundException e)
            {
                var exceptionMessage = "There is an exception because of which we can't go on for today, sorry :(\n" +
                    e.Message;

                Console.WriteLine(exceptionMessage);
                throw;
            }
        }
    }
}
