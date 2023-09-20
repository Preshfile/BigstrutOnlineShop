using BigstrutOnlineShop.Models.Dtos;

namespace BigstrutOnlineShop.web.Services.Contracts
{
    public interface IServiceProduct
    {
        Task<IEnumerable<ProductDto>> GetItems();
    }
}
