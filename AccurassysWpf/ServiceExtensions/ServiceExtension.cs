using AccurassysWpf.Services;
using AccurassysWpf.Services.Api.Authentication;
using AccurassysWpf.Services.Api.Products.Interface;
using AccurassysWpf.ViewModels.Pages;
using AccurassysWpf.ViewModels.Windows;
using AccurassysWpf.Views.Pages;
using AccurassysWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Wpf.Ui;

namespace AccurassysWpf.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services) 
        {
            // Registre ApplicationHostService como singleton e hosted service
            services.AddSingleton<ApplicationHostService>();
            services.AddHostedService(sp => sp.GetRequiredService<ApplicationHostService>());


            // Page resolver service
            services.AddSingleton<IPageService, PageService>();

            // Theme manipulation
            services.AddSingleton<IThemeService, ThemeService>();

            // TaskBar manipulation
            services.AddSingleton<ITaskBarService, TaskBarService>();

            // Service containing navigation, same as INavigationWindow... but without window
            services.AddSingleton<INavigationService, NavigationService>();

            // Main window with navigation
            services.AddSingleton<INavigationWindow, MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<DashboardPage>();
            services.AddSingleton<DashboardViewModel>();

            services.AddSingleton<DataPage>();
            services.AddSingleton<DataViewModel>();

            services.AddSingleton<SettingsPage>();
            services.AddSingleton<SettingsViewModel>();

            services.AddSingleton<ProductsPage>();
            services.AddSingleton<ProductsViewModel>();

            services.AddTransient<ProductDetailWindow>();
            services.AddSingleton<ProductDetailViewModel>();

            services.AddTransient<LoginWindow>();

            services.AddTransient<AuthenticatedHttpClientHandler>();

            return services;
        }
    }
}
