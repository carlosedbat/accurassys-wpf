using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace AccurassysWpf.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "AccurassysWpf";

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Inicio",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            // new NavigationViewItem()
            // {
            //     Content = "Orçamentos",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Add28 },
            //     TargetPageType = typeof(Views.Pages.DashboardPage)
            // },
            // new NavigationViewItem()
            // {
            //     Content = "Ordem de Serviços",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Add28 },
            //     TargetPageType = typeof(Views.Pages.DashboardPage)
            // },
            // new NavigationViewItem()
            // {
            //     Content = "Clientes",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Add28 },
            //     TargetPageType = typeof(Views.Pages.DashboardPage)
            // },
            // new NavigationViewItem()
            // {
            //     Content = "Calibração",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Add28 },
            //     TargetPageType = typeof(Views.Pages.DashboardPage)
            // },
            // new NavigationViewItem()
            // {
            //     Content = "Equipamentos",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Add28 },
            //     TargetPageType = typeof(Views.Pages.DashboardPage)
            // },
            // new NavigationViewItem()
            // {
            //     Content = "Padrões",
            //     Icon = new SymbolIcon { Symbol = SymbolRegular.Add28 },
            //     TargetPageType = typeof(Views.Pages.DashboardPage)
            // },
            new NavigationViewItem()
            {
                Content = "Produtos",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Add28 },
                TargetPageType = typeof(Views.Pages.ProductsPage)
            },
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
