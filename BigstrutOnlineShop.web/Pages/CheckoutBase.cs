﻿

using BigstrutOnlineShop.Models.Dtos;
using BigstrutOnlineShop.web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BigstrutOnlineShop.web.Pages
{
    public class CheckoutBase:ComponentBase
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }

        protected int TotalQty { get; set; }

        protected string PaymentDescription { get; set; }  
        
        protected decimal PaymentAmount { get; set; }

        [Inject]
        public IShoppingCartService shoppingCartService { get; set; }  

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await shoppingCartService.GetItems(HardCoded.UserId);

                if (ShoppingCartItems != null)
                {
                    Guid orderGuid = Guid.NewGuid();

                    PaymentAmount = ShoppingCartItems.Sum(p => p.TotalPrice);
                    TotalQty = ShoppingCartItems.Sum(p => p.Qty);
                    PaymentDescription = $"O_{HardCoded.UserId}_{orderGuid}";

                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await Js.InvokeVoidAsync("initPayPalButton");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
