
using BigstrutOnlineShop.Api.Data;
using BigstrutOnlineShop.Api.Entities;
using BigstrutOnlineShop.Api.Repositories;
using BigstrutOnlineShop.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace BigstrutOnlineShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContextPool<BigstrutOnlineShopDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BigstrutOnlineShopConnection"))
            );

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(policy =>
                policy.WithOrigins("http://localhost:7232", "https://localhost:7232")
                .AllowAnyMethod()
                .WithHeaders(HeaderNames.ContentType)

            );

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}