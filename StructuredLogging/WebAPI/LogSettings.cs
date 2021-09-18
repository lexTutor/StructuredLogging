using Microsoft.Extensions.Configuration;
using Raven.Client.Documents;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace WebAPI
{
    public static class LogSettings
    {
        public static void SetupSerilog(IConfiguration config)
        {
            DocumentStore ravenStore = new DocumentStore
            {
                Urls = new string[] { config["RavenDBConfigurations:ConnectionURL"] },
                Database = config["RavenDBConfigurations:DatabaseName"],
            };

            ravenStore.Certificate =  new X509Certificate2(config["RavenDBConfigurations:CertificateFilePath"],
            config["RavenDBConfigurations:Password"], X509KeyStorageFlags.MachineKeySet);

            ravenStore.Initialize();

            ILogger logger = new LoggerConfiguration()
                .WriteTo.File("Logs.txt",
                restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.RavenDB(ravenStore)
                .CreateLogger();

            Log.Logger = logger;
        }
    }
}
