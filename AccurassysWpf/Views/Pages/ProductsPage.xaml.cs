using AccurassysWpf.Shared.Enumerators;

namespace AccurassysWpf.Views.Pages
{
    using AccurassysWpf.ViewModels.Pages;
    using System;
    using System.Windows.Input;
    using Wpf.Ui.Controls;
    using AccurassysWpf.Models.DTOs;
    using System.Windows.Controls;
    using Microsoft.Extensions.DependencyInjection;
    using AccurassysWpf.ViewModels.Windows;
    using AccurassysWpf.Views.Windows;

    public partial class ProductsPage : INavigableView<ProductsViewModel>
    {
        private readonly IServiceProvider _serviceProvider;
        public ProductsViewModel ViewModel { get; }

        public ProductsPage(ProductsViewModel viewModel, IServiceProvider serviceProvider)
        {
            ViewModel = viewModel;
            _serviceProvider = serviceProvider;
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void OnProductDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is System.Windows.Controls.DataGrid dataGrid && dataGrid.SelectedItem is ProductsDTO selectedProduct)
            {
                // Resolve ProductDetailWindow usando o contêiner de injeção de dependência
                var detailWindow = _serviceProvider.GetRequiredService<ProductDetailWindow>();

                // Configura o produto no ViewModel da janela de detalhes
                if (detailWindow.DataContext is ProductDetailViewModel detailViewModel)
                {
                    detailViewModel.Product = selectedProduct;
                    detailViewModel.ProductCrudState = ProductCrudStateEnum.Update;
                    
                    detailWindow.HandleButton.Content = "Atualizar";
                }

                detailWindow.ShowDialog();
            }
        }

        private async void CreateProduct(object sender, RoutedEventArgs e)
        {
            var newProduct = new ProductsDTO();

            var detailWindow = _serviceProvider.GetRequiredService<ProductDetailWindow>();

            if (detailWindow.DataContext is ProductDetailViewModel detailViewModel)
            {
                detailViewModel.Product = newProduct;
                detailViewModel.ProductCrudState = ProductCrudStateEnum.Create;
                
                detailWindow.HandleButton.Content = "Criar";
            }

            detailWindow.ShowDialog();
        }

        private async void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            // Carrega os produtos ao abrir a página
            if (DataContext is ProductsViewModel viewModel && viewModel.GetProductsCommand.CanExecute(null))
            {
                await viewModel.GetProductsCommand.ExecuteAsync(null);
            }
        }
    }
}
