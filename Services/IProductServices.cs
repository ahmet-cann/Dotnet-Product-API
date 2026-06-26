using FIRSTAPI.DTOs;



namespace FIRSTAPI.Services

{

    public interface IProductServices

    {

        Task<List<ProductResponse>> GetAllProducts();

        Task<ProductResponse> GetProductById(int id);

        Task<ProductResponse> CreateProduct(CreateProductRequest productRequest);

        Task<ProductResponse> UpdateProduct(int id, UpdateProductRequest productRequest);

        Task<bool> DeleteProduct(int id);



    }

}