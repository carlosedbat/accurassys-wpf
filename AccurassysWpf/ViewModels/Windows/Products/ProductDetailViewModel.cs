using AccurassysWpf.Models.DTOs.Products;
using AccurassysWpf.Shared.Enumerators;
using AutoMapper;
using Wpf.Ui.Controls;

namespace AccurassysWpf.ViewModels.Windows
{
    using AccurassysWpf.Models.DTOs;
    using AccurassysWpf.Services.Api.Products.Interface;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using System.Threading.Tasks;
    using System.Windows;

    public partial class ProductDetailViewModel : ObservableObject
    {
        private readonly IProductsApi _productsApi;
        
        [ObservableProperty]
        private ProductCrudStateEnum _productCrudState;

        [ObservableProperty]
        private ProductsDTO product;
        
        private readonly IMapper _mapper;
        
        public ProductDetailViewModel(
            IProductsApi productsApi,
            IMapper mapper)
        {
            _productsApi = productsApi;
            _mapper = mapper;
        }

        [RelayCommand]
        private async Task HandleAddOrUpdateProductAsync()
        {
            try
            {
                switch (ProductCrudState)
                {
                    case ProductCrudStateEnum.Create:
                        await this.CreateProductAsync();
                        break;
                    case ProductCrudStateEnum.Update:
                        await this.UpdateProductAsync();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [RelayCommand]
        private async Task UpdateProductAsync()
        {
            try
            {
                var updatedProduct = await _productsApi.UpdateProductAsync(Product);
                Product = updatedProduct.GenericData;  // Presume que UpdateProductAsync retorna um único ProductDTO
                MessageBox.Show("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o produto: {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task DeleteProductAsync()
        {
            try
            {
                await _productsApi.DeleteProductAsync(Product.Id);
                MessageBox.Show("Produto excluído com sucesso!");
                Product = null; // Opcional, para limpar os dados do produto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o produto: {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task CreateProductAsync()
        {
            try
            {
                CreateProductDto productToCreate = this._mapper.Map<CreateProductDto>(Product);
                
                await _productsApi.CreateProductAsync(productToCreate);
                MessageBox.Show("Produto cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [RelayCommand]
        private async Task LoadImageAsync()
        {
            // Implementar lógica de carregamento da imagem se necessário
            MessageBox.Show("Imagem carregada!");
        }
    }
}
