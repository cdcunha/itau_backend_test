using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace ItauBackend
{
    class Program
    {
        public static IHost Host { get; set; }

        static void Main(string[] args)
        {
            Host = CreateHostBuilder(args).Build();
            Host.Run();


            //Configuration["ConnectionStrings:DefaultConnection"];

            ///var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();

            //ServiceCollection serviceCollection = new ServiceCollection();
            //serviceCollection.AddSingleton(configuration);
            //configuration.GetSection("MySettings").Bind(mySettingsConfig);
            Console.WriteLine("teste");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Host);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            new HostBuilder()
                .ConfigureHostConfiguration(config =>
                {
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(AppContext.BaseDirectory) //Directory.GetCurrentDirectory()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                });
    }
}
