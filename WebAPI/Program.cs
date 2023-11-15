using System.Configuration;
using DomainModels.Context;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using WebAPI;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder
            .Services
            .AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        string? connString = builder.Configuration.GetConnectionString("HumanResourcesDBContext");
        // Add services to the container.

        builder
            .Services
            .AddControllers(options =>
            {
                // options.Filters.Add<HttpResponseExceptionFilter>();
            });
            // .ConfigureApiBehaviorOptions(options =>
            // {
            //     options.InvalidModelStateResponseFactory = context =>
            //         new BadRequestObjectResult(context.ModelState)
            //         {
            //             ContentTypes =
            //             {
            //                 // using static System.Net.Mime.MediaTypeNames;
            //                 Application.Json,
            //                 Application.Xml
            //             }
            //         };
            // })
            // .AddXmlSerializerFormatters();
        ;
        builder.Services.AddAutoMapper(typeof(HumanResourceProfile));
        Configure(builder.Services, connString);
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseCors();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    private static void Configure(IServiceCollection services, string connString)
    {
        services.AddDbContext<HumanResourceContext>(options => options.UseNpgsql(connString));
        services.AddScoped<UnitOfWork, UnitOfWork>();
        services.AddScoped<Services.ServiceProvider, Services.ServiceProvider>();
    }
}
