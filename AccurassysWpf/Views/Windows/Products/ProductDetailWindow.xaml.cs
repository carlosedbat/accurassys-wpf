using AccurassysWpf.Models.DTOs;
using AccurassysWpf.ViewModels.Windows;
using System.Windows;
using Wpf.Ui.Appearance;

namespace AccurassysWpf.Views.Windows
{
    /// <summary>
    /// Lógica interna para ProductDetailWindow.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        public ProductDetailWindow(ProductDetailViewModel viewModel)
        {
            InitializeComponent();
            SystemThemeWatcher.Watch(this);

            DataContext = viewModel;
        }

        public void SetProduct(ProductsDTO product)
        {
            if (DataContext is ProductDetailViewModel viewModel)
            {
                viewModel.Product = product;
            }
        }
    }
}
