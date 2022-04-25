using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace WrappersHomework.Services.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _configuration;
        
        public static IConfiguration Configuration => _configuration.Value;

        static Configurator()
        {
            _configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePathToAssembly = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePathToAssembly)
                .AddJsonFile("appsettings.json");
            
            var appSettingFiles = Directory.EnumerateFiles(basePathToAssembly, "appsettings.*.json");
            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}
