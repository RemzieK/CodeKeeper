using CodeKeeper.UI.interfaces;
using CodeKeeper.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeKeeper.UI.services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateToMain()
        {
            // Open MainWindow from DI
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            // Close LoginView
            System.Windows.Application.Current.Windows
                .OfType<LoginView>()
                .FirstOrDefault()?.Close();
        }
    }


}
