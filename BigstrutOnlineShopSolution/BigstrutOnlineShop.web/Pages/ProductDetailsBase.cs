using BigstrutOnlineShop.Models.Dtos;
using BigstrutOnlineShop.web.Services;
using Microsoft.AspNetCore.Components;
using BigstrutOnlineShop.web.Services.Contracts;

namespace BigstrutOnlineShop.web.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IProductService? ProductService { get; set; } // Make it nullable

        [Inject]
        public IShoppingCartService? ShoppingCartService { get; set; }

		[Inject]
		public NavigationManager? NavigationManager { get; set; }

		public ProductDto? Product { get; set; } // Make it nullable

        public string? ErrorMessage { get; set; } // Make it nullable

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (ProductService != null)
                {
                    Product = await ProductService.GetItem(Id);
                }
                else
                {
                    ErrorMessage = "Product service is not available.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                if (ShoppingCartService != null)
                {
                    var cartItemDto = await ShoppingCartService.AddItem(cartItemToAddDto);
                    NavigationManager.NavigateTo("/ShoppingCart");
                }
            }
            catch (Exception)
            {
                // Log Exception
            }
        }


    }
}
