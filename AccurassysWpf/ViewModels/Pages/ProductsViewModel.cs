using AccurassysWpf.Models.DTOs;
using AccurassysWpf.Services.Api.Products.Interface;
using System.Collections.ObjectModel;

namespace AccurassysWpf.ViewModels.Pages
{
    public partial class ProductsViewModel : ObservableObject
    {
        private readonly IProductsApi _productApi;

        [ObservableProperty]
        private ObservableCollection<ProductsDTO> products = new ObservableCollection<ProductsDTO>();

        [ObservableProperty]
        private int pageIndex = 1;

        [ObservableProperty]
        private int pageSize = 10; // Define o tamanho da página
        
        public ProductsViewModel(IProductsApi productApi)
        {
            _productApi = productApi;
        }

        public IAsyncRelayCommand LoadProductsCommand { get; }
        public IRelayCommand NextPageCommand { get; }
        public IRelayCommand PreviousPageCommand { get; }

        [RelayCommand]
        private async Task GetProductsAsync()
        {
            try
            {
                var productList = await _productApi.GetProductsAsync();

                Products.Clear();
                foreach (var product in productList.GenericData)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções (log, notificação, etc.)
            }
        }

        private async Task LoadProductsAsync()
        {
            var response = await _productApi.GetProductsAsync(pageIndex, null, null); // Filtros adicionais podem ser adicionados
            Products.Clear();
            if (response?.GenericData != null)
            {
                foreach (var product in response.GenericData)
                {
                    Products.Add(product);
                }
            }
        }

        private void NextPage()
        {
            PageIndex++;
            LoadProductsCommand.Execute(null);
        }

        private void PreviousPage()
        {
            if (PageIndex > 1)
            {
                PageIndex--;
                LoadProductsCommand.Execute(null);
            }
        }
    }
}
