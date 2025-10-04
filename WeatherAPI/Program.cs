
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WeatherAPI.Services.Implamantations;
using WeatherAPI.Services.Interfaces;

namespace WeatherAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient<ICountiesService, CountriesService1>((sp, http) =>
            {
                var opts = sp.GetRequiredService<IOptions<CountriesService1>>().Value;
                if (!string.IsNullOrWhiteSpace(opts.BaseUrl))
                {
                    http.BaseAddress = new Uri(opts.BaseUrl);
                }
            });
            builder.Services.AddScoped<ICountiesService ,CountriesService1>();

            
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();   
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
