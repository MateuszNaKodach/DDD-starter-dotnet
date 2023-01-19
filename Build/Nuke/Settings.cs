using Microsoft.Extensions.Configuration;
using MyCompany.Crm.Nuke.Elastic;
using MyCompany.Crm.Nuke.Helpers;
using MyCompany.Crm.Nuke.Postgres;
using static MyCompany.Crm.Nuke.Paths;

namespace MyCompany.Crm.Nuke
{
    public static class Settings
    {
        public static ElasticSettings Elastic { get; }
        public static PostgresSettings Postgres { get; }

        static Settings()
        {
            var configurationRoot = GetConfigurationRoot(Build.Environment);
            Elastic = configurationRoot.GetSection(ElasticSettings.Key).Get<ElasticSettings>();
            Postgres = configurationRoot.GetSection(PostgresSettings.Key).Get<PostgresSettings>();
        }

        private static IConfigurationRoot GetConfigurationRoot(Environment environment)
        {
            const string secretsId = "MyCompanyCrm";
            const string environmentVariablesPrefix = "MYCOMPANY_CRM_";
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(NukeDirectory / "settings.json", optional: true, reloadOnChange: false)
                .AddJsonFile(NukeDirectory / $"settings.{environment.ValueToLower()}.json", true, false);
            if (environment.Equals(Environment.Development))
                configurationBuilder.AddUserSecrets(secretsId);
            configurationBuilder.AddEnvironmentVariables(environmentVariablesPrefix);
            return configurationBuilder.Build();
        }
    }
}