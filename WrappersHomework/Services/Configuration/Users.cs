using Microsoft.Extensions.Configuration;

namespace WrappersHomework.Services.Configuration
{
    public class Users
    {
        private static readonly IConfigurationSection UsersJsonSection =
            Configurator.Configuration.GetSection(nameof(Users));
    
        public static string Email => UsersJsonSection["Email"];
    
        public static string Password => UsersJsonSection["Password"];
    }
}
