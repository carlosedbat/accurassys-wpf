using AccurassysWpf.Models.DTOs.Products;

namespace AccurassysWpf.Services.Api.Products.Interface
{
    using AccurassysWpf.Models.DTOs;
    using Refit;
    using System.Threading.Tasks;

    public interface IProductsApi
    {
        // Obter todos os produtos com paginação
        [Get("/api/Products")]
        Task<ApiResponseListDTO<ProductsDTO>> GetProductsAsync(
            [Query] int pageIndex = 1,                 // Default: página 1
            [Query] string description = null,         // Default: nenhum filtro de descrição
            [Query] double? price = null);            // Default: nenhum filtro de preço

        // Obter um produto específico por ID
        [Get("/api/Products/{id}")]
        Task<ApiResponseDTO<ProductsDTO>> GetProductByIdAsync(Guid id);

        // Criar um novo produto
        [Post("/api/Products")]
        Task<ApiResponseDTO<ProductsDTO>> CreateProductAsync([Body] CreateProductDto product);

        // Atualizar um produto existente
        [Put("/api/Products")]
        Task<ApiResponseDTO<ProductsDTO>> UpdateProductAsync([Body] ProductsDTO product);

        // Excluir um produto por ID
        [Delete("/api/Products/{id}")]
        Task<ApiResponseDTO<ProductsDTO>> DeleteProductAsync(Guid id);
    }
}
