using BigstrutOnlineShop.Models.Dtos;
using BigstrutOnlineShop.web.Services;
using BigstrutOnlineShop.web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigstrutOnlineShop.web.Pages
{
	public class ProductsBase : ComponentBase
	{
		[Inject]
		public IProductService? ProductService { get; set; }

		[Inject]
		public IShoppingCartService? ShoppingCartService { get; set; }

		public IEnumerable<ProductDto>? Products { get; set; }

		public NavigationManager NavigationManager { get; set; }

		protected override async Task OnInitializedAsync()
		{
			if (ProductService != null)
			{
				Products = await ProductService.GetItems();
				var shoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
				var totalQty = shoppingCartItems.Sum(i => i.Qty);

				ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);
				
			}
		}

		protected IOrderedEnumerable<IGrouping<int,ProductDto>> GetGroupedProductsByCategory()
		{
			return from product in Products
				   group product by product.CategoryId into prodByCatGroup
				   orderby prodByCatGroup.Key
				   select prodByCatGroup;
		}
        protected static string GetCategoryName(IGrouping<int, ProductDto> groupedProductDtos)
        {
            return groupedProductDtos.FirstOrDefault(pg => pg.CategoryId == groupedProductDtos.Key)?.CategoryName ?? "Unknown Category";
        }

    }
}
