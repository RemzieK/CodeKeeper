using CodeKeeper.Application.Interfaces;
using CodeKeeper.UI.interfaces;
using CodeKeeper.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CodeKeeper.UI.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        private readonly RegisterViewModel viewModel;
        private readonly IAuthService authService;
        private readonly INavigationService navigation;
        public RegisterView(IAuthService authService, INavigationService navigation)
        {
            InitializeComponent();
            viewModel = new RegisterViewModel(authService, navigation); 
            DataContext = viewModel;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMinimizeReg_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCloseReg_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Login_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var loginWindow = App.ServiceProvider.GetRequiredService<LoginView>();
            loginWindow.Show();
            this.Close();
        }

    }
}
