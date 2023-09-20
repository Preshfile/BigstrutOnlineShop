using BigstrutOnlineShop.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using BigstrutOnlineShop.web.Services.Contracts;

namespace BigstrutOnlineShop.web.Services
{
	public class ProductService : IProductService
	{
		private readonly HttpClient httpClient;

		public ProductService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

        public async Task<ProductDto?> GetItem(int id)
        {
           try
			{
				var response = await httpClient.GetAsync($"api/Product/{id}");

				if (response.IsSuccessStatusCode)
				{
					if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return default;
					}

					return await response.Content.ReadFromJsonAsync<ProductDto>();
				}
				else
				{
					var message = await response.Content.ReadAsStringAsync();
					throw new Exception(message);
				}
			}
			catch (Exception)
			{
				//Log Exception
				throw;
			}
        }

        public async Task<IEnumerable<ProductDto>?> GetItems()
		{
			try
			{
				var response = await this.httpClient.GetAsync("api/Product");

				if (response.IsSuccessStatusCode)
				{
					if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
					{
						return Enumerable.Empty<ProductDto>();
					}
					return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
				}
				else
				{
					var message = await response.Content.ReadAsStringAsync();
					throw new Exception($"Http status code: {response.StatusCode} message: {message}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while retrieving products: {ex.Message}");
				return null;
			}
		}
	}
}
