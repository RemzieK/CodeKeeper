using System;
using System.IO;
using System.Windows; 
using CodeKeeper.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CodeKeeper.Application.Interfaces;
using CodeKeeper.Application.Services;
using CodeKeeper.Infrastructure.Hashing;
using CodeKeeper.Infrastructure.Repositories;
using CodeKeeper.Infrastructure.Data;
using CodeKeeper.UI.Views;
using CodeKeeper.UI.ViewModels;
using CodeKeeper.UI.interfaces;
using CodeKeeper.UI.services;


namespace CodeKeeper.UI
{
    public partial class App : System.Windows.Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Build configuration
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = configurationBuilder.Build();

            // Setup DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Resolve and show the login window **after** ServiceProvider is ready
            var loginWindow = ServiceProvider.GetRequiredService<LoginView>();
            loginWindow.Show();
        }


        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            // EF Core DB context
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPasswordHashing, PasswordHasher>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Views
            services.AddTransient<LoginView>();
            services.AddTransient<RegisterView>();
            services.AddTransient<MainWindow>();

            // ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<MainViewModel>();
        }


    }
}
