using AccurassysWpf.Models.DTOs.Login;
using AccurassysWpf.Services;
using AccurassysWpf.Services.Api.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Wpf.Ui.Appearance;

namespace AccurassysWpf.Views.Windows
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthenticationApi _authenticationApi;
        private readonly ApplicationHostService _hostService;
        private readonly TokenProvider _tokenProvider;

        public LoginWindow(
            IServiceProvider serviceProvider, 
            IAuthenticationApi authenticationApi,
            ApplicationHostService hostService,
            TokenProvider tokenProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _authenticationApi = authenticationApi;
            _hostService = hostService;
            _tokenProvider = tokenProvider;

            // Defina o tema ao abrir a tela de login
            ApplicationThemeManager.Apply(ApplicationThemeManager.GetAppTheme());
        }

        private async void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            // Autenticação aqui (assumindo uma chamada ao método de autenticação)
            bool loginSuccess = await AuthenticateUserAsync(email, password);

            if (loginSuccess)
            {
                // Chama o método para abrir o MainWindow e navega para a DashboardPage
                _hostService.OpenMainWindow();
                this.Close(); // Fecha a janela de login
            }
            else
            {
                MessageBox.Show("Login failed. Please check your credentials.");
            }
        }

        private async Task<bool> AuthenticateUserAsync(string email, string password)
        {
            var loginRequest = new LoginRequest
            {
                Email = email,
                Password = password
            };

            try
            {
                var loginResponse = await _authenticationApi.LoginAsync(loginRequest);

                if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.AccessToken))
                {
                    // Armazena o token para futuras requisições
                    _tokenProvider.AccessToken = loginResponse.AccessToken;  // Armazena o token
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}");
            }

            return false;
        }
    }
}
