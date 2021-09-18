using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public static class ConfigurationSetUp
    {
        public static IConfiguration GetConfig(bool isDevelopment)
        {
            return isDevelopment ? new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build()
            :
             new ConfigurationBuilder()
                    .AddEnvironmentVariables(prefix: "RavenDBConfigurations")
                  .Build();

        }
    }
}
