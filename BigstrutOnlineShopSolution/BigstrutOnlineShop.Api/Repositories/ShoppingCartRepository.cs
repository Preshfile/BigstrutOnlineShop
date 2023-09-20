using BigstrutOnlineShop.Api.Data;
using BigstrutOnlineShop.Api.Entities;
using BigstrutOnlineShop.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BigstrutOnlineShop.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly BigstrutOnlineShopDbContext bigstrutOnlineShopDbContext;

        public ShoppingCartRepository(BigstrutOnlineShopDbContext bigstrutOnlineShopDbContext)
        {
            this.bigstrutOnlineShopDbContext = bigstrutOnlineShopDbContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await this.bigstrutOnlineShopDbContext.CartItems.AnyAsync(c =>c.CartId == cartId &&
                                                                             c.ProductId == productId);
        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in this.bigstrutOnlineShopDbContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await this.bigstrutOnlineShopDbContext.CartItems.AddAsync(item);
                    await this.bigstrutOnlineShopDbContext.SaveChangesAsync();
                    return result.Entity;
                }
                else
                {
                    throw new InvalidOperationException("Failed to add item to the cart.");
                }
            }

            throw new InvalidOperationException("Item already exists in the cart.");
        }



        public async Task<CartItem> DeleteItem(int id)
        {
           var item = await this.bigstrutOnlineShopDbContext.CartItems.FindAsync(id);

            if (item != null)
            {
                this.bigstrutOnlineShopDbContext.CartItems.Remove(item);
                await this.bigstrutOnlineShopDbContext.SaveChangesAsync();
            }
            return item;
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in this.bigstrutOnlineShopDbContext.Carts
                          join cartItem in this.bigstrutOnlineShopDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> GetItem(int id)
        {
            var cartItem = await (from cart in this.bigstrutOnlineShopDbContext.Carts
                                  join cartItemEntry in this.bigstrutOnlineShopDbContext.CartItems
                                  on cart.Id equals cartItemEntry.CartId
                                  where cartItemEntry.Id == id
                                  select new CartItem
                                  {
                                      Id = cartItemEntry.Id,
                                      ProductId = cartItemEntry.ProductId,
                                      Qty = cartItemEntry.Qty,
                                      CartId = cartItemEntry.CartId
                                  }).SingleOrDefaultAsync();

            return cartItem ?? throw new InvalidOperationException("CartItem not found.");
        }


        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            var item = await this.bigstrutOnlineShopDbContext.CartItems.FindAsync(id);
            
            if (item != null)
            {
                item.Qty = cartItemQtyUpdateDto.Qty;
                await this.bigstrutOnlineShopDbContext.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
