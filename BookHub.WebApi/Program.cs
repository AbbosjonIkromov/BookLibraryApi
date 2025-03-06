using BookHub.WebApi.Data;
using BookHub.WebApi.Data.Interceptor;
using BookHub.WebApi.Dtos;
using BookHub.WebApi.Repository.Contracts;
using BookHub.WebApi.Repository.Implementations;
using BookHub.WebApi.Services.Contracts;
using BookHub.WebApi.Services.Implementations;
using BookHub.WebApi.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookHub.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IValidator<CreateBookDto>, CreateBookDtoValidation>();
            builder.Services.AddScoped<IValidator<UpdateBookDto>, UpdateBookDtoValidation>();

            builder.Services.AddDbContext<BookHubContext>(builder =>
            {
                var connectionString =
                    "Host=localhost;Port=5432;Database=book_hub; User Id=postgres;Password=postgresql;";

                builder.UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention()
                    .AddInterceptors(new AuditInterceptor());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

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
