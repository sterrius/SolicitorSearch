
using SolicitorSearch.API.Handlers;
using SolicitorSearch.APP;
using SolicitorSearch.DAL.Repositories;
using SolicitorSearch.INF;

namespace SolicitorSearch.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSingleton<ISolicitorSearchHandler, SolicitorSearchHandler>();
        builder.Services.AddSingleton<ISolicitorSourceRepository, SolicitorSourceRepository>();
        builder.Services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();
        builder.Services.AddSingleton<ISolicitorWebSearch, SolicitorWebSearch>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
