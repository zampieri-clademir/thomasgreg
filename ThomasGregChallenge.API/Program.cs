using Microsoft.AspNetCore;

using System.Diagnostics.CodeAnalysis;

namespace ThomasGregChallenge.API
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)                          
                          .ConfigureAppConfiguration(config =>
                          {
                              config.AddJsonFile("appsettings.json", optional: true);
                              config.AddEnvironmentVariables();

                              if (args != null && args.Length > 0)
                                  config.AddCommandLine(args);
                          })
                          .UseStartup<Startup>();

        }

    }
}
