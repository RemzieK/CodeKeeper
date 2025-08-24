using System.Windows;
using System.Windows.Input;
using CodeKeeper.Application.Services;
using CodeKeeper.Application.DTOs;
using CodeKeeper.Application.Interfaces;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata;
using CodeKeeper.UI.interfaces;

namespace CodeKeeper.UI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly INavigationService navigation;
        public IAsyncRelayCommand LoginCommand { get; }

        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public LoginViewModel(IAuthService authService, INavigationService navigation)
        {
            _authService = authService;
            this.navigation = navigation;
            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }

        private async Task LoginAsync()
        {
            try
            {
                var dto = new LoginDTO
                {
                    Email = Email,
                    Password = Password
                };

                var user = await _authService.LoginAsync(dto);
                MessageBox.Show($"Welcome, {user.userName}!");

                navigation.NavigateToMain();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}");
            }
        }
    }
}
