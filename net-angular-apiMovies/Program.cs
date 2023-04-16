using Microsoft.EntityFrameworkCore;
using net_angular_apiMovies.Models.Domain;

namespace net_angular_apiMovies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DatabaseContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("dbconnection")));
            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}