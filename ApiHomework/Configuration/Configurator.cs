using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ApiHomework.Configuration.Enums;
using Microsoft.Extensions.Configuration;

namespace ApiHomework.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _configuration;
        private static List<User> _users = null!;
        private static AppSettings _appSettings = null!;

        private static IConfiguration Configuration => _configuration.Value;

        public static User Admin =>
            _users.Find(x => x.UserType == UserType.Admin) ??
            throw new NullReferenceException(
                "Users array in appsettings.json is empty. Fill it before the next restart.");

        public static User User =>
            _users.Find(x => x.UserType == UserType.User) ??
            throw new NullReferenceException(
                "Users array in appsettings.json is empty. Fill it before the next restart.");

        public static AppSettings AppSettings =>
            _appSettings ??
            throw new NullReferenceException(
                "App settings in appsettings.json are empty. Fill it before the next restart.");

        static Configurator()
        {
            _configuration = new Lazy<IConfiguration>(BuildConfiguration);
            FormUsersList();
            FormAppSettings();
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }

        private static void FormUsersList()
        {
            var usersJsonSection = Configuration.GetSection(nameof(User));
            _users = new List<User>();

            foreach (var jsonUsersArrayMember in usersJsonSection.GetChildren())
            {
                var user = new User
                {
                    Email = jsonUsersArrayMember["Email"], Password = jsonUsersArrayMember["Password"]
                };
                user.UserType = jsonUsersArrayMember["UserType"].ToLower() switch
                {
                    "admin" => UserType.Admin,
                    "user" => UserType.User,
                    _ => user.UserType
                };

                _users.Add(user);
            }
        }

        private static void FormAppSettings()
        {
            var appSettingsJsonSection = Configuration.GetSection(nameof(AppSettings));

            _appSettings = new AppSettings
            {
                BaseUrl = appSettingsJsonSection["BaseUrl"]
            };
        }
    }
}
