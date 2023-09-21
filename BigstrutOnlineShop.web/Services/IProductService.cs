using BigstrutOnlineShop.Models.Dtos;

namespace BigstrutOnlineShop.web.Services
{
    public interface IProductService
	{
		Task<IEnumerable<ProductDto>?> GetItems();
		Task<ProductDto?> GetItem(int id);
	}
}