using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;

namespace CodeKeeper.UI
{
    public partial class App : Application
    {
        private static IConfiguration configuration;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();
            string connString = configuration.GetConnectionString("DefaultConnection");
        }
    }

}
