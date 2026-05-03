using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zohal.DependencyInjection;

namespace Test
{
    internal static class Program
    {
        public static IServiceProvider? Services;

        [STAThread]
        static void Main()
        {
            // ساخت Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            // خواندن تنظیمات Zohal از Configuration
            services.AddZohal(options =>
            {
                options.BaseUrl = configuration["Zohal:BaseUrl"]!;
                options.Token =
                    configuration["Zohal:Token"]
                    ?? configuration["ZOHAL__TOKEN"]
                    ?? throw new InvalidOperationException("Zohal Token is not configured.");
            });

            // ثبت فرم
            services.AddTransient<Form1>();

            Services = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            Application.Run(Services.GetRequiredService<Form1>());
        }
    }
}
