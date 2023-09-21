using BigstrutOnlineShop.Models.Dtos;
using Microsoft.AspNetCore.Components;


namespace BigstrutOnlineShop.web.Pages
{
    public class DisplayProductsBase:ComponentBase
	{
		[Parameter]
        public IEnumerable<ProductDto>? Products { get; set; }
    }
}
