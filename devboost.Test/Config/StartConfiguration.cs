using Microsoft.Extensions.Configuration;
using System.IO;

namespace devboost.Test.Config
{
    public static class StartConfiguration
    {
        public static IConfiguration Configuration { get; private set; }

        static StartConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}
