
using Microsoft.EntityFrameworkCore;
using Shop.Repo.Abstractions;
using Shop.Repo.Repositories;
using Shop.Service;
using Shop.Service.Abstractions;
using Shop.Service.Services;

namespace ShopWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ShopDBContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString("Shop")));
            builder.Services.AddScoped<IGoodService, GoodService>();
            builder.Services.AddScoped<ISoldGoodService, SoldGoodService>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<IWorkerService, WorkerService>();
            builder.Services.AddScoped<IGoodRepository, GoodRepository>();
            builder.Services.AddScoped<ISoldGoodRepository, SoldGoodRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
