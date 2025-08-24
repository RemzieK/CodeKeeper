using CodeKeeper.Application.Interfaces;
using CodeKeeper.UI.interfaces;
using CodeKeeper.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CodeKeeper.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly IAuthService authService;
        private readonly INavigationService navigation;
        public LoginView(IAuthService authService, INavigationService navigation)
        {
            InitializeComponent();
            this.authService = authService;
            DataContext = new LoginViewModel(authService, navigation);
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Register_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var registerWindow = App.ServiceProvider.GetRequiredService<RegisterView>();
            registerWindow.Show();
            this.Close();
        }

    }
}
