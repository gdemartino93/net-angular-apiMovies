using Microsoft.EntityFrameworkCore;
using net_angular_apiMovies.Models.Domain;
using net_angular_apiMovies.Repositories.Abstract;
using net_angular_apiMovies.Repositories.Implementation;

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

            //resolve dependencies
            builder.Services.AddTransient<IMovieRepository, MovieRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(
                options =>
                options.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.MapControllers();

            app.Run();
        }
    }
}