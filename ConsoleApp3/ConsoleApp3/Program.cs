using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                MyApp app = serviceProvider.GetService<MyApp>();

                app.Run();
            }

            Console.Read();
        }

        static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole()).AddTransient<MyApp>();
        }
    }

    class MyApp
    {
        private readonly ILogger _logger;

        public MyApp(ILogger<MyApp> logger)
        {
            _logger = logger;
        }

        internal void Run()
        {
            _logger.LogInformation($"application started {DateTime.UtcNow}");

            _logger.LogInformation($"application ended {DateTime.UtcNow} ");
        }
    }
}
