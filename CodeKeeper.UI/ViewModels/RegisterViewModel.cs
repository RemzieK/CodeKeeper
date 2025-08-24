using CodeKeeper.Application.DTOs;
using CodeKeeper.Application.Interfaces;
using CodeKeeper.UI.interfaces;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CodeKeeper.UI.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public IAuthService AuthService => _authService;
        private readonly IAuthService _authService;
        private readonly INavigationService navigation;

        public IAsyncRelayCommand RegisterCommand { get; }

        private string email;
        private string username;
        private string password;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public RegisterViewModel(IAuthService authService, INavigationService navigation)
        {
            _authService = authService;
            this.navigation = navigation;
            RegisterCommand = new AsyncRelayCommand(RegisterAsync);
        }

        private async Task RegisterAsync()
        {
            try
            {
                var dto = new RegisterDTO
                {
                    Email = Email,
                    Name = Username,
                    Password = Password
                };

                await _authService.RegisterAsync(dto);
                MessageBox.Show("Registration successful ✅");

                navigation.NavigateToMain();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed ❌: {ex.Message}");
            }
        }
    }

}
