using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DBHomework.Configuration.Enums;
using Microsoft.Extensions.Configuration;

namespace DBHomework.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> Config;
        private static List<User> _users = null!;
        private static AppSettings _appSettings = null!;
        private static DbSettings _dbSettings = null!;

        private static IConfiguration Configuration => Config.Value;

        public static AppSettings AppSettings =>
            _appSettings ??
            throw new NullReferenceException(
                "App settings in appsettings.json are empty. Fill it before the next restart.");
        
        public static User Admin =>
            _users.Find(x => x.UserType == UserType.Admin) ??
            throw new NullReferenceException(
                "Users array in appsettings.json is empty. Fill it before the next restart.");

        public static User User =>
            _users.Find(x => x.UserType == UserType.User) ??
            throw new NullReferenceException(
                "Users array in appsettings.json is empty. Fill it before the next restart.");

        public static DbSettings DbSettings =>
            _dbSettings ??
            throw new NullReferenceException(
                "Data base settings in appsettings.json is empty. Fill it before the next restart.");

        static Configurator()
        {
            Config = new Lazy<IConfiguration>(BuildConfiguration);
            FormAppSettings();
            FormUsersList();
            FormDbSettings();
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

        private static void FormAppSettings()
        {
            var appSettingsSection = Configuration.GetSection(nameof(AppSettings));

            _appSettings = new AppSettings
            {
                BaseUrl = appSettingsSection["BaseUrl"]
            };
        }
        
        private static void FormDbSettings()
        {
            var dbSettingsSection = Configuration.GetSection(nameof(DbSettings));

            _dbSettings = new DbSettings
            {
                Driver = dbSettingsSection["DB_Driver"],
                Server = dbSettingsSection["DB_Server"],
                Port = dbSettingsSection["DB_Port"],
                Schema = dbSettingsSection["DB_Schema"],
                Username = dbSettingsSection["DB_Username"],
                Password = dbSettingsSection["DB_Password"]
            };
        }
        
        private static void FormUsersList()
        {
            var usersSection = Configuration.GetSection(nameof(User));
            _users = new List<User>();

            foreach (var usersArrayMember in usersSection.GetChildren())
            {
                var user = new User
                {
                    Email = usersArrayMember["Email"], Password = usersArrayMember["Password"]
                };
                user.UserType = usersArrayMember["UserType"].ToLower() switch
                {
                    "admin" => UserType.Admin,
                    "user" => UserType.User,
                    _ => user.UserType
                };

                _users.Add(user);
            }
        }
    }
}
